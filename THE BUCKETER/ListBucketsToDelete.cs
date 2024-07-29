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
    public partial class ListBucketsToDelete : Form
    {
        public ListBucketsToDelete()
        {
            InitializeComponent();
        }

        private void ListBucketsToDelete_Load(object sender, EventArgs e)
        {
            label1.Text = ListView.Rows.Count.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usingApi.allowDelete = false;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usingApi.allowDelete = true;
            this.Close();
        }
    }
}
