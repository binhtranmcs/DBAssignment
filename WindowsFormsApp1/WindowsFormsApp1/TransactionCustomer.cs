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
    public partial class Transaction : Form
    {
        int cid = -1;
        DateTime date;
        public Transaction(int _cid = -1)
        {
            InitializeComponent();
            cid = _cid;
            load_view();
        }

        public void load_view()
        {
            load_type();
        }

        public void load_type()
        {
            Console.WriteLine("Test genre Box");
            typeBox.Items.Clear();
            typeBox.Items.Add("All transaction");
            typeBox.Items.Add("Error transaction");
            typeBox.Items.Add("Unfinished transaction");
            typeBox.Items.Add("Most-book transaction");
            typeBox.Items.Add("Mixed-book transaction");
        }

        private void btnGetAuthor_Click(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("", con);
                int month = date.Month;
                int year = date.Year;
                Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx" + cid + " " + month + " " + year);

                if (typeBox.Text == "All transaction")
                {
                    cmd = new SqlCommand("SELECT * FROM dbo.list_all_transaction(@cid, @month, @year)", con);
                }
                if (typeBox.Text == "Error transaction")
                {
                    cmd = new SqlCommand("SELECT * FROM dbo.list_error_transaction(@cid, @month, @year)", con);
                }
                if (typeBox.Text == "Unfinished transaction")
                {
                    cmd = new SqlCommand("SELECT * FROM dbo.list_unfinished_transaction(@cid, @month, @year)", con);
                }
                if (typeBox.Text == "Most-book transaction")
                {
                    cmd = new SqlCommand("SELECT * FROM dbo.max_bill(@cid, @month, @year)", con);
                }
                if (typeBox.Text == "Mixed-book transaction")
                {
                    cmd = new SqlCommand("SELECT * FROM dbo.mixed_bill(@cid, @month, @year)", con);
                }

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cid", cid);
                cmd.Parameters.AddWithValue("@month", month);
                cmd.Parameters.AddWithValue("@year", year);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView1.DataSource = dt;
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
    }
}
