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
    public partial class Customer : Form
    {
        public int cid = -1;
        public Customer(int _cid = -1)
        {
            InitializeComponent();
            cid = _cid;
            Console.WriteLine("Ok day la Customer1 co id la: " + cid.ToString());
            showNameCustomer(cid);
            showbook();
        }
        
        public void showbook()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_isbn", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bookView.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
        }
        public void showName(string nameCustomer)
        {
            label1.Text = "Hi " + nameCustomer;
            label1.Refresh();
        }
        public void showNameCustomer(int cid)
        {
            string name = "";
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM customer WHERE cid='" + cid.ToString() +  "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("Number customer: " + dt.Rows.Count.ToString());
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("Oups, co gi do sai sai o Customer show Name");
                        con.Close();
                        return;
                    }
                    name = dt.Rows[0]["cname"].ToString();
                }
                else
                {
                    MessageBox.Show("Oups, co gi do sai sai o Customer show Name");
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
            showName(name);
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            var fm = new InfoCustomer(cid);
            fm.ShowDialog();
            showNameCustomer(cid);
            showbook();
        }

        private void btnGetBook_Click(object sender, EventArgs e)
        {
            var fm = new GetBookCustomer(cid);
            fm.ShowDialog();
        }
    }
}
