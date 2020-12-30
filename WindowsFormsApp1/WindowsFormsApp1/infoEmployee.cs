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
    public partial class infoEmployee : Form
    {
        public int eid = -1;
        public infoEmployee(int _eid = -1)
        {
            InitializeComponent();
            eid = _eid;
            Console.WriteLine("Ok day la Employee co id la: " + eid.ToString());
            load_view();
        }

        //
        void load_view()
        {
            string ename = "";
            string eemail = "";
            string eaddress = "";
        
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM employee WHERE eid='" + eid.ToString() + "'", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Console.WriteLine("Number account InfoEmployee: " + dt.Rows.Count.ToString());
                    if (dt.Rows.Count > 1)
                    {
                        MessageBox.Show("Oups, co gi do sai sai o Info Customer");
                        con.Close();
                        return;
                    }
                    ename = dt.Rows[0]["ename"].ToString();
                    eemail = dt.Rows[0]["eemail"].ToString();
                    eaddress = dt.Rows[0]["eaddress"].ToString();
                }
                else
                {
                    MessageBox.Show("Wrong Username and Password Infor Employee, Please try again", "Wrong account", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            textBox1.Text = ename;
            textBox2.Text = eaddress;
            textBox3.Text = eemail;
        }
        //

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void infoEmployee_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(eid.ToString());
            string ename = textBox1.Text;
            string eaddress = textBox2.Text;
            string eemail = textBox3.Text;
            if (ename == "" || eemail == "" || eaddress == "")
            {
                MessageBox.Show("Enter Your Information to Update", "Empty Blank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Bookstore;Integrated Security=True");
            try
            {
                Console.WriteLine(ename + " " + eemail + " " + eaddress);
                con.Open();
                SqlCommand cmd = new SqlCommand("updateInfo_Employee", con);

                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.Add(new SqlParameter("@eid", eid));
                cmd.Parameters.Add(new SqlParameter("@ename", ename));
                cmd.Parameters.Add(new SqlParameter("@eemail", eemail));
                cmd.Parameters.Add(new SqlParameter("@eaddress", eaddress));

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
