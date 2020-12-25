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
    }
}
