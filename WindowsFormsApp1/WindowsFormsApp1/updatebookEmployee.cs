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
    public partial class updatebookEmployee : Form
    {
        DateTime date_published;
        string keyword="";
        public updatebookEmployee()
        {
            InitializeComponent();
        }

        private void updatebookEmployee_Load(object sender, EventArgs e)
        {
           
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           keyword = comboBox1.Text;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        //4
        private void ViewAllBook_ForISBN_OneDay() {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
               
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.ISBN_Bought_Oneday(@date)", con);//4
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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
        //5
        private void ViewAllBook_ForEachISBN_OneDay()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Totalof_ISBN_Bought_Oneday(@date)", con);//5
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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
        //6
        private void ViewAllpBook_ForEachISBN_OneDay()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Totalof_Pbook_ISBN_Bought_Oneday(@date)", con);//6
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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
        //7
        private void ViewAlleBook_BuyFor_OneDay()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.Ebook_Bought_Oneday(@date)", con);//7
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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
        //8
        private void ViewAlleBook_BorrowFor_OneDay()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT  dbo.Ebook_Borrowed_Oneday(@date)", con);//8
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dt = new DataSet();
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
        //9
        private void ViewAuthor_MostBoughted_Oneday()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Most_Author_Bought_Oneday(@date)", con);//9
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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
        //12
        private void ViewBill_ForCreditBuy_OneDay()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Credit_Bought_Oneday(@date)", con);//12
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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
        //13
        private void ViewBill_ForIssue_Oneday()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Issue_Bought_Oneday(@date)", con);//13
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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
        // common
      /*  private void ViewAllBook()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.", con);//common
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@date", date_published);
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


        }*/
        //
        private void button1_Click(object sender, EventArgs e)
        {
            date_published = dateTimePicker1.Value;
          //  ViewAllBook();
            if (keyword == "ViewAllBook_ForISBN_OneDay")
            {
                ViewAllBook_ForISBN_OneDay();//4
            }
            if (keyword == "ViewAllBook_ForEachISBN_OneDay") {
                ViewAllBook_ForEachISBN_OneDay();//5
            }
            if (keyword == "ViewAllpBook_ForEachISBN_OneDay")
            {
                ViewAllpBook_ForEachISBN_OneDay();//6
            }
            if (keyword == "ViewAlleBook_BuyFor_OneDay")
            {
                ViewAlleBook_BuyFor_OneDay();//7
            }
            if (keyword == "ViewAlleBook_BorrowFor_OneDay")
            {
                ViewAlleBook_BorrowFor_OneDay();//8
            }
            if (keyword == "ViewAuthor_MostBoughted_Oneday")
            {
                ViewAuthor_MostBoughted_Oneday();//9
            }
            if (keyword == "ViewBill_ForCreditBuy_OneDay")
            {
                ViewBill_ForCreditBuy_OneDay();//12
            }
            if (keyword == "ViewBill_ForIssue_Oneday")
            {
                ViewBill_ForIssue_Oneday();//13
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
