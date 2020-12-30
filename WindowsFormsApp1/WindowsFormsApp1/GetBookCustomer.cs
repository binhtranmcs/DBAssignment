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
    public partial class GetBookCustomer : Form
    {
        int cid = -1;
        string genre = "";
        string aname = "";
        string keyword = "";
        DateTime date_published;
        public GetBookCustomer(int _cid = -1)
        {
            InitializeComponent();
            cid = _cid;
            load_view();
        }

        public void load_view()
        {
            load_genre();
            load_author();
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
        public void load_author()
        {
            Console.WriteLine("Test author Box");
            nameAuthorBox.Items.Clear();
            nameAuthorBox.Items.Add("null");
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DISTINCT aname FROM author", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dtr in dt.Rows)
                {
                    nameAuthorBox.Items.Add(dtr["aname"].ToString());
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
        private void genreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            genre = genreBox.Text;
            //MessageBox.Show("Genre Book: " + genre);
        }

        private void nameAuthorBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            aname = nameAuthorBox.Text;
            //MessageBox.Show("Name author: " + aname);
        }

        private void keywordBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            keyword = keywordBox.Text;
            //MessageBox.Show("Keyword: " + keyword);
        }

        private void btnGetBook_Click(object sender, EventArgs e)
        {
            date_published = dateTimePicker1.Value;
            if (genre == "" || keyword == "" || aname == "")
            {
                MessageBox.Show("Please select to get book", "Empty Select", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                Console.WriteLine(genre + " " + keyword + " " + aname);
                Console.WriteLine(date_published);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.get_book(@genre, @aname, @keyword, @date_published)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@aname", aname);
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@keyword", keyword);
                cmd.Parameters.AddWithValue("@date_published", date_published);

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

        private void btnBuyBook_Click(object sender, EventArgs e)
        {
            DateTime date_now = dateTimePicker1.Value;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                Console.WriteLine("Id Customer La: " + cid.ToString());
                Console.WriteLine(date_published);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.list_buy_month(@cid, @date_now)", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cid", cid.ToString());
                cmd.Parameters.AddWithValue("@date_now", date_now);

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

        public int createBill(int numBook, int totalPrice)
        {
            int bbid = -1;
            DateTime date_now = DateTime.Now;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into bill values(@quantity, @payment, @issue, @price, @purchase_date)", con);
                cmd.Parameters.AddWithValue("@quantity", numBook.ToString());
                cmd.Parameters.AddWithValue("@payment", "bank");
                cmd.Parameters.AddWithValue("@issue", DBNull.Value);
                cmd.Parameters.AddWithValue("@price", totalPrice.ToString());
                cmd.Parameters.AddWithValue("@purchase_date", date_now);
                Console.WriteLine("add bill: " + cmd.ExecuteNonQuery().ToString());
                MessageBox.Show("Your Bill Has Been Created", "Bill Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cmd = new SqlCommand("SELECT MAX(bbid) FROM bill", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                bbid = Convert.ToInt32(dt.Rows[0][0]);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return bbid;
        }

        public void createPBuy(int bid, int cid, int bbid)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into pbuy values(@bid, @cid, @bbid)", con);
                cmd.Parameters.AddWithValue("@bid", bid.ToString());
                cmd.Parameters.AddWithValue("@cid", cid.ToString());
                cmd.Parameters.AddWithValue("@bbid", bbid.ToString());
                Console.WriteLine("add pBuy: " + cmd.ExecuteNonQuery().ToString());
                //MessageBox.Show("Your pBuy Has Been Created", "Bill Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public void createEBuy(int bid, int cid, int bbid, string link = "thanh.com")
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into ebuy values(@bid, @cid, @bbid, @link)", con);
                cmd.Parameters.AddWithValue("@bid", bid.ToString());
                cmd.Parameters.AddWithValue("@cid", cid.ToString());
                cmd.Parameters.AddWithValue("@bbid", bbid.ToString());
                cmd.Parameters.AddWithValue("@link", link);
                Console.WriteLine("add EBuy: " + cmd.ExecuteNonQuery().ToString());
                // MessageBox.Show("Your EBuy Has Been Created", "Bill Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        public int getBidIsbn(string isbn) ///(bid, book_type)
        {
            int bid = -1;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * from dbo.get_book_by_isbn(@isbn)", con);
                cmd.Parameters.AddWithValue("@isbn", isbn);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                Console.WriteLine("number of book: " + dt.Rows.Count.ToString());
                if (dt.Rows.Count > 0)
                {
                    bid = Convert.ToInt32(dt.Rows[0]["bid"].ToString());
                }
                else
                {
                    //MessageBox.Show("Khong ton tai sach");
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
            return bid;
        }
        public int getBookTypeIsbn(string isbn) ///(bid, book_type)
        {
            int book_type = -1;
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.book_type(@isbn)", con);

                cmd.Parameters.Add(new SqlParameter("@isbn", isbn));

                book_type = Convert.ToInt32(cmd.ExecuteScalar());
                //MessageBox.Show("Lay book_type thanh cong");
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            finally
            {
                con.Close();
            }
            return book_type;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            List<string> list_isbn = new List<string>();
            List<string> list_genre = new List<string>();
            List<string> list_title = new List<string>();
            List<int> list_price = new List<int>();
            int totalPrice = 0;
            int numBook = 0;
            foreach (DataGridViewRow r in dataGridView1.SelectedRows)
            {
                string isbn = r.Cells[0].Value.ToString();
                string genre = r.Cells[1].Value.ToString();
                string title = r.Cells[2].Value.ToString();
                int price = Convert.ToInt32(r.Cells[3].Value.ToString());
                list_isbn.Add(isbn);
                list_genre.Add(genre);
                list_title.Add(title);
                list_price.Add(price);
                numBook++;
                totalPrice += price;
            }
            int bbid = createBill(numBook, totalPrice);
            Console.WriteLine(bbid);
            foreach (string isbn in list_isbn)
            {
                int book_type = getBookTypeIsbn(isbn);
                if (book_type <= 0)
                {
                    Console.WriteLine("Khong lay duoc book_type");
                    continue;
                }
                Console.WriteLine("isbn: " + isbn);
                int bid = getBidIsbn(isbn);
                Console.WriteLine("bid: " + bid.ToString());
                if (book_type == 1) Console.WriteLine("book_type is PBuy");
                else
                {
                    if (book_type == 2) Console.WriteLine("book_type is EBuy");
                    else
                    {
                        Console.WriteLine("Stupid Code");
                    }
                }
                if (book_type == 1)
                {
                    createPBuy(bid, cid, bbid);
                }
                else
                {
                    createEBuy(bid, cid, bbid);
                }
            }
            MessageBox.Show("Create Bill Thanh Cong", "Bill Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
