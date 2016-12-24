using System;
using System.Windows.Forms;

namespace Galaxy_Logger.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void slcClose1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void slCbtn1_Click_1(object sender, EventArgs e)
        {
            new frmKeylogger().Show();
        }

        private void slCbtn3_Click(object sender, EventArgs e)
        {
            new frmToolBox().Show();
        }

        private void slCbtn4_Click(object sender, EventArgs e)
        {
            new frmScanner().Show();
        }


        private void slCbtn6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.educationaltools.info/webpanel/login");
        }

        private void slCbtn2_Click(object sender, EventArgs e)
        {
            LicenseGlobal.Seal.ShowAccount();
        }

        private void slCbtn5_Click(object sender, EventArgs e)
        {
            new frmNews().Show();
        }

        private void slCbtn1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slCbtn1, "Build a Keylogger.");
        }

        private void slCbtn3_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slCbtn3, "Different tools to modify your files.");
        }

        private void slCbtn4_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slCbtn4, "Scan your files!");
        }

        private void slCbtn6_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slCbtn6, "Login to the webpanel.");
        }

        private void slcClose1_Click_1(object sender, EventArgs e)
        {

        }

        private void monoFlat_ControlBox1_Click(object sender, EventArgs e)
        {
            //this.Close();
        }


    }
}
