using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public partial class insertchinh : Form
    {
        string type = "";
        string isbn = "";
        string price = "";
        string genre = "";
        string title = "";
        string publisher = "";
        string author = "";
        string store = "";
        public insertchinh()
        {
            InitializeComponent();
            ViewAllBook_ForISBN();
            ViewAllBook_ForISBN2();
        }

        private void insertchinh_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            type = comboBox1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            isbn = textBox1.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            title = textBox6.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            price = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            author = textBox4.Text;
        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            genre = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(type);
            if (type == "ebook") UpdateEbook();
            else UpdatePbook();
        }
        //
        private void UpdateEbook()
        {

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Insert_eBookISBN", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@isbn", isbn));
                cmd.Parameters.Add(new SqlParameter("@genre", genre));
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@aname", author));
                SqlDataReader rdr = cmd.ExecuteReader();

                MessageBox.Show("Ok insert eBook thanh cong");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            ViewAllBook_ForISBN();
        }
        private void UpdatePbook()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Insert_pBookISBN", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@isbn", isbn));
                cmd.Parameters.Add(new SqlParameter("@genre", genre));
                cmd.Parameters.Add(new SqlParameter("@title", title));
                cmd.Parameters.Add(new SqlParameter("@price", price));
                cmd.Parameters.Add(new SqlParameter("@aname", author));
                SqlDataReader rdr = cmd.ExecuteReader();

                MessageBox.Show("Ok insert pBook thanh cong");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            ViewAllBook_ForISBN2();
        }
        //
        private void ViewAllBook_ForISBN()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.ebookInsert()", con);//4

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

        private void ViewAllBook_ForISBN2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.pbookInsert()", con);//4

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);

                dataGridView2.DataSource = dt;
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

        private void label8_Click(object sender, EventArgs e)
        {

        }

       

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
