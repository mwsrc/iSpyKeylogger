using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// License Loader, Version: 2.0.0.7, Changed: 09/05/2013
/// </summary>

internal sealed class License
{

	#region " ReadOnly Properties "

	public string Username {
		get {
			object Data = Instance.GetMethod("GetUsername").Invoke(null, null);
			return (string)Data;
		}
	}

    public static string ProductID = "qLRsADuSpcHXfRJ2MM0Oyw==";

	private Version _ProductVersion;
	public Version ProductVersion {
		get {
			if (_ProductVersion == null) {
				_ProductVersion = new Version(Application.ProductVersion);
			}

			return _ProductVersion;
		}
	}

	public string ExecutablePath {
		get {
			object Data = Instance.GetMethod("GetExecutablePath").Invoke(null, null);
			return (string)Data;
		}
	}

	public string GlobalMessage {
		get {
			object Data = Instance.GetMethod("GetMessage").Invoke(null, null);
			return (string)Data;
		}
	}
	
	public IPAddress IPAddress {
		get {
			object Data = Instance.GetMethod("GetIPAddress").Invoke(null, null);
			return (IPAddress)Data;
		}
	}

	public System.DateTime ExpirationDate {
		get {
			object Data = Instance.GetMethod("GetExpiration").Invoke(null, null);
			return (System.DateTime)Data;
		}
	}

	public TimeSpan TimeRemaining {
		get {
			object Data = Instance.GetMethod("GetRemaining").Invoke(null, null);
			return (TimeSpan)Data;
		}
	}

	public LicenseType LicenseType {
		get {
			object Data = Instance.GetMethod("GetLicenseType").Invoke(null, null);
			return (LicenseType)Data;
		}
	}

	public int Points {
		get {
			object Data = Instance.GetMethod("GetPoints").Invoke(null, null);
			return (int)Data;
		}
	}

	public bool UnlimitedTime {
		get {
			object Data = Instance.GetMethod("GetUnlimitedTime").Invoke(null, null);
			return (bool)Data;
		}
	}

	public bool UpdateAvailable {
		get {
			object Data = Instance.GetMethod("GetUpdateAvailable").Invoke(null, null);
			return (bool)Data;
		}
	}

	public int UsersCount {
		get {
			object Data = Instance.GetMethod("GetUsersCount").Invoke(null, null);
			return (int)Data;
		}
	}

	public int UsersOnline {
		get {
			object Data = Instance.GetMethod("GetUsersOnline").Invoke(null, null);
			return (int)Data;
		}
	}

	public string GUID {
		get {
			object Data = Instance.GetMethod("GetGUID").Invoke(null, null);
			return (string)Data;
		}
	}

	public string PublicToken {
		get {
			object Data = Instance.GetMethod("GetPublicToken").Invoke(null, null);
			return (string)Data;
		}
	}

	public byte[] PrivateKey {
		get {
			object Data = Instance.GetMethod("GetPrivateKey").Invoke(null, null);
			return (byte[])Data;
		}
	}

	public WebClient Client {
		get {
			object Data = Instance.GetMethod("GetClient").Invoke(null, null);
			return (WebClient)Data;
		}
	}

	public NewsPost[] News {
		get {
			object Data = Instance.GetMethod("GetNews").Invoke(null, null);
			object[] Values = (object[])Data;

			int Section = 0;
			List<NewsPost> T = new List<NewsPost>();

			for (int I = 0; I <= Values.Length - 1; I += 3) {
				Section = I * 3;
				T.Add(new NewsPost(Values[I], Values[I + 1], Values[I + 2]));
			}

			return T.ToArray();
		}
	}

	#endregion

	#region " Initialize Properties "

	private string _ID;
	public string ID {
		get { return _ID; }
		set { _ID = value; }
	}

	private bool _Catch = true;
	public bool Catch {
		get { return _Catch; }
		set { _Catch = value; }
	}

	private bool _DisableUpdates;
	public bool DisableUpdates {
		get { return _DisableUpdates; }
		set { _DisableUpdates = value; }
	}

	private GenericDelegate _RunHook;
	public GenericDelegate RunHook {
		get { return _RunHook; }
		set { _RunHook = value; }
	}

	private GenericDelegate _BanHook;
	public GenericDelegate BanHook {
		get { return _BanHook; }
		set { _BanHook = value; }
	}

	private GenericDelegate _RenewHook;
	public GenericDelegate RenewHook {
		get { return _RenewHook; }
		set { _RenewHook = value; }
	}

	private RuntimeProtection _Protection;
	public RuntimeProtection Protection {
		get { return _Protection; }
		set { _Protection = value; }
	}

	private bool _ValidateCore = true;
	public bool ValidateCore {
		get { return _ValidateCore; }
		set { _ValidateCore = value; }
	}

	#endregion

	#region " Public Methods "

	public void Initialize(string programID)
	{
		ID = programID;
		Initialize();
	}

	public void Initialize()
	{
		if (LicenseGlobal.LicenseInitialize)
			return;
		LicenseGlobal.LicenseInitialize = true;

		if (string.IsNullOrEmpty(ID)) {
			ErrorKill("Unable to initialize due to missing Net Seal ID.");
			return;
		}

		ServicePointManager.Expect100Continue = false;
		ServicePointManager.DefaultConnectionLimit = 5;

		try {
			WC = new CookieClient();

			string Common = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			LocationPath = Path.Combine(Common, "Nimoru");

			LicenseLocation = Path.Combine(LocationPath, "LicenseSE");
			GizmoDllLocation = Path.Combine(LocationPath, "GizmoDll");
			GizmoLocation = Path.Combine(LocationPath, "GizmoSE");

			OverrideSSL();
			//--BEGIN OVERRIDE--

			DownloadChecksums();
			DownloadComponents();

			RestoreSSL();
			//--END OVERRIDE--

			Endpoint = Checksums[5];
			ValidateSignature();

			Instance.GetMethod("SetID").Invoke(null, new object[] { ID });
			Instance.GetMethod("SetCatch").Invoke(null, new object[] { Catch });
			Instance.GetMethod("SetDisableUpdates").Invoke(null, new object[] { DisableUpdates });
			Instance.GetMethod("SetRunHook").Invoke(null, new object[] { RunHook });
			Instance.GetMethod("SetBanHook").Invoke(null, new object[] { BanHook });
			Instance.GetMethod("SetRenewHook").Invoke(null, new object[] { RenewHook });
			Instance.GetMethod("SetScan").Invoke(null, new object[] { (byte)Protection });
		} catch (Exception ex) {
			StringBuilder T = new StringBuilder();
			T.AppendLine(System.DateTime.UtcNow.ToString());
			T.AppendLine();
			T.AppendLine(ex.Message);
			T.AppendLine(ex.StackTrace);
			File.WriteAllText("loader.log", T.ToString());

			ErrorKill("Unable to continue due to an error. Exception written to 'loader.log' file.");
			return;
		}

		try {
			Instance.GetMethod("RunWE").Invoke(null, new object[] {
				Version,
				ProductVersion,
				Endpoint
			});
		} catch {
			ErrorKill("Unable to initialize license file.");
		}
	}

	public void ShowAccount()
	{
		Instance.GetMethod("ShowAccount").Invoke(null, null);
	}

	public string Encrypt(string data)
	{
		InitializeRm();

		byte[] R = Encoding.UTF8.GetBytes(data);
		byte[] O = Encryptor.TransformFinalBlock(R, 0, R.Length);
		byte[] U = new byte[O.Length + 4];

		Buffer.BlockCopy(BitConverter.GetBytes(data.Length), 0, U, 0, 4);
		Buffer.BlockCopy(O, 0, U, 4, O.Length);

		return Convert.ToBase64String(U);
	}

	public byte[] Decrypt(byte[] data)
	{
		InitializeRm();

		int Size = BitConverter.ToInt32(data, 0);
		byte[] O = Decryptor.TransformFinalBlock(data, 4, data.Length - 4);

		byte[] U = new byte[Size];
		Buffer.BlockCopy(O, 0, U, 0, Size);

		return U;
	}

	//NOTE: If String.IsNullOrEmpty() get new posts from License.News.
	public string GetPostMessage(int postID)
	{
		object Data = Instance.GetMethod("GetPostMessage").Invoke(null, new object[] { postID });
		return (string)Data;
	}

	public string GetVariable(string name)
	{
		object Data = Instance.GetMethod("GetVariable").Invoke(null, new object[] { name });
		return (string)Data;
	}

	public bool SpendPoints(int count)
	{
		object Data = Instance.GetMethod("SpendPoints").Invoke(null, new object[] { count });
		return (bool)Data;
	}

	public void InstallUpdates()
	{
		Instance.GetMethod("InstallUpdates").Invoke(null, null);
	}

	public void BanCurrentUser(string reason)
	{
		Instance.GetMethod("BanCurrentUser").Invoke(null, new object[] { reason });
	}

	#endregion

	#region " System Declarations "

	//IMPORTANT: DO NOT CHANGE THIS!

	private Version Version = new Version("2.0.0.6");
	private Type Instance;

	private CookieClient WC;
	private string LocationPath;
	private string LicenseLocation;
	private string GizmoDllLocation;

	private string GizmoLocation;
	private string[] Checksums;

	private string Endpoint;
	private const string Domain1 = "http://seal.nimoru.com/Base/";

	private const string Domain2 = "https://s3.amazonaws.com/nimoru/";

	private const string PublicKey = "BgIAAAAiAABEU1MxAAQAAKVlurdZMaHymNk04yRy3VGj0Bhf6gGIBsGr1zk42LrdnwYLfvn7MBAiYoCH2cD07M/HuM6NW1WqJQVF2omwH5S211wfvBCutU92RxXldmfvd06l8eQqmppztYIrXdxmW0BRlosBKPM5ms6YXZnoMKseAoqZ6Ajza8U9QCJMkSHSR+O23EoGj9V+7xwkCoYHklFtLJzERB6y/DW1BCCHhLblzpFz+mht1CD6xAi2QBNY7vZcWdbqo+ZLT4y7sw8jU61liYBuZLA/t+6KHhoIwZ+NIErsCHW5RD9ln5VpMC66wBCcY594ZTIManIuvmpw4eQaUXZPoMogf29gJgJSolaDg5iP1XDqzOTPu9RdsHe3R1ZaNglrL05zoTM94Zkl5KT+bPAUC99kGrEDmNipe6tj8FwoOTNNaTaOvWZlXTtAfaxqGV47nxKfabgxEl08n0c3PBJEjUZzJ4chwQ2Ex2A5uYBgRukcmKmRmdwIphHq0IwdoxS1+6HSwXxg1d3EEAoxJ75R1eSXF+cXOeC7d/U2UY0tqwAAAMvTiz5uMzpBQIYdNcbYnrJwHObk";
	private string UID {
		get { return "?uid=" + BitConverter.ToString(BitConverter.GetBytes(Environment.TickCount)).Replace("-", ""); }
	}

	private ICryptoTransform Encryptor;
	private ICryptoTransform Decryptor;

	private bool RmInitialize;
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public delegate void GenericDelegate();

	[DllImport("kernel32.dll", EntryPoint = "ExitProcess")]
	private static extern void ExitProcess(uint code);

	[DllImport("mscoree.dll", EntryPoint = "StrongNameSignatureVerificationEx", CharSet = CharSet.Unicode)]
	private static extern bool StrongNameSignatureVerificationEx(string fileName, bool force, ref bool genuine);

	[DllImport("mscoree.dll", PreserveSig = false, EntryPoint = "CLRCreateInstance")]
	[return: MarshalAs(UnmanagedType.Interface)]
	private static extern object CreateInstance(	[MarshalAs(UnmanagedType.LPStruct)]
Guid cid, 	[MarshalAs(UnmanagedType.LPStruct)]
Guid iid);

	#endregion

	#region " System Methods "

	private void DownloadChecksums()
	{
		try {
			Checksums = WC.DownloadString(Domain1 + "checksumSE.php" + UID).Split(char.MinValue);
		} catch {
			System.Threading.Thread.Sleep(500);
			Checksums = WC.DownloadString(Domain2 + "checksumSE.txt" + UID).Split(Convert.ToChar(124));
		}
	}

	private void DownloadComponents()
	{
		string Hash = null;
		if (!Directory.Exists(LocationPath)) {
			Directory.CreateDirectory(LocationPath);
		}

		if (!File.Exists(GizmoDllLocation)) {
			DownloadGizmoDll();
		}

		Hash = MD5File(GizmoDllLocation);
		if (!(Hash == Checksums[1])) {
			DownloadGizmoDll();
		}

		if (!File.Exists(GizmoLocation)) {
			DownloadGizmo();
		}

		Hash = MD5File(GizmoLocation);
		if (!(Hash == Checksums[2])) {
			DownloadGizmo();
		}

		if (!File.Exists(LicenseLocation)) {
			DownloadLicense();
		}

		Hash = MD5File(LicenseLocation);
		if (!(Hash == Checksums[3])) {
			DownloadLicense();
		}
	}

	private void ValidateSignature()
	{
		if (ValidateCore && !CheckCore()) {
			throw new InvalidDataException("Core framework files are not trusted.");
			return;
		}

		FileStream M = File.OpenRead(LicenseLocation);
		BinaryReader R = new BinaryReader(M);

		byte[] FullData = R.ReadBytes(Convert.ToInt32(M.Length));
		M.Position = 2;

		byte[] Sign = R.ReadBytes(40);
		byte[] Data = R.ReadBytes(Convert.ToInt32(M.Length - Sign.Length - 2));
		R.Close();

		DSACryptoServiceProvider DSA = new DSACryptoServiceProvider();
		DSA.ImportCspBlob(Convert.FromBase64String(PublicKey));

		if (DSA.VerifyData(Data, Sign)) {
			Instance = Assembly.Load(FullData).GetType("Share");
		} else {
			throw new InvalidDataException("Unable to validate signature.");
		}
	}


	private void DownloadGizmoDll()
	{
		byte[] Data = WC.DownloadData(Checksums[0] + Checksums[1] + ".co");
		Data = Decompress(Data);

		string Hash = MD5(Data);
		if (!(Checksums[1] == Hash)) {
			Fail(GizmoDllLocation);
			return;
		}

		File.WriteAllBytes(GizmoDllLocation, Data);
	}

	private void DownloadGizmo()
	{
		byte[] Data = WC.DownloadData(Checksums[0] + Checksums[2] + ".co");
		Data = GizmoDecompress(Data);

		string Hash = MD5(Data);
		if (!(Checksums[2] == Hash)) {
			Fail(GizmoLocation);
			return;
		}

		File.WriteAllBytes(GizmoLocation, Data);
	}

	private void DownloadLicense()
	{
		ProcessStartInfo PI = new ProcessStartInfo();
		PI.Arguments = string.Format("\"{0}\" \"{1}\" {2} -s", Checksums[0] + Checksums[3] + ".co", LicenseLocation, Checksums[3]);
		PI.FileName = GizmoLocation;
		PI.UseShellExecute = false;

		Process P = Process.Start(PI);
		if (!P.WaitForExit(20000)) {
			Environment.Exit(0);
		}

		if (!(P.ExitCode == 7788)) {
			Environment.Exit(0);
		}
	}


	private void Fail(string path)
	{
		File.Delete(path);
		ErrorKill("Failed to initialize all the required components.");
	}

	private void ErrorKill(string message)
	{
		MessageBox.Show(message, "Loader Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		Environment.Exit(0);
		ExitProcess(0);
	}


	private byte[] Decompress(byte[] data)
	{
		int Size = BitConverter.ToInt32(data, 0);

		byte[] U = new byte[Size];
		MemoryStream M = new MemoryStream(data, 4, data.Length - 4);

		DeflateStream D = new DeflateStream(M, CompressionMode.Decompress, false);
		D.Read(U, 0, U.Length);

		D.Close();
		M.Close();
		return U;
	}

	private byte[] GizmoDecompress(byte[] data)
	{
		byte[] GizmoDll = File.ReadAllBytes(GizmoDllLocation);
		MethodInfo G = Assembly.Load(GizmoDll).GetType("H").GetMethod("Decompress");
		return (byte[])G.Invoke(null, new object[] { data });
	}


	private string MD5(byte[] data)
	{
		MD5CryptoServiceProvider H = new MD5CryptoServiceProvider();
		return HashToString(H.ComputeHash(data));
	}

	private string MD5File(string path)
	{
		FileStream F = new FileStream(path, FileMode.Open, FileAccess.Read);
		MD5CryptoServiceProvider H = new MD5CryptoServiceProvider();

		string Hash = HashToString(H.ComputeHash(F));

		F.Close();
		return Hash;
	}

	private string HashToString(byte[] data)
	{
		return BitConverter.ToString(data).ToLower().Replace("-", string.Empty);
	}

	private void InitializeRm()
	{
		if (RmInitialize)
			return;
		RmInitialize = true;

		RijndaelManaged Rm = new RijndaelManaged();
		Rm.Padding = PaddingMode.Zeros;
		Rm.Mode = CipherMode.CBC;
		Rm.Key = PrivateKey;
		Rm.IV = PrivateKey;

		Encryptor = Rm.CreateEncryptor();
		Decryptor = Rm.CreateDecryptor();
	}


	private IStrongName SN;
	private bool CheckCore()
	{
		string Base = RuntimeEnvironment.GetRuntimeDirectory();
		string Build = RuntimeEnvironment.GetSystemVersion();
		bool HostCLR = Int32.Parse(Build[1].ToString()) >= 4;

		if (HostCLR) {
			Guid CID_META_HOST = new Guid("9280188D-0E8E-4867-B30C-7FA83884E8DE");
			Guid CID_STRONG_NAME = new Guid("B79B0ACD-F5CD-409B-B5A5-A16244610B92");

			IMeta Meta = (IMeta)CreateInstance(CID_META_HOST, typeof(IMeta).GUID);
			IRuntime Runtime = (IRuntime)Meta.GetRuntime(Build, typeof(IRuntime).GUID);
			SN = (IStrongName)Runtime.GetInterface(CID_STRONG_NAME, typeof(IStrongName).GUID);
		}

		string File1 = Path.ChangeExtension(Path.Combine(Base, "mscorlib"), "dll");
		string File2 = Path.ChangeExtension(Path.Combine(Base, "system"), "dll");

		byte[] Token = new byte[] {
			183,
			122,
			92,
			86,
			25,
			52,
			224,
			137
		};
		if (!IsTrusted(File1, Token, HostCLR))
			return false;
		if (!IsTrusted(File2, Token, HostCLR))
			return false;

		return true;
	}

	private bool IsTrusted(string path, byte[] token, bool hostCLR)
	{
		bool Genuine = false;

		if (hostCLR) {
			if (!(SN.StrongNameSignatureVerificationEx(path, true, ref Genuine) == 0 && Genuine))
				return false;
		} else {
			if (!(StrongNameSignatureVerificationEx(path, true, ref Genuine) && Genuine))
				return false;
		}

		byte[] PublicToken = Assembly.LoadFile(path).GetName().GetPublicKeyToken();
		if (PublicToken == null || !(PublicToken.Length == 8))
			return false;

		for (int I = 0; I <= 7; I++) {
			if (!(PublicToken[I] == token[I]))
				return false;
		}

		return true;
	}

	private RemoteCertificateValidationCallback SSLCallback;
	private bool ValidateSSL(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
	{
		return true;
	}

	private void OverrideSSL()
	{
		SSLCallback = ServicePointManager.ServerCertificateValidationCallback;
		ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateSSL);
	}

	private void RestoreSSL()
	{
		ServicePointManager.ServerCertificateValidationCallback = SSLCallback;
	}

	#endregion

	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("D332DB9E-B9B3-4125-8207-A14884F53216")]
	private interface IMeta
	{
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetRuntime(string version, 		[MarshalAs(UnmanagedType.LPStruct)]
Guid iid);
	}

	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
	private interface IRuntime
	{
		void M1();
		void M2();
		void M3();
		void M4();
		void M5();
		void M6();
		[return: MarshalAs(UnmanagedType.Interface)]
		object GetInterface(		[MarshalAs(UnmanagedType.LPStruct)]
Guid cid, 		[MarshalAs(UnmanagedType.LPStruct)]
Guid iid);
	}

	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9FD93CCF-3280-4391-B3A9-96E1CDE77C8D")]
	private interface IStrongName
	{
		void M1();
		void M2();
		void M3();
		void M4();
		void M5();
		void M6();
		void M7();
		void M8();
		void M9();
		void M10();
		void M11();
		void M12();
		void M13();
		void M14();
		void M15();
		void M16();
		void M17();
		void M18();
		void M19();
		void M20();
		int StrongNameSignatureVerificationEx(string filePath, bool force, ref bool genuine);
	}

}

static internal class LicenseGlobal
{

	static internal License Seal = new License();

	static internal bool LicenseInitialize;
}

internal enum LicenseType : byte
{
	Free = 0,
	Bronze = 1,
	Silver = 2,
	Gold = 3,
	Platinum = 4,
	Diamond = 5
}

[Flags()]
internal enum RuntimeProtection : byte
{
	None = 0,
	Debuggers = 1,
	DebuggersEx = 2,
	Timing = 4,
	Parent = 8,
	FullScan = 15,
	VirtualMachine = 16
}

internal struct NewsPost
{
	private readonly int _ID;
	public int ID {
		get { return _ID; }
	}

	private readonly string _Name;
	public string Name {
		get { return _Name; }
	}

	private readonly System.DateTime _Time;
	public System.DateTime Time {
		get { return _Time; }
	}

	public NewsPost(object id, object name, object time)
	{
		_ID = (int)id;
		_Name = (string)name;
		_Time = (System.DateTime)time;
	}
}

internal sealed class CookieClient : WebClient
{

	private HttpWebRequest Request;

	public CookieContainer Cookies = new CookieContainer();
	protected override WebRequest GetWebRequest(Uri address)
	{
		Request = (HttpWebRequest)base.GetWebRequest(address);
		Request.Timeout = 8000;
		Request.ReadWriteTimeout = 30000;
		Request.KeepAlive = false;
		Request.CookieContainer = Cookies;
		Request.Proxy = null;
		return Request;
	}

	public void ClearCookies()
	{
		Cookies = new CookieContainer();
	}

}