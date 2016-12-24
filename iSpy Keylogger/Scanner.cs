using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Galaxy_Logger.Utility;
using System.Net;


namespace Galaxy_Logger
{
    public class Scanner : IDisposable
    {
        public String[] returned;
        #region " Public properties "

        public string Username { get; set; }
        public string Password { get; set; }

        public bool LoggedIn { get; set; }

        #endregion

        #region " Events "

        public delegate void LoginCompleteEventHandler(bool success);
        public event LoginCompleteEventHandler LoginComplete;

        private void OnLogin(bool success)
        {
            if (LoginComplete != null)
                LoginComplete(success);
        }

        public delegate void ScanCompleteEventHandler(ScanEventArgs args);
        public event ScanCompleteEventHandler ScanComplete;

        private void OnScanComplete(ScanEventArgs args)
        {
            if (ScanComplete != null)
                ScanComplete(args);
        }

        #endregion

        #region " Private properties "

        private Http Http { get; set; }

        #endregion

        #region " Constructor "

        public Scanner(/*string username, string password*/ String filename)
        {
            String[] a = test(filename);
            returned = a;
            //Username = username;
            //Password = password;
            //Http = new Http();
        }
        public String[] getReturned()
        {
            return returned;
        }

        #endregion

        #region " Deconstructor "

        public void Dispose()
        {
            Http.Dispose();
            LoginComplete = null;
            Username = null;
            Password = null;
        }

        #endregion

        #region " Reset "

        private void Reset()
        {
            if (Http != null)
                Http.Dispose();
            Http = new Http();
            LoggedIn = true;
        }

        #endregion

        private bool LoginThreaded { get; set; }
        public void Login()
        {
            if (!LoginThreaded)
            {
                LoginThreaded = true;
                Thread thread = new Thread(Login) { IsBackground = true, Priority = ThreadPriority.BelowNormal };
                thread.Start();
                return;
            }
            LoginThreaded = false;

            Reset();

            Http.TimeOut = 10000;
            Http.DebugMode = true;
            Http.AutoRedirect = true;

            StringBuilder postData = new StringBuilder();
            postData.Append("username=" + Http.UrlEncode(Username));
            postData.Append("&password=" + Http.UrlEncode(Password));
            postData.Append("&send=Login&rememberme=on");

            Http.ContentType = "application/x-www-form-urlencoded";
            Http.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            Http.Referer = "http://scan4you.net/remote.php";

            Http.HttpResponse response = Http.GetResponse(Http.Verb.POST, "http://scan4you.net/remote.php", postData.ToString());
            response = Http.GetResponse(Http.Verb.GET, "http://www.cyber-software.org/scan/index.php?cs=csscanner");

            bool success = response.Html.Contains("Logout");

            OnLogin(success);
            LoggedIn = success;
        }

        public String[] test(String filename)
        {
            var file1 = filename;

            var yourUrl = "http://scan4you.net/remote.php";
            var httpForm = new HttpForm(yourUrl);
            httpForm.AttachFile("file1", file1);
            httpForm.SetValue("id", "34681").SetValue("token", "fe8f7ffa233eb2e6f189");
            HttpWebResponse response = httpForm.Submit();
            return parseResponse(response);

        }

        private String[] parseResponse(HttpWebResponse r)
        {
            String[] asdf = null;
            if (r != null)
            {
                Http.HttpResponse response = new Http.HttpResponse();
                Http a = new Http();
                response = a.GetResponse(r);
                //                response = Http.GetResponse(r);
                ScanEventArgs args = new ScanEventArgs { Detections = new Dictionary<string, string>() };

                args.BBCode = a.ParseBetween(response.Html, "<textarea style=\"width: 100%; height: 200px;\">[u]", "</textarea>",
                                                     "<textarea style=\"width: 100%; height: 200px;\">".Length);

                args.Rate =a.ParseBetween(args.BBCode, "[u][b]Result:[/b][/u] ", "[u][b]", "[u][b]Result:[/b][/u] ".Length).Trim();

                args.Link = a.ParseBetween(args.BBCode, "[url]", "[/url", "[url]".Length);

                string detections = a.ParseBetween(args.BBCode, "[/url]", "[i]", "[/url]".Length).Trim();

                string[] lines = detections.Split('\n');
                foreach (string t in lines)
                {
                    /*
                    string[] x = t.Split(new string[] { "[/b] : [color=" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int s = 0; s < x.Length; s++)
                    {
                        x[s] = x[s].Replace("[b]", "").Replace("green]", "").Replace("red]", "").Replace("[/color]", "");
                    }
                    args.Detections.Add(x[0].Trim(), x[1].Replace("File seems clean", "Clean").Trim());
                     */
                    args.Detections.Add(t, "0");
                }
                //OnScanComplete(args);
             
                asdf = lines;
            }
            return asdf;
        }


        public class HttpForm
        {

            private Dictionary<string, string> _files = new Dictionary<string, string>();
            private Dictionary<string, string> _values = new Dictionary<string, string>();

            public HttpForm(string url)
            {
                this.Url = url;
                this.Method = "POST";
            }

            public string Method { get; set; }
            public string Url { get; set; }

            //return self so that we can chain
            public HttpForm AttachFile(string field, string fileName)
            {
                _files[field] = fileName;
                return this;
            }

            public HttpForm ResetForm()
            {
                _files.Clear();
                _values.Clear();
                return this;
            }

            //return self so that we can chain
            public HttpForm SetValue(string field, string value)
            {
                _values[field] = value;
                return this;
            }

            public HttpWebResponse Submit()
            {
                return this.UploadFiles(_files, _values);
            }


            private HttpWebResponse UploadFiles(Dictionary<string, string> files, Dictionary<string, string> otherValues)
            {
                var req = (HttpWebRequest)WebRequest.Create(this.Url);

                req.Timeout = 10000 * 1000;
                req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                req.AllowAutoRedirect = false;

                var mimeParts = new List<MimePart>();
                try
                {
                    if (otherValues != null)
                    {
                        foreach (var fieldName in otherValues.Keys)
                        {
                            var part = new MimePart();

                            part.Headers["Content-Disposition"] = "form-data; name=\"" + fieldName + "\"";
                            part.Data = new MemoryStream(Encoding.UTF8.GetBytes(otherValues[fieldName]));

                            mimeParts.Add(part);
                        }
                    }

                    if (files != null)
                    {
                        foreach (var fieldName in files.Keys)
                        {
                            var part = new MimePart();

                            part.Headers["Content-Disposition"] = "form-data; name=\"" + fieldName + "\"; filename=\"" + files[fieldName] + "\"";
                            part.Headers["Content-Type"] = "application/octet-stream";
                            part.Data = File.OpenRead(files[fieldName]);

                            mimeParts.Add(part);
                        }
                    }

                    string boundary = "----------" + DateTime.Now.Ticks.ToString("x");

                    req.ContentType = "multipart/form-data; boundary=" + boundary;
                    req.Method = this.Method;

                    long contentLength = 0;

                    byte[] _footer = Encoding.UTF8.GetBytes("--" + boundary + "--\r\n");

                    foreach (MimePart part in mimeParts)
                    {
                        contentLength += part.GenerateHeaderFooterData(boundary);
                    }

                    req.ContentLength = contentLength + _footer.Length;

                    byte[] buffer = new byte[8192];
                    byte[] afterFile = Encoding.UTF8.GetBytes("\r\n");
                    int read;

                    using (Stream s = req.GetRequestStream())
                    {
                        foreach (MimePart part in mimeParts)
                        {
                            s.Write(part.Header, 0, part.Header.Length);

                            while ((read = part.Data.Read(buffer, 0, buffer.Length)) > 0)
                                s.Write(buffer, 0, read);

                            part.Data.Dispose();

                            s.Write(afterFile, 0, afterFile.Length);
                        }

                        s.Write(_footer, 0, _footer.Length);
                    }

                    var res = (HttpWebResponse)req.GetResponse();

                    return res;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    foreach (MimePart part in mimeParts)
                        if (part.Data != null)
                            part.Data.Dispose();

                    return (HttpWebResponse)req.GetResponse();
                }
            }

            private class MimePart
            {
                private NameValueCollection _headers = new NameValueCollection();
                public NameValueCollection Headers { get { return _headers; } }

                public byte[] Header { get; protected set; }

                public long GenerateHeaderFooterData(string boundary)
                {
                    StringBuilder sb = new StringBuilder();

                    sb.Append("--");
                    sb.Append(boundary);
                    sb.AppendLine();
                    foreach (string key in _headers.AllKeys)
                    {
                        sb.Append(key);
                        sb.Append(": ");
                        sb.AppendLine(_headers[key]);
                    }
                    sb.AppendLine();

                    Header = Encoding.UTF8.GetBytes(sb.ToString());

                    return Header.Length + Data.Length + 2;
                }

                public Stream Data { get; set; }
            }
        }


        private bool ScanThreaded { get; set; }
        public void ScanFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new ArgumentException("File doesn't exist", "fileName");
            ScanFile((object)fileName);
        }
        private void ScanFile(object fileName)
        {
            if (!ScanThreaded)
            {
                ScanThreaded = true;
                Thread thread = new Thread(ScanFile) { Priority = ThreadPriority.BelowNormal, IsBackground = true };
                thread.Start(fileName);
                return;
            }
            ScanThreaded = false;

            ScanEventArgs args = new ScanEventArgs { Detections = new Dictionary<string, string>() };

            string path = (string)fileName;

            Http.TimeOut = 600000;
            Http.DebugMode = true;
            Http.AutoRedirect = true;

            FileInfo fileInfo = new FileInfo(path);

            Http.UploadData data = new Http.UploadData(File.ReadAllBytes(path), fileInfo.Name, "file");

            Http.Referer = "http://www.cyber-software.org/scan/index.php?cs=csscanner";

            NameValueCollection fields = new NameValueCollection
            {
                {"send", "Check File"},
                {"url", "http://"},
                {"domen", "http://"},
                {"pack", "http://"}
            };

            Http.HttpResponse response = Http.GetResponse(Http.Verb.POST, "http://www.cyber-software.org/scan/index.php?cs=csscanner", null, fields, data);

            args.BBCode = Http.ParseBetween(response.Html, "<textarea style=\"width: 100%; height: 200px;\">[u]", "</textarea>",
                                                 "<textarea style=\"width: 100%; height: 200px;\">".Length);

            args.Rate = Http.ParseBetween(args.BBCode, "[u][b]Result:[/b][/u] ", "[u][b]", "[u][b]Result:[/b][/u] ".Length).Trim();

            args.Link = Http.ParseBetween(args.BBCode, "[url]", "[/url", "[url]".Length);

            string detections = Http.ParseBetween(args.BBCode, "[/url]", "[i]", "[/url]".Length).Trim();

            string[] lines = detections.Split('\n');
            foreach (string t in lines)
            {
                string[] x = t.Split(new string[] { "[/b] : [color=" }, StringSplitOptions.RemoveEmptyEntries);

                for (int s = 0; s < x.Length; s++)
                {
                    x[s] = x[s].Replace("[b]", "").Replace("green]", "").Replace("red]", "").Replace("[/color]", "");
                }
                args.Detections.Add(x[0].Trim(), x[1].Replace("File seems clean", "Clean").Trim());
            }

            OnScanComplete(args);
        }
    }

    public class ScanEventArgs : EventArgs
    {
        public string Link { get; set; }
        public string Rate { get; set; }
        public string BBCode { get; set; }
        public Dictionary<string, string> Detections { get; set; }
    }
}
