using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualisation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            FormSort formSort = new FormSort();
            formSort.Show();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {

        }

        private void buttonGraph_Click(object sender, EventArgs e)
        {

        }
    }
}
