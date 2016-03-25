using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TearcherRoom tr = new TearcherRoom();
            tr.ID = 1;
            tr.TearcharName = "郭老师";
            tr.TearcharAge = 28;
        }
    }
    [Serializable()]
    public class TearcherRoom
    {
        public int ID { set; get; }
        public string TearcharName { get; set; }
        public int TearcharAge { get; set; }
    }
}
