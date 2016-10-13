using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAutoForm
{
    public partial class AutoCenterForm : Form
    {
        public AutoCenterForm()
        {
            InitializeComponent();
        }

        private void TotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a new or used vehicle." + "\nAuto Centre\nVersion 1.0\n©2016 Mark Chipp\nAll rights reserved.");
        }
    }
}
