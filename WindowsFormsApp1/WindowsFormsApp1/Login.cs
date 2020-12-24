using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            SqlConnection con = new SqlConnection(@"Data Source=TECHMAC\SQLEXPRESS;Initial Catalog=db_QL;Integrated Security=True");

        }
        private string getID(string username, string pass)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            string id = "";
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM account WHERE username ='" + username + "' and pass='" + pass + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        id = dr["id_user"].ToString();
                    }
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
            return id;
        }
    }
}
