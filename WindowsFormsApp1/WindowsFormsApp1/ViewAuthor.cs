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
    public partial class ViewAuthor : Form
    {
        int cid = -1;
        string genre = "";
        string keyword = "";
        public ViewAuthor(int _cid = -1)
        {
            InitializeComponent();
            cid = _cid;
            load_view();
        }

        public void load_view()
        {
            load_genre();
            load_keyword();
        }

        public void load_genre()
        {
            Console.WriteLine("Test genre Box");
            genreBox.Items.Clear();
            genreBox.Items.Add("null");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT genre FROM book_isbn", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dtr in dt.Rows)
                {
                    genreBox.Items.Add(dtr["genre"].ToString());
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
        }
        public void load_keyword()
        {
            Console.WriteLine("Test keyword Box");
            keywordBox.Items.Clear();
            keywordBox.Items.Add("null");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT keyword FROM book_prop", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dtr in dt.Rows)
                {
                    keywordBox.Items.Add(dtr["keyword"].ToString());
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
        }

        private void btnGetAuthor_Click(object sender, EventArgs e)
        {
            if (genre == "" || keyword == "")
            {
                MessageBox.Show("Please select to get author", "Empty Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                Console.WriteLine(genre + " " + keyword);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.get_author(@genre, @keyword)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@keyword", keyword);

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

        private void genreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            genre = genreBox.Text;
        }

        private void keywordBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyword = keywordBox.Text;
        }
    }
}
