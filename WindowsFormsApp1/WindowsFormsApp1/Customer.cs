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
    public partial class Customer : Form
    {
        public int cid = -1;
        public Customer(int _cid = -1)
        {
            InitializeComponent();
            cid = _cid;
            Console.WriteLine("Ok day la Customer1 co id la: " + cid.ToString());
        }
    }
}
