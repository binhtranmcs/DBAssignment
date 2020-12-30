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
    public partial class insert : Form
    { string keyword = "";
        string bookid = "";
        string bookprice = "";
        public insert()
        {
            InitializeComponent();
            ViewAllBook_ForISBN();
            ViewAllBook_ForISBN2();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyword = comboBox1.Text;
        }
        private void ViewAllBook_ForISBN()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from ebook inner join book_isbn on book_isbn.isbn=ebook.isbn", con);//4

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
                SqlCommand cmd = new SqlCommand("Select * from pbook inner join book_isbn on book_isbn.isbn=pbook.isbn", con);//4

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
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void insert_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (keyword == "ebook") UpdateEbook(bookid, bookprice);
            else UpdatePbook(bookid, bookprice);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            bookid = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            bookprice = textBox4.Text;
        }
        private void UpdateEbook(string bookid, string bookprice){

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("exec updateImport_BookISBN "+bookid+","+bookprice, con);

                cmd.ExecuteNonQuery();
                ViewAllBook_ForISBN();
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
        private void UpdatePbook(string bookid, string bookprice)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("exec updateImport_pBookISBN " + bookid + "," + bookprice, con);

                cmd.ExecuteNonQuery();
                ViewAllBook_ForISBN2();
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
