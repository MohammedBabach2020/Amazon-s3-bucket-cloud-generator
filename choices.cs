using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace THE_BUCKETER
{
    public partial class choices : Form
    {
        public choices()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            usingApi ua = new usingApi();
            ua.Show();
        }
    }
}
