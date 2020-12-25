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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Password and Confirm password don't match !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string username = textBox1.Text;
            string pass = textBox2.Text;
            if (username == "" || pass == "")
            {
                MessageBox.Show("Enter Your Username and Password To Sign Up", "Empty Blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkAccount(username))
            {
                int cid = addCustomer();
                if (cid == -1)
                {
                    MessageBox.Show("Co gi do sai sai o Sign Up");
                    return;
                }
                addAccount(cid, username, pass);
                textBox1.Text = textBox2.Text = textBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Account username has been created, Please Try Again", "Failed username account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void addAccount(int accid, string username, string pass)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO account VALUES(@username, @password, @type_account, @accid)", con);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", pass);
                cmd.Parameters.AddWithValue("type_account", "Customer");
                cmd.Parameters.AddWithValue("accid", accid.ToString());
                if (cmd.ExecuteNonQuery() > 0)
                {
                    MessageBox.Show("Your Account Has Been Created", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed add accid account");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed add account");
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
        }
        private int addCustomer()
        {
            int cid = -1;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO customer VALUES(@caddress, @cname, @cemail)", con);
                cmd.Parameters.AddWithValue("caddress", "default");
                cmd.Parameters.AddWithValue("cname", "default");
                cmd.Parameters.AddWithValue("cemail", "default@gmail.com");
                Console.WriteLine("add customer: " + cmd.ExecuteNonQuery().ToString());
                MessageBox.Show("New Customer Has Been Created", "Customer Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd = new SqlCommand("SELECT MAX(cid) FROM customer", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cid = Convert.ToInt32(dt.Rows[0][0]);
                Console.WriteLine("Id customer: " + cid);
            }
            catch (Exception)
            {
                MessageBox.Show("Failed add customer");
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return cid;
        }
        private bool checkAccount(string username)
        {
            bool ok = true;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM account WHERE username='" + username + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    ok = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed check account");
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return ok;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

    }
}
