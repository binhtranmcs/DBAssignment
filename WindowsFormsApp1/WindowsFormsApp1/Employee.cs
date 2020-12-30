using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Employee : Form
    {
        public int eid = -1;
        public Employee(int _eid = -1)
        {
            InitializeComponent();
            eid = _eid;
            Console.WriteLine("Ok day la Employee co id la: " + eid.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fm = new insert();
            fm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fm = new updatebookEmployee();
            fm.ShowDialog();
        }

        private void Employee_Load(object sender, EventArgs e)
        {

        }

        private void info_Click(object sender, EventArgs e)
        {
            var fm = new infoEmployee(1);
            fm.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var fm = new insertchinh();
            fm.ShowDialog();
        }
    }
}
