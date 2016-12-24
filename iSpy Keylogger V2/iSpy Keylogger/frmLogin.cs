using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using Networking;
namespace iSpy_Keylogger
{
    public partial class frmLogin : Form
    {
        private static string settingsFolder = Application.StartupPath + "\\Settings";
        private string loginData = settingsFolder + "\\Login Data";
        private string autoLogin = settingsFolder + "\\Auto Login";
        public frmLogin()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            GlobalVariables.LoginForm = this;
            ThreadPool.QueueUserWorkItem(GlobalVariables.Listen);
            if (!File.Exists(settingsFolder))
                Directory.CreateDirectory(settingsFolder);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            GlobalVariables.HWID = Networking.HWID.GetValue();
            tbHWID.Text = GlobalVariables.HWID;
            if (File.Exists(loginData))
            {
                cbRememberMe.Checked = true;
                string data = File.ReadAllText(loginData);
                data = GlobalVariables.cryptor.Decrypt(data, GlobalVariables.HWID);
                tbUsername.txtbox.Text = data.Split('\n')[0].Trim();
                tbPassword.txtbox.Text = data.Split('\n')[1].Trim();
                if (File.Exists(autoLogin))
                {
                    cbAutoLogin.Checked = true;
                    DoLogin();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.txtbox.Text) || string.IsNullOrEmpty(tbPassword.txtbox.Text))
            {
                MessageBox.Show("Fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DoLogin();
            }
            
        }

        private void DoLogin()
        {
            
            if (!cbRememberMe.Checked)
            {
                File.Delete(loginData);
            }
            if (!cbAutoLogin.Checked)
            {
                File.Delete(autoLogin);
            }
            if (cbRememberMe.Checked && !File.Exists(loginData))
            {
                string data = tbUsername.txtbox.Text + Environment.NewLine + tbPassword.txtbox.Text;
                File.WriteAllText(loginData, GlobalVariables.cryptor.Encrypt(data, GlobalVariables.HWID));
            }
            if (cbAutoLogin.Checked && !File.Exists(autoLogin))
            {
                File.WriteAllText(autoLogin, string.Empty);
            }

            using (PayloadWriter pw = new PayloadWriter())
            {
                tbUsername.Enabled = false;
                tbPassword.Enabled = false;
                btnLogin.Enabled = false;
                pw.WriteByte(0x02);
                pw.WriteString(tbUsername.txtbox.Text);
                pw.WriteString(tbPassword.txtbox.Text);
                pw.WriteString(GlobalVariables.HWID);
                pw.WriteString(GlobalVariables.version);
                GlobalVariables.Username = tbUsername.txtbox.Text;
                GlobalVariables.SendData(pw.ToByteArray());
            }
             
        }
    }
}
