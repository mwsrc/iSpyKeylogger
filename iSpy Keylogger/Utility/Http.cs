using System;
using System.IO;
using System.Net;
using System.Web;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Diagnostics;
using System.IO.Compression;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Galaxy_Logger.Utility
{

    /// <warning>DO NOT REMOVE ANY OF THIS INFORMATION.</warning>
    /// <summary>Wrapper for HttpWebRequest/HttpWebResponse to make life easier :D</summary>
    /// <author>idb</author>
    /// <author_url>http://s.olution.cc/</author_url>
    /// <credits>
    /// stimms - http://stackoverflow.com/users/361/stimms
    /// </credits>
    /// <remarks>
    /// Although this class is open source I DO NOT grant anyone permission to use it in projects for monetary gain.
    /// This class is to only be used for educational purposes in open source/freeware projects and if the author (me) is given credit. 
    /// Please don't take advantage of my willingness to share code and steal money out of my pocket.
    /// </remarks>
    /// <thieves>
    /// This section is reserved for keeping track of people who have gone against my wishes and are making money off this class without my permission.
    /// GeoCoreTV aka TKzGhostRider aka TKzTechnology (Skype: anders18881) - http://goo.gl/E191G
    /// </thieves>
    /// <last_update>Tuesday, July 3, 2012</last_update>
    /// <update_history>
    /// Friday, January 13, 2012
    ///          Added another GetUploadResponse method that allows you to pass PostData as Byte().
    /// Saturday, January 14, 2012
    ///         Handled "The underlying connection was closed:" exceptions in ProcessException function.
    ///         Included Request (HttpWebRequest) object into HttpResponse class.
    /// Wednesday, February 22, 2012
    ///          Accept, Accept-Language, Accept-Encoding will no longer be sent if the property is empty.
    /// Tuesday, February 28, 2012
    ///          Removed some unnecessary DirectCast's in the GetResponse and GetUploadResponse methods.
    /// Wednesday, March 21, 2012
    ///          Handled GMT dates on cookie expiration parsing
    ///          Added RequestUri/ResponseUri and RequestHeaders/ResponseHeaders to HttpResponse class
    /// Sunday, March 25, 2012
    ///          Added IsValidUri function
    /// Tuesday, March 27, 2012
    ///          Fixed an error in the ParseCookies function
    ///          Got rid of unnecessary FindCookie functions
    /// Wednesday, April 4, 2012
    ///          Updated ParseCookies, GetCookies, and FindCookie functions
    /// Tuesday, May 22, 2012
    ///          Updated/Consolidated GetResponse and GetUploadResponse methods. 
    ///          Removed CancelRequest method.
    ///          Removed ForceHttps property. 
    /// Thursday, May 24, 2012
    ///          Updated GetRedirectUrl function.
    ///          Replaced GetContentType function with GetMIMEType.
    /// Friday, June 1, 2012
    ///          Added Method parameter to GetResponse methods (now supports PUT as well as GET/POST).
    ///          Added TimeStampLong function for getting epoch millisecond timestamps.
    ///          Fixed problem in auto-redirection caused by new Method parameter in GetResponse methods.
    /// Monday, June 4, 2012
    ///          Added Properties UseCustomCookies and CustomCookies (used for sending specific cookies on a per request basis without disturbing the session cookies).
    ///          Added ImageToBase64/Base64ToString functions.
    /// Friday, June 15, 2012
    ///          Added SendChunked property.
    /// Friday, June 23, 2012
    ///          Fixed bug in GetResponse (Multi-Part) method that caused data to be posted incorrectly
    /// Saturday, June 30, 2012
    ///          Fixed problem with headers in SendRequest method
    ///          Added CookieBlacklist.
    /// Tuesday, July 3, 2012
    ///          Fixed problem with cookie domain value
    ///          Handled another auto-redirection method
    /// </update_history>

    public class Http : IDisposable
    {

        public List<string> RedirectBlacklist = new List<string>();

        public List<string> CookieBlacklist = new List<string>();

        private List<HttpCookie> SessionCookies;
        #region "Declarations"
        [DllImport("urlmon.dll", CharSet = CharSet.Auto)]
        private static extern System.UInt32 FindMimeFromData(System.UInt32 pBC, [MarshalAs(UnmanagedType.LPStr)]
System.String pwzUrl, [MarshalAs(UnmanagedType.LPArray)]
byte[] pBuffer, System.UInt32 cbSize, [MarshalAs(UnmanagedType.LPStr)]
System.String pwzMimeProposed, System.UInt32 dwMimeFlags, ref System.UInt32 ppwzMimeOut, System.UInt32 dwReserverd);
        #endregion

        #region "Dictionaries"
        private readonly string[] Verbs = new string[] {
		"GET",
		"POST",
		"PUT"
	};
        private readonly Dictionary<string, string> MIMETypes = new Dictionary<string, string> {
		{
			"ai",
			"application/postscript"
		},
		{
			"aif",
			"audio/x-aiff"
		},
		{
			"aifc",
			"audio/x-aiff"
		},
		{
			"aiff",
			"audio/x-aiff"
		},
		{
			"asc",
			"text/plain"
		},
		{
			"atom",
			"application/atom+xml"
		},
		{
			"au",
			"audio/basic"
		},
		{
			"avi",
			"video/x-msvideo"
		},
		{
			"bcpio",
			"application/x-bcpio"
		},
		{
			"bin",
			"application/octet-stream"
		},
		{
			"bmp",
			"image/bmp"
		},
		{
			"cdf",
			"application/x-netcdf"
		},
		{
			"cgm",
			"image/cgm"
		},
		{
			"class",
			"application/octet-stream"
		},
		{
			"cpio",
			"application/x-cpio"
		},
		{
			"cpt",
			"application/mac-compactpro"
		},
		{
			"csh",
			"application/x-csh"
		},
		{
			"css",
			"text/css"
		},
		{
			"dcr",
			"application/x-director"
		},
		{
			"dif",
			"video/x-dv"
		},
		{
			"dir",
			"application/x-director"
		},
		{
			"djv",
			"image/vnd.djvu"
		},
		{
			"djvu",
			"image/vnd.djvu"
		},
		{
			"dll",
			"application/octet-stream"
		},
		{
			"dmg",
			"application/octet-stream"
		},
		{
			"dms",
			"application/octet-stream"
		},
		{
			"doc",
			"application/msword"
		},
		{
			"docx",
			"application/vnd.openxmlformats-officedocument.wordprocessingml.document"
		},
		{
			"dotx",
			"application/vnd.openxmlformats-officedocument.wordprocessingml.template"
		},
		{
			"docm",
			"application/vnd.ms-word.document.macroEnabled.12"
		},
		{
			"dotm",
			"application/vnd.ms-word.template.macroEnabled.12"
		},
		{
			"dtd",
			"application/xml-dtd"
		},
		{
			"dv",
			"video/x-dv"
		},
		{
			"dvi",
			"application/x-dvi"
		},
		{
			"dxr",
			"application/x-director"
		},
		{
			"eps",
			"application/postscript"
		},
		{
			"etx",
			"text/x-setext"
		},
		{
			"exe",
			"application/octet-stream"
		},
		{
			"ez",
			"application/andrew-inset"
		},
		{
			"gif",
			"image/gif"
		},
		{
			"gram",
			"application/srgs"
		},
		{
			"grxml",
			"application/srgs+xml"
		},
		{
			"gtar",
			"application/x-gtar"
		},
		{
			"hdf",
			"application/x-hdf"
		},
		{
			"hqx",
			"application/mac-binhex40"
		},
		{
			"htm",
			"text/html"
		},
		{
			"html",
			"text/html"
		},
		{
			"ice",
			"x-conference/x-cooltalk"
		},
		{
			"ico",
			"image/x-icon"
		},
		{
			"ics",
			"text/calendar"
		},
		{
			"ief",
			"image/ief"
		},
		{
			"ifb",
			"text/calendar"
		},
		{
			"iges",
			"model/iges"
		},
		{
			"igs",
			"model/iges"
		},
		{
			"jnlp",
			"application/x-java-jnlp-file"
		},
		{
			"jp2",
			"image/jp2"
		},
		{
			"jpe",
			"image/jpeg"
		},
		{
			"jpeg",
			"image/jpeg"
		},
		{
			"jpg",
			"image/jpeg"
		},
		{
			"js",
			"application/x-javascript"
		},
		{
			"kar",
			"audio/midi"
		},
		{
			"latex",
			"application/x-latex"
		},
		{
			"lha",
			"application/octet-stream"
		},
		{
			"lzh",
			"application/octet-stream"
		},
		{
			"m3u",
			"audio/x-mpegurl"
		},
		{
			"m4a",
			"audio/mp4a-latm"
		},
		{
			"m4b",
			"audio/mp4a-latm"
		},
		{
			"m4p",
			"audio/mp4a-latm"
		},
		{
			"m4u",
			"video/vnd.mpegurl"
		},
		{
			"m4v",
			"video/x-m4v"
		},
		{
			"mac",
			"image/x-macpaint"
		},
		{
			"man",
			"application/x-troff-man"
		},
		{
			"mathml",
			"application/mathml+xml"
		},
		{
			"me",
			"application/x-troff-me"
		},
		{
			"mesh",
			"model/mesh"
		},
		{
			"mid",
			"audio/midi"
		},
		{
			"midi",
			"audio/midi"
		},
		{
			"mif",
			"application/vnd.mif"
		},
		{
			"mov",
			"video/quicktime"
		},
		{
			"movie",
			"video/x-sgi-movie"
		},
		{
			"mp2",
			"audio/mpeg"
		},
		{
			"mp3",
			"audio/mpeg"
		},
		{
			"mp4",
			"video/mp4"
		},
		{
			"mpe",
			"video/mpeg"
		},
		{
			"mpeg",
			"video/mpeg"
		},
		{
			"mpg",
			"video/mpeg"
		},
		{
			"mpga",
			"audio/mpeg"
		},
		{
			"ms",
			"application/x-troff-ms"
		},
		{
			"msh",
			"model/mesh"
		},
		{
			"mxu",
			"video/vnd.mpegurl"
		},
		{
			"nc",
			"application/x-netcdf"
		},
		{
			"oda",
			"application/oda"
		},
		{
			"ogg",
			"application/ogg"
		},
		{
			"pbm",
			"image/x-portable-bitmap"
		},
		{
			"pct",
			"image/pict"
		},
		{
			"pdb",
			"chemical/x-pdb"
		},
		{
			"pdf",
			"application/pdf"
		},
		{
			"pgm",
			"image/x-portable-graymap"
		},
		{
			"pgn",
			"application/x-chess-pgn"
		},
		{
			"pic",
			"image/pict"
		},
		{
			"pict",
			"image/pict"
		},
		{
			"png",
			"image/png"
		},
		{
			"pnm",
			"image/x-portable-anymap"
		},
		{
			"pnt",
			"image/x-macpaint"
		},
		{
			"pntg",
			"image/x-macpaint"
		},
		{
			"ppm",
			"image/x-portable-pixmap"
		},
		{
			"ppt",
			"application/vnd.ms-powerpoint"
		},
		{
			"pptx",
			"application/vnd.openxmlformats-officedocument.presentationml.presentation"
		},
		{
			"potx",
			"application/vnd.openxmlformats-officedocument.presentationml.template"
		},
		{
			"ppsx",
			"application/vnd.openxmlformats-officedocument.presentationml.slideshow"
		},
		{
			"ppam",
			"application/vnd.ms-powerpoint.addin.macroEnabled.12"
		},
		{
			"pptm",
			"application/vnd.ms-powerpoint.presentation.macroEnabled.12"
		},
		{
			"potm",
			"application/vnd.ms-powerpoint.template.macroEnabled.12"
		},
		{
			"ppsm",
			"application/vnd.ms-powerpoint.slideshow.macroEnabled.12"
		},
		{
			"ps",
			"application/postscript"
		},
		{
			"qt",
			"video/quicktime"
		},
		{
			"qti",
			"image/x-quicktime"
		},
		{
			"qtif",
			"image/x-quicktime"
		},
		{
			"ra",
			"audio/x-pn-realaudio"
		},
		{
			"ram",
			"audio/x-pn-realaudio"
		},
		{
			"ras",
			"image/x-cmu-raster"
		},
		{
			"rdf",
			"application/rdf+xml"
		},
		{
			"rgb",
			"image/x-rgb"
		},
		{
			"rm",
			"application/vnd.rn-realmedia"
		},
		{
			"roff",
			"application/x-troff"
		},
		{
			"rtf",
			"text/rtf"
		},
		{
			"rtx",
			"text/richtext"
		},
		{
			"sgm",
			"text/sgml"
		},
		{
			"sgml",
			"text/sgml"
		},
		{
			"sh",
			"application/x-sh"
		},
		{
			"shar",
			"application/x-shar"
		},
		{
			"silo",
			"model/mesh"
		},
		{
			"sit",
			"application/x-stuffit"
		},
		{
			"skd",
			"application/x-koan"
		},
		{
			"skm",
			"application/x-koan"
		},
		{
			"skp",
			"application/x-koan"
		},
		{
			"skt",
			"application/x-koan"
		},
		{
			"smi",
			"application/smil"
		},
		{
			"smil",
			"application/smil"
		},
		{
			"snd",
			"audio/basic"
		},
		{
			"so",
			"application/octet-stream"
		},
		{
			"spl",
			"application/x-futuresplash"
		},
		{
			"src",
			"application/x-wais-source"
		},
		{
			"sv4cpio",
			"application/x-sv4cpio"
		},
		{
			"sv4crc",
			"application/x-sv4crc"
		},
		{
			"svg",
			"image/svg+xml"
		},
		{
			"swf",
			"application/x-shockwave-flash"
		},
		{
			"t",
			"application/x-troff"
		},
		{
			"tar",
			"application/x-tar"
		},
		{
			"tcl",
			"application/x-tcl"
		},
		{
			"tex",
			"application/x-tex"
		},
		{
			"texi",
			"application/x-texinfo"
		},
		{
			"texinfo",
			"application/x-texinfo"
		},
		{
			"tif",
			"image/tiff"
		},
		{
			"tiff",
			"image/tiff"
		},
		{
			"tr",
			"application/x-troff"
		},
		{
			"tsv",
			"text/tab-separated-values"
		},
		{
			"txt",
			"text/plain"
		},
		{
			"ustar",
			"application/x-ustar"
		},
		{
			"vcd",
			"application/x-cdlink"
		},
		{
			"vrml",
			"model/vrml"
		},
		{
			"vxml",
			"application/voicexml+xml"
		},
		{
			"wav",
			"audio/x-wav"
		},
		{
			"wbmp",
			"image/vnd.wap.wbmp"
		},
		{
			"wbmxl",
			"application/vnd.wap.wbxml"
		},
		{
			"wml",
			"text/vnd.wap.wml"
		},
		{
			"wmlc",
			"application/vnd.wap.wmlc"
		},
		{
			"wmls",
			"text/vnd.wap.wmlscript"
		},
		{
			"wmlsc",
			"application/vnd.wap.wmlscriptc"
		},
		{
			"wrl",
			"model/vrml"
		},
		{
			"xbm",
			"image/x-xbitmap"
		},
		{
			"xht",
			"application/xhtml+xml"
		},
		{
			"xhtml",
			"application/xhtml+xml"
		},
		{
			"xls",
			"application/vnd.ms-excel"
		},
		{
			"xml",
			"application/xml"
		},
		{
			"xpm",
			"image/x-xpixmap"
		},
		{
			"xsl",
			"application/xml"
		},
		{
			"xlsx",
			"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
		},
		{
			"xltx",
			"application/vnd.openxmlformats-officedocument.spreadsheetml.template"
		},
		{
			"xlsm",
			"application/vnd.ms-excel.sheet.macroEnabled.12"
		},
		{
			"xltm",
			"application/vnd.ms-excel.template.macroEnabled.12"
		},
		{
			"xlam",
			"application/vnd.ms-excel.addin.macroEnabled.12"
		},
		{
			"xlsb",
			"application/vnd.ms-excel.sheet.binary.macroEnabled.12"
		},
		{
			"xslt",
			"application/xslt+xml"
		},
		{
			"xul",
			"application/vnd.mozilla.xul+xml"
		},
		{
			"xwd",
			"image/x-xwindowdump"
		},
		{
			"xyz",
			"chemical/x-xyz"
		},
		{
			"zip",
			"application/zip"
		}

	};
        #endregion

        #region "Enumerators"
        public enum MimicBrowser
        {
            Firefox = 0,
            InternetExplorer = 1,
            Chrome = 2,
            Custom = 3
        }
        public enum Verb
        {
            GET = 0,
            POST = 1,
            PUT = 2
        }
        #endregion

        #region "Structures"
        public struct HttpProxy
        {
            public string Server;
            public int Port;
            public string UserName;

            public string Password;
            public HttpProxy(string pServer, int pPort, string pUserName = "", string pPassword = "")
            {
                Server = pServer;
                Port = pPort;
                UserName = pUserName;
                Password = pPassword;
            }
        }
        public struct UploadData
        {
            public byte[] Contents;
            public string FileName;
            public string FieldName;
            public UploadData(byte[] uContents, string uFileName, string uFieldName)
            {
                Contents = uContents;
                FileName = uFileName;
                FieldName = uFieldName;
            }
        }
        #endregion

        #region "Properties"
        private int _TimeOut = 7000;
        public int TimeOut
        {
            get { return _TimeOut; }
            set { _TimeOut = value; }
        }

        private int _Progress = 0;
        public int Progress
        {
            get { return _Progress; }
            set { _Progress = value; }
        }

        private HttpProxy _Proxy = new HttpProxy();
        public HttpProxy Proxy
        {
            get { return _Proxy; }
            set { _Proxy = value; }
        }

        private string _UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:13.0) Gecko/20100101 Firefox/13.0.1";
        public string Useragent
        {
            get { return _UserAgent; }
            set { _UserAgent = value; }
        }

        private string _Referer = string.Empty;
        public string Referer
        {
            get { return _Referer; }
            set { _Referer = value; }
        }

        private bool _AutoRedirect = true;
        public bool AutoRedirect
        {
            get { return _AutoRedirect; }
            set { _AutoRedirect = value; }
        }

        private bool _StoreCookies = true;
        public bool StoreCookies
        {
            get { return _StoreCookies; }
            set { _StoreCookies = value; }
        }

        private bool _SendCookies = true;
        public bool SendCookies
        {
            get { return _SendCookies; }
            set { _SendCookies = value; }
        }

        private string _LastRequestUri = string.Empty;
        public string LastRequestUri
        {
            get { return _LastRequestUri; }
            set { _LastRequestUri = value; }
        }

        private string _LastResponseUri = string.Empty;
        public string LastResponseUri
        {
            get { return _LastResponseUri; }
            set { _LastResponseUri = value; }
        }

        private bool _KeepAlive = true;
        public bool KeepAlive
        {
            get { return _KeepAlive; }
            set { _KeepAlive = value; }
        }

        private System.Version _Version = HttpVersion.Version11;
        public System.Version Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        private string _Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        public string Accept
        {
            get { return _Accept; }
            set { _Accept = value; }
        }

        private bool _AllowExpect100 = false;
        public bool AllowExpect100
        {
            get { return _AllowExpect100; }
            set { _AllowExpect100 = value; }
        }

        private string _ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
        public string ContentType
        {
            get { return _ContentType; }
            set { _ContentType = value; }
        }

        private bool _DebugMode = true;
        public bool DebugMode
        {
            get { return _DebugMode; }
            set { _DebugMode = value; }
        }

        private string _AcceptEncoding = "gzip, deflate";
        public string AcceptEncoding
        {
            get { return _AcceptEncoding; }
            set { _AcceptEncoding = value; }
        }

        private string _AcceptLanguage = "en-us,en;q=0.5";
        public string AcceptLanguage
        {
            get { return _AcceptLanguage; }
            set { _AcceptLanguage = value; }
        }

        private string _AcceptCharset = "ISO-8859-1,utf-8;q=0.7,*;q=0.7";
        public string AcceptCharset
        {
            get { return _AcceptCharset; }
            set { _AcceptCharset = value; }
        }

        private bool _AllowWriteStreamBuffering = false;
        public bool AllowWriteStreamBuffering
        {
            get { return _AllowWriteStreamBuffering; }
            set { _AllowWriteStreamBuffering = value; }
        }

        private bool _UseCustomCookies = false;
        public bool UseCustomCookies
        {
            get { return _UseCustomCookies; }
            set { _UseCustomCookies = value; }
        }

        private HttpCookie[] _CustomCookies = null;
        public HttpCookie[] CustomCookies
        {
            get { return _CustomCookies; }
            set { _CustomCookies = value; }
        }

        private bool _SendChunked = false;
        public bool SendChunked
        {
            get { return _SendChunked; }
            set { _SendChunked = value; }
        }
        #endregion

        #region "Constructor"
        public Http()
        {
            SetUnsafeHeaderParsing(true);

            ServicePointManager.DefaultConnectionLimit = 500;
            ServicePointManager.Expect100Continue = this.AllowExpect100;
            ServicePointManager.ServerCertificateValidationCallback = AcceptAllCertifications;
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;

            SessionCookies = new List<HttpCookie>();
        }
        #endregion

        #region "Deconstructor"
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    RedirectBlacklist.Clear();
                    SessionCookies.Clear();
                }
            }
            this.disposedValue = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region "Public Methods"
        public HttpResponse GetResponse(Verb Method, string Uri, string PostData, NameValueCollection ExtraHeaders = null)
        {
            byte[] Data = null;
            if (!string.IsNullOrEmpty(PostData))
                Data = Encoding.Default.GetBytes(PostData);
            HttpResponse Result = GetResponse(Method, Uri, Data, ExtraHeaders);
            return Result;
        }
        public HttpResponse GetResponse(Verb Method, string Uri, byte[] PostData = null, NameValueCollection ExtraHeaders = null)
        {
            HttpResponse hr = new HttpResponse();
            Exception e = null;

            HttpWebResponse Response = null;
        request:

            try
            {
                if (!Uri.StartsWith("http"))
                    Uri = "http://" + Uri;
                if (!IsValidUri(Uri))
                {
                    e = new Exception(string.Format("'{0}' is not a valid Uri.", Uri));
                    return hr;
                }
                HttpWebRequest Request = SendRequest(Method, Uri, PostData, ExtraHeaders);
                Response = (HttpWebResponse)Request.GetResponse();
                if (StoreCookies)
                    ProcessCookies(Response);

                var _with1 = hr;
                _with1.WebRequest = Request;
                _with1.RequestUri = Request.RequestUri.ToString();
                _with1.RequestHeaders = GetRequestHeaders(Request);
                if ((PostData != null))
                    _with1.RequestHeaders += "\n\n" + Verbs[(int)Method] + Encoding.Default.GetString(PostData);

                _with1.WebResponse = Response;
                _with1.ResponseUri = Response.ResponseUri.ToString();
                _with1.ResponseHeaders = GetResponseHeaders(Response);
                PostData = null;

                var _with2 = Response;
                if (!(_with2.StatusCode == HttpStatusCode.OK))
                {
                    switch (_with2.StatusCode)
                    {
                        case HttpStatusCode.Found:
                        case HttpStatusCode.RedirectMethod:
                        case HttpStatusCode.RedirectKeepVerb:
                            string Redirect = GetRedirectUrl(hr.RequestUri, _with2.Headers["Location"]);
                            if (AutoRedirect)
                            {
                                if (!string.IsNullOrEmpty(Redirect))
                                {
                                    if (!IsBlackListed(Redirect))
                                    {
                                        Uri = Redirect;
                                        Method = Verb.GET;
                                        Referer = hr.RequestUri;
                                        goto request;
                                    }
                                    else
                                    {
                                        //Debug.Print("Redirect '{0}' is blacklisted", Redirect)
                                    }
                                }
                                else
                                {
                                    Debug.Print("Could not combine redirect Url with base Url");
                                }
                            }
                            else
                            {
                                hr.RedirectUrl = Redirect;
                            }
                            break;
                    }
                }
                else
                {
                    LastResponseUri = Response.ResponseUri.ToString();
                    if ((_with2.Headers[HttpResponseHeader.ContentType] != null))
                    {
                        if (_with2.Headers[HttpResponseHeader.ContentType].StartsWith("image"))
                        {
                            hr.Image = System.Drawing.Image.FromStream(_with2.GetResponseStream());
                            return hr;
                        }
                    }
                }

                hr.Html = HtmlDecode(ProcessResponse(Response));
                hr.StatusCode = Response.StatusCode;
                _LastResponseUri = Uri;

                if (hr.Html.ToLower().Contains("<meta http-equiv=\"refresh"))
                {
                    string Redirect = GetRedirectUrl(hr.RequestUri, ParseMetaRefreshUrl(hr.Html));
                    if (AutoRedirect)
                    {
                        if (!string.IsNullOrEmpty(Redirect))
                        {
                            if (!IsBlackListed(Redirect))
                            {
                                Uri = Redirect;
                                Method = Verb.GET;
                                Referer = hr.RequestUri;
                                goto request;
                            }
                            else
                            {
                                //Debug.Print("Redirect '{0}' is blacklisted", Redirect)
                            }
                        }
                        else
                        {
                            Debug.Print("Could not combine redirect Url with base Url");
                        }
                    }
                    else
                    {
                        hr.RedirectUrl = Redirect;
                    }
                }
                else if (hr.Html.ToLower().Contains("window.parent.location.href =\""))
                {
                    string Redirect = hr.Html.Substring(hr.Html.IndexOf("window.parent.location.href =\"") + "window.parent.location.href =\"".Length);
                    Redirect = Redirect.Substring(0, Redirect.IndexOf("\""));
                    Redirect = GetRedirectUrl(hr.RequestUri, Redirect);
                    if (AutoRedirect)
                    {
                        if (!string.IsNullOrEmpty(Redirect))
                        {
                            if (!IsBlackListed(Redirect))
                            {
                                Uri = Redirect;
                                Method = Verb.GET;
                                Referer = hr.RequestUri;
                                goto request;
                            }
                            else
                            {
                                //Debug.Print("Redirect '{0}' is blacklisted", Redirect)
                            }
                        }
                        else
                        {
                            Debug.Print("Could not combine redirect Url with base Url");
                        }
                    }
                    else
                    {
                        hr.RedirectUrl = Redirect;
                    }
                }

            }
            catch (WebException we)
            {
                e = we;
                if ((we.Response != null))
                {
                    hr.WebResponse = (HttpWebResponse)we.Response;
                    hr.StatusCode = ((HttpWebResponse)we.Response).StatusCode;
                    hr.Html = ProcessResponse(hr.WebResponse);
                }
            }
            catch (Exception ex)
            {
                e = ex;
            }
            finally
            {
                if ((e != null))
                    hr.RequestError = ProcessException(e);
                if ((Response != null))
                    Response.Close();
                this.Referer = string.Empty;
            }

            return hr;
        }

        public HttpResponse GetResponse(HttpWebResponse Response)
        {

            HttpResponse hr = new HttpResponse();
            hr.WebRequest = null;
            hr.RequestHeaders = string.Empty;

            hr.RequestUri = string.Empty;
            hr.WebResponse = null;
            hr.ResponseHeaders = string.Empty;

            hr.ResponseUri = string.Empty;

            hr.RequestError = null;

            hr.RedirectUrl = string.Empty;
            hr.Image = null;
            hr.WebResponse = Response;
            hr.StatusCode = (Response).StatusCode;
            hr.Html = HtmlDecode(ProcessResponse(Response));

            return hr;
        }



        public HttpResponse GetResponse(Verb Method, string Uri, NameValueCollection ExtraHeaders, NameValueCollection Fields, params UploadData[] Upload)
        {
            string Boundary = Guid.NewGuid().ToString().Replace("-", "");

            ContentType = "multipart/form-data; boundary=" + Boundary;

            MemoryStream PostData = new MemoryStream();
            StreamWriter Writer = new StreamWriter(PostData);
            var _with3 = Writer;
            if (Fields != null)
            {
                for (int Index = 0; Index <= (Fields.Count - 1); Index++)
                {
                    _with3.Write(("--" + Boundary) + "\n");
                    _with3.Write("Content-Disposition: form-data; name=\"{0}\"{1}{1}{2}{1}", Fields.Keys[Index], "\n", Fields[Index]);
                }
            }
            if ((Upload != null))
            {
                foreach (UploadData u in Upload)
                {
                    _with3.Write(("--" + Boundary) + "\n");
                    _with3.Write("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", u.FieldName, u.FileName, "\n");
                    _with3.Write(("Content-Type: " + GetMIMEType(u.FileName) + "\n") + "\n");
                    _with3.Flush();
                    if ((u.Contents != null))
                        PostData.Write(u.Contents, 0, u.Contents.Length);
                    _with3.Write("\n");
                }
            }
            _with3.Write("--{0}--{1}", Boundary, "\n");
            _with3.Flush();

            ContentType = "multipart/form-data; boundary=" + Boundary;
            HttpResponse Result = GetResponse(Method, Uri, PostData.ToArray(), ExtraHeaders);
            ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            return Result;
        }

        public string ResolveIP(ref string IP)
        {
            try
            {
                return System.Net.Dns.GetHostEntry(IP).HostName;
            }
            catch
            {
                return string.Empty;
            }
        }
        public IPAddress[] ResolveHost(string Host)
        {
            try
            {
                return System.Net.Dns.GetHostEntry(Host).AddressList;
            }
            catch
            {
                return null;
            }
        }

        public void ClearCookies()
        {
            SessionCookies.Clear();
        }
        public void AddCookie(HttpCookie c)
        {
            SessionCookies.Add(c);
        }
        public void AddCookie(HttpCookie[] c)
        {
            SessionCookies.AddRange(c);
        }
        public void RemoveCookie(HttpCookie c)
        {
            SessionCookies.Remove(c);
        }
        public void RemoveCookie(string Name)
        {
            HttpCookie c = FindCookie(Name);
            if ((c != null))
                RemoveCookie(c);
        }
        public void RemoveCookie(string Name, string Domain)
        {
            for (int Index = (SessionCookies.Count - 1); Index >= 0; Index += -1)
            {
                HttpCookie c = SessionCookies[Index];
                if (c.Name == Name && c.Domain == Domain)
                    SessionCookies.RemoveAt(Index);
            }
        }
        public HttpCookie FindCookie(string Name)
        {
            HttpCookie Result = null;
            foreach (HttpCookie c in SessionCookies)
            {
                if (c.Name == Name)
                {
                    Result = c;
                    break;
                }
            }
            return Result;
        }
        public HttpCookie FindCookie(string Name, string Domain)
        {
            HttpCookie Result = null;
            foreach (HttpCookie c in SessionCookies)
            {
                if (c.Name == Name && c.Domain == Domain)
                {
                    Result = c;
                    break;
                }
            }
            return Result;
        }
        public List<HttpCookie> GetAllCookies()
        {
            return SessionCookies;
        }

        public string UrlEncode(string Data)
        {
            return HttpUtility.UrlEncode(Data);
        }
        public string UrlEncode2(string Value)
        {
            // Proper casing of UrlEncode (MS is encodes lowercase)

            string Unused = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
            StringBuilder sb = new StringBuilder();
            foreach (char c in Value)
            {
                sb.Append(Unused.IndexOf(c) != -1 ? c.ToString() : "%" + string.Format("{0:X2}", Convert.ToInt32(c)));
            }
            return sb.ToString();
        }
        public string UrlDecode(string Data)
        {
            return HttpUtility.UrlDecode(Data);
        }
        public string HtmlEncode(string Data)
        {
            return HttpUtility.HtmlEncode(Data);
        }
        public string HtmlDecode(string Data)
        {
            return HttpUtility.HtmlDecode(Data);
        }

        public string EscapeUnicode(string Data)
        {
            return Regex.Unescape(Data);
        }
        public string FixData(string Data)
        {
            // Ghetto hack
            return HtmlDecode(Data.Replace("\\/\\/", "//").Replace("\\/", "/").Replace("\\\"", "\"").Replace("\\u003e", ">").Replace("\\u003c", "<").Replace("\\u003a", ":").Replace("\\u003b", ";").Replace("\\u003f", "?").Replace("\\u003d", "=").Replace("\\u002f", "/").Replace("\\u0026", "&").Replace("\\u002b", "+").Replace("\\u0025", "%").Replace("\\u0027", "'").Replace("\\u007b", "{").Replace("\\u007d", "}").Replace("\\u007c", "|").Replace("\\u0022", "\"").Replace("\\u0023", "#").Replace("\\u0021", "!").Replace("\\u0024", "$").Replace("\\u0040", "@").Replace("\\002f", "/").Replace("\\r\\n", "\n" + "\n").Replace("\\n", "\n")).Replace("\\x3a", ":").Replace("\\x2f", "/").Replace("\\x3f", "?").Replace("\\x3d", "=").Replace("\\x26", "&");
        }
        public string TrimHtml(string Data)
        {
            return Convert.ToString((string.IsNullOrEmpty(Data) ? string.Empty : Regex.Replace(Data, "<.*?>", "")));
        }

        public string ParseMetaRefreshUrl(string Html)
        {
            if (string.IsNullOrEmpty(Html))
                return string.Empty;
            string Result = Html.Substring(Html.ToLower().IndexOf("<meta http-equiv=\"refresh\"") + "<meta http-equiv=\"refresh\"".Length);
            Result = ParseBetween(Result.ToLower(), "url=", "\"", "url=".Length).Trim();
            if (Result.StartsWith("'"))
                Result = Result.Substring(1);
            if (Result.EndsWith("'"))
                Result = Result.Substring(0, Result.Length - 1);
            return Result;
        }
        public string ParseBetween(string Html, string Before, string After, int Offset)
        {
            if (string.IsNullOrEmpty(Html))
                return string.Empty;
            if (Html.Contains(Before))
            {
                string Result = Html.Substring(Html.IndexOf(Before) + Offset);
                if (Result.Contains(After) && !string.IsNullOrEmpty(After))
                    Result = Result.Substring(0, Result.IndexOf(After));
                return Result;
            }
            else
            {
                return string.Empty;
            }
        }
        public string ParseFormIdText(string Html, string Id, string Highlighter = "\"")
        {
            if (string.IsNullOrEmpty(Html))
                return string.Empty;
            string value = string.Empty;
            try
            {
                Html = Html.Substring(Html.IndexOf("id=" + Highlighter + Id + Highlighter) + 5);
                value = ParseBetween(Html, "value=" + Highlighter, Highlighter, 7);
            }
            catch
            {
            }
            return value;
        }
        public string ParseFormNameText(string Html, string Name, string Highlighter = "\"")
        {
            if (string.IsNullOrEmpty(Html))
                return string.Empty;
            string value = string.Empty;
            try
            {
                Html = Html.Substring(Html.IndexOf("name=" + Highlighter + Name + Highlighter) + 5);
                value = ParseBetween(Html, "value=" + Highlighter, Highlighter, 7);
            }
            catch
            {
            }
            return value;
        }
        public string ParseFormClassText(string Html, string ClassName, string Highlighter = "\"")
        {
            if (string.IsNullOrEmpty(Html))
                return string.Empty;
            string value = string.Empty;
            try
            {
                Html = Html.Substring(Html.IndexOf("class=" + Highlighter + ClassName + Highlighter) + 7);
                value = ParseBetween(Html, "value=" + Highlighter, Highlighter, 7);
            }
            catch
            {
            }
            return value;
        }

        public string TimeStamp()
        {
            return Convert.ToInt32(DateTime.Now.Subtract(Convert.ToDateTime("1.1.1970 00:00:00")).TotalSeconds).ToString();
        }
        public string TimeStampLong()
        {
            return Convert.ToInt64(DateTime.Now.Subtract(Convert.ToDateTime("1.1.1970 00:00:00")).TotalMilliseconds).ToString();
        }

        public string GetMIMEType(string FilePath)
        {
            // Author: stimms (http://stackoverflow.com/users/361/stimms)
            if (MIMETypes.ContainsKey(Path.GetExtension(FilePath.ToLower()).Remove(0, 1)))
                return MIMETypes[Path.GetExtension(FilePath.ToLower()).Remove(0, 1)];
            return "unknown/unknown";
        }

        public int CountOccurance(string Data, string Search, bool CaseSensitive = false)
        {
            return Convert.ToInt32((Convert.ToInt32((CaseSensitive ? (Data.Length - (Data.Replace(Search, "").Length)) : (Data.Length - (Data.ToLower().Replace(Search.ToLower(), "").Length)))) / Search.Length));
        }

        public bool IsValidUri(string Url)
        {
            try
            {
                Uri Uri = new Uri(Url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string ImageToBase64(Image Image, ImageFormat Format)
        {
            string Result = string.Empty;
            try
            {
                using (MemoryStream MemoryStream = new MemoryStream())
                {
                    Image.Save(MemoryStream, Format);
                    Result = Convert.ToBase64String(MemoryStream.ToArray());
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
            return Result;
        }
        public Image Base64ToImage(string Text)
        {
            Image Result = null;
            try
            {
                byte[] Bytes = Convert.FromBase64String(Text);
                using (MemoryStream MemoryStream = new MemoryStream(Bytes, 0, Bytes.Length))
                {
                    MemoryStream.Write(Bytes, 0, Bytes.Length);
                    Result = Image.FromStream(MemoryStream, true);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
            return Result;
        }
        #endregion

        #region "Private Methods"
        private HttpWebRequest SendRequest(Verb Method, string Uri, byte[] PostData, NameValueCollection ExtraHeaders)
        {
            if ((ExtraHeaders == null))
                ExtraHeaders = new NameValueCollection();

            bool Secure = Uri.ToLower().StartsWith("https://");

            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Uri);
            var _with4 = Request;
            _with4.AllowWriteStreamBuffering = AllowWriteStreamBuffering;
            _with4.AllowAutoRedirect = false;
            _with4.AutomaticDecompression = DecompressionMethods.GZip & DecompressionMethods.Deflate;
            _with4.ProtocolVersion = Version;
            _with4.ServicePoint.Expect100Continue = AllowExpect100;
            _with4.Timeout = TimeOut;

            System.Reflection.PropertyInfo Prop = _with4.ServicePoint.GetType().GetProperty("HttpBehaviour", BindingFlags.Instance | BindingFlags.NonPublic);
            Prop.SetValue(_with4.ServicePoint, Convert.ToByte(0), null);

            if (!string.IsNullOrEmpty(Proxy.Server))
            {
                _with4.Proxy = new WebProxy(Proxy.Server, Proxy.Port);
                if (!string.IsNullOrEmpty(Proxy.UserName))
                    _with4.Proxy.Credentials = new NetworkCredential(Proxy.UserName, Proxy.Password);
            }

            if (this.DebugMode)
                Debug.Print(string.Format("[{0}] {1} >> {2}", DateTime.Now.ToString("hh:mm:ss tt").ToLower(), Verbs[(int)Method], Uri));

            _with4.Method = Verbs[(int)Method];
            _with4.Headers.Clear();

            WebHeaderCollection hc = new WebHeaderCollection();
            var _with5 = hc;
            _with5.Add(HttpRequestHeader.Host, new Uri(Uri).Host);
            _with5.Add(HttpRequestHeader.UserAgent, Useragent);
            if (!string.IsNullOrEmpty(Accept))
                _with5.Add(HttpRequestHeader.Accept, Accept);
            if (!string.IsNullOrEmpty(AcceptLanguage))
                _with5.Add(HttpRequestHeader.AcceptLanguage, AcceptLanguage);
            if (!string.IsNullOrEmpty(AcceptEncoding))
                _with5.Add(HttpRequestHeader.AcceptEncoding, AcceptEncoding);
            if (!string.IsNullOrEmpty(AcceptCharset))
                _with5.Add(HttpRequestHeader.AcceptCharset, AcceptCharset);

            if (!(ExtraHeaders.Count == 0))
            {
                for (int Index = 0; Index <= (ExtraHeaders.Count - 1); Index++)
                {
                    switch (ExtraHeaders.Keys[Index])
                    {
                        case "Host":
                        case "User-Agent":
                        case "Referer":
                        case "Accept":
                        case "Accept-Language":
                        case "Accept-Charset":
                        case "Connection":
                            break;
                        default:
                            _with5.Add(ExtraHeaders.Keys[Index], ExtraHeaders[Index]);
                            break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(Referer))
                _with5.Add(HttpRequestHeader.Referer, Referer);
            if (KeepAlive)
            {
                if (Secure)
                {
                    _with5.Add(HttpRequestHeader.Connection, "keep-alive");
                }
                else
                {

                    try
                    {
                        if (!(Proxy.Server == null))
                        {
                            _with5.Add("Proxy-Connection", "keep-alive");
                        }
                    }
                    catch
                    {
                        _with5.Add("Connection", "keep-alive");
                    }
                }
            }

            if (SendCookies)
            {
                string Cookie = null;
                Cookie = Convert.ToString((UseCustomCookies ? GetCookies(CustomCookies) : GetCookies(Uri)));
                if (!string.IsNullOrEmpty(Cookie))
                    _with5.Add("Cookie", Cookie);
            }

            // Set correct order of headers before sending. 
            // Needed to use reflection to send in the proper order.
            for (int Index = 0; Index <= hc.Count - 1; Index++)
            {
                Type Type = typeof(WebHeaderCollection);
                MethodInfo Info = Type.GetMethod("AddWithoutValidate", BindingFlags.Instance | BindingFlags.NonPublic);
                Info.Invoke(Request.Headers, new object[] {
				hc.Keys[Index],
				hc[Index]
			});
            }

            if ((PostData != null))
            {
                _with4.SendChunked = SendChunked;

                _with4.ContentType = ContentType;
                _with4.ContentLength = PostData.Length;

                Stream dataStream = _with4.GetRequestStream();
                var _with6 = dataStream;
                _with6.Write(PostData, 0, PostData.Length);
                _with6.Close();
                _with6.Dispose();
            }

            PostData = null;
            LastRequestUri = Uri;
            return Request;
        }

        public string ProcessResponse(System.Net.HttpWebResponse Response)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                var _with7 = Response;
                System.IO.Stream Stream = _with7.GetResponseStream();

                if ((Response.ContentEncoding.ToLower().Contains("gzip")))
                {
                    Stream = new GZipStream(Stream, CompressionMode.Decompress);
                }
                else if ((Response.ContentEncoding.ToLower().Contains("deflate")))
                {
                    Stream = new DeflateStream(Stream, CompressionMode.Decompress);
                }

                StreamReader Reader = new StreamReader(Stream);
                Char[] Buffer = new Char[1026];
                int Read = Reader.Read(Buffer, 0, 1024);
                while (Read > 0)
                {
                    String outputData = new String(Buffer, 0, Read);
                    outputData = outputData.Replace(Convert.ToChar(0x00).ToString(), string.Empty);
                    sb.Append(outputData);
                    Read = Reader.Read(Buffer, 0, 1024);
                }
                Reader.Close();
                Reader.Dispose();
                Reader = null;
                Stream.Close();
                Stream.Dispose();
                Stream = null;
                return sb.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }
        private HttpError ProcessException(object Ex)
        {
            HttpError Result = new HttpError();
            string Message = string.Empty;

            Result.Exception = Ex;

            if (Ex is WebException)
            {
                WebException we = (WebException)Ex;
                if ((we.Response != null) && ((HttpWebResponse)we.Response).StatusCode == HttpStatusCode.BadGateway)
                {
                    Message = we.Message;
                    if (!string.IsNullOrEmpty(this.Proxy.Server))
                        Result.IsProxyError = true;
                }
                if (we.Message.Contains("The underlying connection was closed:"))
                {
                    Message = we.Message;
                    if (!string.IsNullOrEmpty(this.Proxy.Server))
                        Result.IsProxyError = true;
                }
                else if (we.Message.Contains("The remote server returned an error: ("))
                {
                    Message = we.Message;
                    if (!string.IsNullOrEmpty(this.Proxy.Server))
                        Result.IsProxyError = true;
                }
                else
                {
                    switch (we.Status)
                    {
                        case WebExceptionStatus.Timeout:
                            Message = "Timed out.";
                            if (!string.IsNullOrEmpty(this.Proxy.Server))
                                Result.IsProxyError = true;
                            break;
                        case WebExceptionStatus.ConnectFailure:
                            if (we.Message.Trim() == "Unable to connect to the remote server")
                            {
                                Message = Convert.ToString((!string.IsNullOrEmpty(this.Proxy.Server) ? "Could not connect to proxy server." : "Could not connect to server."));
                                if (!string.IsNullOrEmpty(this.Proxy.Server))
                                    Result.IsProxyError = true;
                            }
                            else
                            {
                                Message = we.Message;
                            }
                            break;
                        case WebExceptionStatus.KeepAliveFailure:
                            Message = Convert.ToString((!string.IsNullOrEmpty(this.Proxy.Server) ? "Disconnected from proxy server." : we.Message));
                            if (!string.IsNullOrEmpty(this.Proxy.Server))
                                Result.IsProxyError = true;
                            break;
                        default:
                            Message = we.Message;
                            Debug.Print("Exception else: " + we.Status + " - " + we.Message);
                            break;
                    }
                }
            }
            else
            {
                Message = (Ex as Exception).Message;
            }
            Result.Message = Message;
            return Result;
        }

        private string GetCookies(HttpCookie[] Cookies)
        {
            string Result = string.Empty;
            if ((Cookies != null))
            {
                var _with8 = Cookies;
                if (_with8.Length == 0)
                    return Result;
                foreach (HttpCookie item in Cookies)
                {
                    Result += item.Name + (string.IsNullOrEmpty(item.Value) ? "" : "=" + item.Value).ToString() + "; ";
                }
                if (Result.EndsWith("; "))
                    Result = Result.Substring(0, Result.Length - 2);
            }
            return Result;
        }
        private string GetCookies(string RequestUri)
        {
            string Result = string.Empty;
            if (RequestUri.StartsWith("https://"))
                RequestUri = "http://" + RequestUri.Substring(RequestUri.IndexOf("//") + 2);
            if (!RequestUri.StartsWith("http"))
                RequestUri = "http://" + RequestUri;
            Uri Uri = new Uri(RequestUri);

            if ((SessionCookies != null))
            {
                var _with9 = SessionCookies;
                if (_with9.Count == 0)
                    return Result;
                foreach (HttpCookie item in SessionCookies)
                {
                    if (item.Domain.ToLower().Trim() == Uri.Host.ToLower().Trim())
                    {
                        Result += item.Name + (string.IsNullOrEmpty(item.Value) ? "" : "=" + item.Value).ToString() + "; ";
                    }
                    else
                    {
                        if (item.Domain.StartsWith(".") && Uri.Host.Contains(item.Domain))
                        {
                            Result += item.Name + (string.IsNullOrEmpty(item.Value) ? "" : "=" + item.Value).ToString() + "; ";
                        }
                        else if (item.Domain.StartsWith(".") && CountOccurance(Uri.Host, ".") == 1)
                        {
                            Result += item.Name + (string.IsNullOrEmpty(item.Value) ? "" : "=" + item.Value).ToString() + "; ";
                        }
                        else if (item.Domain.Contains(Uri.Host))
                        {
                            Result += item.Name + (string.IsNullOrEmpty(item.Value) ? "" : "=" + item.Value).ToString() + "; ";
                        }
                        else
                        {
                            //Debug.Print("here: " & Uri.Host & " / " & item.Domain)
                        }
                    }
                }
                if (Result.EndsWith("; "))
                    Result = Result.Substring(0, Result.Length - 2);
            }
            else
            {
                SessionCookies = new List<HttpCookie>();
            }
            return Result;
        }
        public void ProcessCookies(HttpWebResponse Response)
        {
            try
            {
                if ((SessionCookies == null))
                    SessionCookies = new List<HttpCookie>();

                string Data = Response.Headers["Set-Cookie"];
                if (Data == null)
                    return;
                if (string.IsNullOrEmpty(Data))
                    return;
                Data = Data.Replace("Mon,", "Mon").Replace("Tue,", "Tue").Replace("Wed,", "Wed").Replace("Thu,", "Thu").Replace("Fri,", "Fri").Replace("Sat,", "Sat").Replace("Sun,", "Sun");
                Data = Data.Replace("Monday,", "Mon").Replace("Tuesday,", "Tue").Replace("Wednesday,", "Wed").Replace("Thursday,", "Thurs").Replace("Friday,", "Fri").Replace("Saturday,", "Sat").Replace("Sunday,", "Sun");

                if (!Data.Contains(","))
                {
                    ParseCookie(Data, Response.ResponseUri);
                }
                else
                {
                    foreach (string c in Data.Split(','))
                    {
                        ParseCookie(c, Response.ResponseUri);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }
        private void ParseCookie(string Data, Uri Uri)
        {
            HttpCookie Cookie = new HttpCookie();
            var _with10 = Cookie;
            _with10.Name = Data.Split('=')[0].Trim();
            if (CookieBlacklist.Contains(_with10.Name))
                return;

            _with10.HttpOnly = false;
            _with10.Secure = false;

            if (Data.Contains(";"))
            {
                _with10.Value = Data.Substring(0, Data.IndexOf(";"));
                _with10.Value = _with10.Value.Split('=')[1].Trim();
            }
            else
            {
                _with10.Value = Data.Split('=')[1].Trim();
            }

            if (!(_with10.Value.ToLower() == "deleted"))
            {
                foreach (string param in Data.Split(';'))
                {
                    string Parameter = param.Trim();
                    if (!string.IsNullOrEmpty(Parameter))
                    {
                        if (Parameter.Contains("="))
                        {
                            string Key = Parameter.Split('=')[0].Trim();
                            string Value = Parameter.Substring(Parameter.IndexOf("=") + 1).Trim();

                            if (Key.ToLower() == _with10.Name.ToLower())
                            {
                                _with10.Value = Value;
                            }

                            switch (Key.ToLower())
                            {
                                case "path":
                                    _with10.Path = Value;
                                    break;
                                case "expires":
                                    try
                                    {
                                        if (Value.ToLower().EndsWith("utc") | Value.ToLower().EndsWith("gmt"))
                                        {
                                            Value = Value.Substring(0, Value.ToLower().IndexOf((Value.ToLower().EndsWith("utc") ? "utc" : "gmt").ToString())).Trim();
                                            try
                                            {
                                                _with10.Expires = System.DateTime.Parse(Value);
                                            }
                                            catch
                                            {
                                                _with10.Expires = default(DateTime);
                                            }
                                        }
                                        else
                                        {
                                            _with10.Expires = Convert.ToDateTime(Value);
                                        }
                                    }
                                    catch
                                    {
                                        _with10.Expires = default(DateTime);
                                    }
                                    break;
                                case "domain":
                                    _with10.Domain = Value;
                                    break;
                                case "httponly":
                                    _with10.HttpOnly = true;
                                    break;
                                case "secure":
                                    _with10.Secure = true;
                                    break;
                                case "version":
                                    _with10.Version = Convert.ToInt32(Value);
                                    break;
                                default:
                                    Debug.Print("unknown with value: " + Key + " - " + Value);
                                    break;
                            }
                        }
                        else
                        {
                            switch (Parameter.ToLower())
                            {
                                case "secure":
                                    _with10.Secure = true;
                                    break;
                                case "httponly":
                                    _with10.HttpOnly = true;
                                    break;
                                default:
                                    Debug.Print("unknown without value: " + Parameter);
                                    break;
                            }
                        }
                    }
                }

                if (string.IsNullOrEmpty(_with10.Path))
                    _with10.Path = Uri.AbsolutePath;
                if (string.IsNullOrEmpty(_with10.Domain))
                    _with10.Domain = Uri.Host;
                if (_with10.Domain.StartsWith("www."))
                    _with10.Domain = _with10.Domain.Replace("www.", ".");

                HttpCookie Find = FindCookie(_with10.Name, _with10.Domain);
                if ((Find != null))
                    SessionCookies.Remove(Find);
                SessionCookies.Add(Cookie);
            }
            else
            {
                if ((FindCookie(Cookie.Name, Cookie.Domain) != null))
                    SessionCookies.Remove(FindCookie(Cookie.Name, Cookie.Domain));
            }
        }
        private bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void SetUnsafeHeaderParsing(bool Allow)
        {
            // Credit: lessthandot.com
            // Source: http://wiki.lessthandot.com/index.php/Setting_unsafeheaderparsing

            //Dim SettingsSection As New System.Net.Configuration.SettingsSection
            //Dim Assembly As System.Reflection.Assembly = System.Reflection.Assembly.GetAssembly(SettingsSection.GetType)
            //Dim SettingsType As Type = Assembly.GetType("System.Net.Configuration.SettingsSectionInternal")
            //Dim Args As Object() = Nothing
            //Dim Instance As Object = SettingsType.InvokeMember("Section", System.Reflection.BindingFlags.Static Or BindingFlags.GetProperty Or BindingFlags.NonPublic, Nothing, Nothing, Args)
            //Dim UseUnsafeHeaderParsing As FieldInfo = SettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic Or BindingFlags.Instance)
            //UseUnsafeHeaderParsing.SetValue(Instance, Allow)
        }

        private string GetRequestHeaders(HttpWebRequest Request)
        {
            return string.Format("Request Headers -----------------------------------{0}{1}", "\n", Request.Headers.ToString());
        }
        public string GetResponseHeaders(HttpWebResponse Response)
        {
            return string.Format("Response Headers -----------------------------------{0}{1}", "\n", Response.Headers.ToString());
        }

        private string GetRedirectUrl(string RequestUri, string Redirect)
        {
            string Result = string.Empty;
            if (IsValidUri(Redirect))
            {
                Result = Redirect;
            }
            else
            {
                if (Redirect.StartsWith("&") | Redirect.StartsWith("?"))
                {
                    Result = RequestUri + Redirect;
                }
                else if (Redirect.StartsWith("/"))
                {
                    bool Built = false;
                    foreach (string Part in Redirect.Split('/'))
                    {
                        if (RequestUri.EndsWith("/" + Part))
                        {
                            Result = RequestUri + Redirect.Substring(Redirect.IndexOf("/" + Part) + Part.Length + 1);
                            break;
                        }
                    }
                    if (!Built)
                        Result = (RequestUri.StartsWith("https") ? "https://" : "http://").ToString() + new Uri(RequestUri).Host + Redirect;
                }
                else
                {
                    Debug.Print("RequestUri: " + RequestUri);
                    Debug.Print("Redirect: " + Redirect);
                }
            }
            return Result;
        }

        private bool IsBlackListed(string Url)
        {
            foreach (string r in RedirectBlacklist)
            {
                if (Url.ToLower().Contains(r.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        [Serializable()]
        public class HttpCookie
        {
            public string Name = string.Empty;
            public string Value = string.Empty;
            public string Domain = string.Empty;
            public string Path = string.Empty;
            public System.DateTime Expires = default(DateTime);
            public bool HttpOnly = false;
            public bool Secure = false;

            public int Version = -1;
            public HttpCookie()
            {
            }
            public HttpCookie(string cName, string cValue, string cDomain)
            {
                Name = cName;
                Value = cValue;
                Domain = cDomain;
            }
            public HttpCookie(string cName, string cValue, string cDomain, string cPath, System.DateTime cExpires, bool cHttpOnly, bool cSecure, int cVersion)
            {
                Name = cName;
                Value = cValue;
                Domain = cDomain;
                Path = cPath;
                Expires = cExpires;
                HttpOnly = cHttpOnly;
                Secure = cSecure;
                Version = cVersion;
            }
        }
        public class HttpResponse
        {
            public HttpWebRequest WebRequest = null;
            public string RequestHeaders = string.Empty;

            public string RequestUri = string.Empty;
            public HttpWebResponse WebResponse = null;
            public string ResponseHeaders = string.Empty;

            public string ResponseUri = string.Empty;

            public HttpStatusCode StatusCode;

            public HttpError RequestError = null;

            public string RedirectUrl = string.Empty;
            public string Html = string.Empty;
            public Image Image = null;
        }
        public class HttpError
        {
            public object Exception = null;
            public string Message = string.Empty;
            public bool IsProxyError = false;
            public string Html = string.Empty;
        }

    }
}
