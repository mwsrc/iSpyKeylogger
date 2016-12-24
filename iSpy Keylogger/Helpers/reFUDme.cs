using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;

namespace Galaxy_Logger.Helpers
    {
    class reFUDme
    {
        private string token;
        public event ScanStateEventHandler ScanState;
        public delegate void ScanStateEventHandler(string status);

        public reFUDme(string token)
        {
            this.token = token;
        }
        public int detectionCount { get { return Results.Count(r => r.Value != "OK"); } }
        public string link { get; set; }
        public Dictionary<string, string> Results { get; set; }

        public void scan(string filename)
        {
            WebClient wc = new WebClient { Proxy = null };
            bool scanned = false;
            wc.UploadFileCompleted += delegate (object sender, UploadFileCompletedEventArgs args) {
                string response = Encoding.UTF8.GetString(args.Result);
                Dictionary<string, string> dict = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(response);
                string url = dict["url"];
                dict.Remove("url");
                dict.Remove("result");
                link = url;
                Results = dict;
                ScanState("Scan complete.");
                scanned = true;

            };

            if (ScanState != null)
            {
                ScanState("Starting upload...");

                ScanState(string.Format("Attempting to scan file '{0}'.", new FileInfo(filename).Name));
            }

            wc.UploadFileAsync(new Uri("http://www.refud.me/api.php?auth_token=" + token + "&type=text"), "POST", filename);
            while (!scanned)
                Thread.Sleep(300);

        }
    }
}
