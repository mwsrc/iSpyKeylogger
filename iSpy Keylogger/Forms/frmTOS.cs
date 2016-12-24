using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Galaxy_Logger.Forms
{
    public partial class frmTOS : Form
    {

        public frmTOS()
        {
            LicenseGlobal.Seal.RunHook = run;
            LicenseGlobal.Seal.Initialize("8C5A0000");
            //run();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;
        }
        private void run()
        {
            this.AcceptButton = (IButtonControl)slCbtn1;
            this.CancelButton = (IButtonControl)slCbtn2;
            InitializeComponent();
        }
        private void fb_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void slCbtn1_Click_1(object sender, EventArgs e)
        {
            new frmMain().Show();
            //new frmKeylogger().Show();
            this.Visible = false;
        }

        private void slCbtn2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
