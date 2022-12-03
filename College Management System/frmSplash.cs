using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace College_Management_System
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            ProgressBar1.Width = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            ProgressBar1.Visible = true;

            this.ProgressBar1.Value = this.ProgressBar1.Value + 4;
            if (this.ProgressBar1.Value ==10){
                label3.Text="Reading modules..";
            }
            else if (this.ProgressBar1.Value == 20)
            {
                label3.Text = "Turning on modules.";
            }
            else if (this.ProgressBar1.Value == 40)
            {
                label3.Text = "Starting modules..";
            }
            else if (this.ProgressBar1.Value == 60)
            {
                label3.Text = "Loading modules..";
            }
            else if (this.ProgressBar1.Value == 80)
            {
                label3.Text = "Done Loading modules..";
            }
            else if (this.ProgressBar1.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

