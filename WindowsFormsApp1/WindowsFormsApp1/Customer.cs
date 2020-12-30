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

        private void btnGetAuthor_Click(object sender, EventArgs e)
        {
            var fm = new ViewAuthor(cid);
            fm.ShowDialog();
        }

        private void btnTransaction_Click(object sender, EventArgs e)
        {
            var fm = new Transaction(cid);
            fm.ShowDialog();
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
        private void btnBuyBook_Click(object sender, EventArgs e)
        {
            List<string> list_isbn = new List<string>();
            List<string> list_genre = new List<string>();
            List<string> list_title = new List<string>();
            List<int> list_price = new List<int>();
            int totalPrice = 0;
            int numBook = 0;
            foreach (DataGridViewRow r in bookView.SelectedRows)
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
