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
    public partial class InfoCustomer : Form
    {
        int cid = -1;
        public InfoCustomer(int _cid = -1)
        {
            InitializeComponent();
            cid = _cid;
            Console.WriteLine("Ok day la Customer Info co id la: " + cid.ToString());
            load_view();
        }

        void load_view()
        {
            string cname = "";
            string cemail = "";
            string caddress = "";
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE cid='" + cid.ToString() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("Number account InfoCustomer: " + dt.Rows.Count.ToString());
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("Oups, co gi do sai sai o Info Customer");
                        con.Close();
                        return;
                    }
                    cname = dt.Rows[0]["cname"].ToString();
                    cemail = dt.Rows[0]["cemail"].ToString();
                    caddress = dt.Rows[0]["caddress"].ToString();
                }
                else
                {
                    MessageBox.Show("Wrong Username and Password Infor Customer, Please try again", "Wrong account", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBox1.Text = cname;
            textBox2.Text = cemail;
            textBox3.Text = caddress;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string cname = textBox1.Text;
            string cemail = textBox2.Text;
            string caddress = textBox3.Text;
            if (cname == "" || cemail == "" || caddress == "")
            {
                MessageBox.Show("Enter Your Information to Update", "Empty Blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                Console.WriteLine(cname + " " + cemail + " " + caddress);
                con.Open();
                SqlCommand cmd = new SqlCommand("updateInfo_Customer", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@cid", cid));
                cmd.Parameters.Add(new SqlParameter("@cname", cname));
                cmd.Parameters.Add(new SqlParameter("@cemail", cemail));
                cmd.Parameters.Add(new SqlParameter("@caddress", caddress));

                SqlDataReader rdr = cmd.ExecuteReader();
                MessageBox.Show("Ok update thanh cong");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            load_view();
        }
    }
}
