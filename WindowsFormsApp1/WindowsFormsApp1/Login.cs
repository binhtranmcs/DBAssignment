using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = "";
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string pass = textBox2.Text;
            string typeAccount = "";
            int accid = -1;
            if (username == "" || pass == "")
            {
                MessageBox.Show("Enter Your Username and Password To Login", "Empty Blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                Console.WriteLine(username + " " + pass);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM account WHERE username='" + username + "' and password='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                { 
                    Console.WriteLine("Number account: " + dt.Rows.Count.ToString());
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("Oups, co gi do sai sai o Login");
                        con.Close();
                        return;
                    }
                    typeAccount = dt.Rows[0]["type_account"].ToString();
                    accid = Convert.ToInt32(dt.Rows[0]["accid"]);
                }
                else
                {
                    MessageBox.Show("Wrong Username and Password, Please try again", "Wrong account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            Console.WriteLine("Debug login: " + typeAccount + " " + accid.ToString());
            if (typeAccount == "Admin")
            {
                MessageBox.Show("Day la Admin account");
            }
            else
            {
                if (typeAccount == "Customer")
                {
                    var fm = new Customer(accid);
                    fm.ShowDialog();
                }
                if (typeAccount == "Employee")
                {
                    var fm = new Employee(accid);
                    fm.ShowDialog();
                }
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            var fm = new SignUp();
            fm.ShowDialog();
        }
    }
}
