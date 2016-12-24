using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace Networking
{
    public class Socket : IDisposable
    {
        private IntPtr _Handle;
        private ws2_32.ProtocolType _protocol;
        private ws2_32.SocketType _type;
        private ws2_32.AddressFamily _family;
        private string _RemoteIp;
        private uint _Port;

        public uint ReceiveBufferSize;
        public uint SendBufferSize;

        public const uint DefaultBufferSize = 8192;
        private ws2_32.sockaddr_in _AddrRemoteAddress;
        private bool _Listening;
        private bool _Connected;

        public IntPtr Handle
        {
            get { return this._Handle; }
            protected set { this._Handle = value; }
        }
        public ws2_32.ProtocolType protocol
        {
            get { return this._protocol; }
            protected set { this._protocol = value; }
        }
        public ws2_32.SocketType type
        {
            get { return this._type; }
            protected set { this._type = value; }
        }
        public ws2_32.AddressFamily family
        {
            get { return this._family; }
            protected set { this._family = value; }
        }
        public string RemoteIp
        {
            get { return this._RemoteIp; }
            protected set { this._RemoteIp = value; }
        }
        public uint Port
        {
            get { return this._Port; }
            protected set { this._Port = value; }
        }
        public ws2_32.sockaddr_in AddrRemoteAddress
        {
            get { return this._AddrRemoteAddress; }
            protected set { this._AddrRemoteAddress = value; }
        }
        public bool Listening
        {
            get { return this._Listening; }
            protected set { this._Listening = value; }
        }
        public bool Connected
        {
            get { return this._Connected; }
            protected set { this._Connected = value; }
        }

        /// <summary>
        /// Used to make a stable connection, default: false, Header size is 4 bytes
        /// </summary>
        public bool EnableSizeHeader;

        /// <summary> The length of the header size </summary>
        public HeaderTypeSize HeaderSize = HeaderTypeSize.SHORT;
        public enum HeaderTypeSize : int
        {
            BYTE = 1,
            SHORT = 2,
            INT = 4,
        }

        public Socket(ws2_32.AddressFamily family, ws2_32.ProtocolType protocol, ws2_32.SocketType type)
        {
            this.protocol = protocol;
            this.type = type;
            this.family = family;
        }

        /// <summary></summary>
        /// <param name="Handle">The handle of an already existing connection</param>
        public Socket(ws2_32.AddressFamily family, ws2_32.ProtocolType protocol, ws2_32.SocketType type, IntPtr Handle)
            : this(family, protocol, type)
        {
            this.Handle = Handle;
        }

        /// <summary></summary>
        /// <param name="Handle">The handle of an already existing connection</param>
        public Socket(ws2_32.AddressFamily family, ws2_32.ProtocolType protocol, ws2_32.SocketType type, IntPtr Handle, uint SendBufferSize, uint ReceiveBufferSize)
            : this(family, protocol, type, Handle)
        {
            this.SendBufferSize = SendBufferSize;
            this.ReceiveBufferSize = ReceiveBufferSize;
        }

        //New client - Server Accepted
        internal unsafe Socket(ws2_32.AddressFamily family, ws2_32.ProtocolType protocol, ws2_32.SocketType type,
                      IntPtr Handle, ws2_32.sockaddr_in addr, HeaderTypeSize headerSize, uint SendBufferSize, uint ReceiveBufferSize)
            : this(family, protocol, type, Handle)
        {
            this.SendBufferSize = SendBufferSize;
            this.ReceiveBufferSize = ReceiveBufferSize;
            this.RemoteIp = Marshal.PtrToStringAnsi(new IntPtr(ws2_32.inet_ntoa(addr.sin_addr)));
            this.Port = (uint)ws2_32.ntohs(addr.sin_port);
            this.HeaderSize = headerSize;
        }

        /// <summary>This function returns the accepted connection that has been made by a client</summary>
        /// <returns>The accepted connection</returns>
        public virtual Socket Accept()
        {
            if (this.Handle.ToInt32() == 0)
                throw new Exception("The socket handle was invalid");

            ws2_32.sockaddr_in addr = new ws2_32.sockaddr_in();
            int dwSize = Marshal.SizeOf(addr);

            IntPtr CHandle = ws2_32.accept(this.Handle, ref addr, ref dwSize);
            Socket sock = new Socket(family, protocol, type, CHandle, addr, this.HeaderSize, this.SendBufferSize, this.ReceiveBufferSize);
            sock.Connected = true;
            sock.EnableSizeHeader = this.EnableSizeHeader;
            return sock;
        }

        /// <summary> </summary>
        /// <param name="IpAddress">Default: 0.0.0.0</param>
        /// <param name="port"></param>
        public virtual bool Bind(string IpAddress, ushort port)
        {
            ws2_32.sockaddr_in addr = new ws2_32.sockaddr_in();
            addr.sin_family = (short)family;
            addr.sin_port = ws2_32.htons(port);
            addr.sin_addr = (int)ws2_32.inet_addr(IpAddress);

            int result = ws2_32.bind(this.Handle, ref addr, Marshal.SizeOf(addr));

            if (result == 0)
            {
                this.Port = port;
                this.AddrRemoteAddress = addr;
                return true;
            }
            else
            {
                throw new Exception("Unable to bind at port: " + port);
            }
        }
        public virtual bool Listen(int Backlog)

        {
            if (this.Handle.ToInt32() == 0)
                throw new Exception("INVALID_SOCKET");

            if (ws2_32.listen(this.Handle, Backlog) == 0)
            {
                Listening = true;
                return true;
            }
            return false;
        }

        /// <summary> Initialize the handle for the socket connection </summary>
        /// <returns></returns>
        public virtual bool Initialize()
        {
            ws2_32.WSAData wsaData = new ws2_32.WSAData();
            wsaData.Version = 2;
            wsaData.HighVersion = 2;

            if (ws2_32.WSAStartup(36, out wsaData) == 0) //0=success
            {
                bool success = false;
                while (!success)
                {
                    try
                    {
                        this.Handle = ws2_32.WSASocket(family, type, protocol, IntPtr.Zero, 0, ws2_32.SocketConstructorFlags.WSA_FLAG_OVERLAPPED);

                        if (this.Handle.ToInt32() == ws2_32.INVALID_SOCKET)
                            throw new Exception("INVALID_SOCKET");

                        this.SendBufferSize = DefaultBufferSize;
                        this.ReceiveBufferSize = DefaultBufferSize;
                        success = true;
                    }
                    catch (Exception ex)
                    {
                        GlobalVariables.DumpErrorLog(ex);
                    }
                }
                return true;
            }
            else
            {
                throw new Exception("WSAStartup was unsuccessfully started");
            }
        }

        public virtual bool Initialize(uint ReceiveBufferSize, uint SendBufferSize)
        {
            if (Initialize())
            {
                this.ReceiveBufferSize = ReceiveBufferSize;
                this.SendBufferSize = SendBufferSize;
                return true;
            }
            return false;
        }

        public virtual bool Connect(string remoteIp, ushort port)
        {
            ws2_32.sockaddr_in addr = new ws2_32.sockaddr_in();
            addr.sin_family = (short)family;
            addr.sin_port = ws2_32.htons(port);
            addr.sin_addr = (int)ws2_32.inet_addr(remoteIp);

            int ret = ws2_32.connect(this.Handle, ref addr, Marshal.SizeOf(addr));
            if (ret == 0)
                Connected = true;
            this.RemoteIp = remoteIp;
            return (ret == 0);
        }

        /// <summary> This function will try to connect to the remote server,
        /// When the connection is made your code will continue </summary>
        public virtual void ConnectEx(string remoteIp, ushort port)
        {
            while (!Connected)
                Connect(remoteIp, port);
        }

        /// <summary> This function will try to connect to the remote server,
        /// When the connection is made a packet will be send your code will continue </summary>
        public virtual void ConnectEx(string remoteIp, ushort port, byte[] payload)
        {
            while (!Connected)
                Connect(remoteIp, port);
            SendPacket(payload);
        }

        private unsafe int _SendPacket(byte[] payload, ws2_32.SocketFlags flag, bool async)
        {
            if (!Connected)
                return -1;

            if (EnableSizeHeader)
            {
                if (HeaderSize == HeaderTypeSize.BYTE && payload.Length > 255)
                    throw new Exception("Payload cannot be bigger then 255 bytes, Recheck the HeaderSize");
                else if (HeaderSize == HeaderTypeSize.INT && payload.Length > int.MaxValue)
                    throw new Exception("Payload cannot be bigger then " + int.MaxValue + " bytes, Recheck the HeaderSize");
                else if (HeaderSize == HeaderTypeSize.SHORT && payload.Length > 65535)
                    throw new Exception("Payload cannot be bigger then 65535 bytes, Recheck the HeaderSize");

                byte[] HeaderBuffer = new byte[(int)HeaderSize];
                switch (HeaderSize)
                {
                    case HeaderTypeSize.BYTE:
                        HeaderBuffer = BitConverter.GetBytes((byte)payload.Length);
                        break;
                    case HeaderTypeSize.INT:
                        HeaderBuffer = BitConverter.GetBytes((int)payload.Length);
                        break;
                    case HeaderTypeSize.SHORT:
                        HeaderBuffer = BitConverter.GetBytes((short)payload.Length);
                        break;
                }

                //Send header
                int DataSend = 0;
                fixed (byte* x = HeaderBuffer)
                {
                    int ret = ws2_32.send(this.Handle, x, HeaderBuffer.Length, (int)flag);

                    if (ret <= 0)
                    {
                        Disconnect();
                        return 0;
                    }

                    DataSend += ret;
                }

                //Send our data
                byte[] buffer = new byte[0];
                for (uint i = 0; i < payload.Length; i += SendBufferSize)
                {
                    if ((i + SendBufferSize) <= payload.Length)
                        buffer = new byte[SendBufferSize];
                    else
                        buffer = new byte[payload.Length - i];

                    Array.Copy(payload, i, buffer, 0, buffer.Length);

                    fixed (byte* x = buffer)
                    {
                        int ret = ws2_32.send(this.Handle, x, buffer.Length, (int)flag);
                        if (ret <= 0)
                        {
                            Disconnect();
                            return 0;
                        }
                        DataSend += ret;
                    }
                }
                return DataSend;
            }
            else
            {
                fixed (byte* x = payload)
                    return ws2_32.send(this.Handle, x, payload.Length, (int)flag);
            }
        }

        /// <summary> send a packet to the remote server </summary>
        /// <param name="payload">The bytes that you want to sent</param>
        /// <returns>The length of the packet that has been sent</returns>
        public virtual int SendPacket(byte[] payload)
        {
            return _SendPacket(payload, ws2_32.SocketFlags.None, false);
        }

        /// <summary> send a packet to the remote server </summary>
        /// <param name="payload">The bytes that you want to sent</param>
        /// <returns>The length of the packet that has been sent</returns>
        public virtual int SendPacket(byte[] payload, ws2_32.SocketFlags flag)
        {
            return _SendPacket(payload, flag, false);
        }

        private unsafe byte[] _Receive(ws2_32.SocketFlags flag)
        {
            List<Byte> payload = new List<Byte>();
            if (EnableSizeHeader)
            {
                int PayloadSize = 0;
                byte[] xSize = Receive((uint)HeaderSize);

                if (xSize.Length <= 0)
                {
                    return new byte[] { };
                }

                try
                {
                    switch (HeaderSize)
                    {
                        case HeaderTypeSize.BYTE:
                            PayloadSize = xSize[0];
                            break;
                        case HeaderTypeSize.INT:
                            PayloadSize = BitConverter.ToInt32(xSize, 0);
                            break;
                        case HeaderTypeSize.SHORT:
                            PayloadSize = BitConverter.ToInt16(xSize, 0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    GlobalVariables.DumpErrorLog(ex);
                    //Overflow exception, We have been attacked!
                    Disconnect();
                    return new byte[] { };
                }

                if (PayloadSize < 0)
                {
                    Disconnect();
                    return new byte[] { };
                }

                //Read the whole packet
                payload.AddRange(Receive((uint)PayloadSize));

                if (!Connected)
                {
                    Disconnect();
                    return new byte[] { };
                }
            }
            else
            {
                //Just read the data we are receiving
                byte[] bytes = new byte[ReceiveBufferSize];
                int recv = 0;
                fixed (byte* x = bytes)
                    recv = ws2_32.recv(this.Handle, x, bytes.Length, (int)flag);

                if (recv <= 0)
                {
                    Disconnect();
                    return new byte[] { };
                }

                Array.Resize(ref bytes, recv);
                payload.AddRange(bytes);
            }
            return payload.ToArray();
        }

        public virtual byte[] Receive()
        {
            return _Receive(ws2_32.SocketFlags.None);
        }

        public virtual byte[] Receive(ws2_32.SocketFlags flag)
        {
            return _Receive(flag);
        }

        public unsafe virtual byte[] Receive(uint length)
        {
            List<Byte> payload = new List<Byte>();
            int received = 0;
            uint BytesLeft = length;
            byte[] ReceivedBytes = new byte[0];

            while (true)
            {
                ReceivedBytes = new byte[BytesLeft]; //<- vulnerability
                fixed (byte* x = ReceivedBytes)
                {
                    received = ws2_32.recv(this.Handle, x, (int)BytesLeft, 0);
                }

                if (received <= 0)
                {
                    Disconnect();
                    return new byte[0];
                }

                Array.Resize(ref ReceivedBytes, received);
                BytesLeft -= (uint)received;
                payload.AddRange(ReceivedBytes);

                if (BytesLeft == 0)
                    break;
            }
            return payload.ToArray();
        }

        public virtual void Disconnect()
        {
            this.Connected = false;
            this.Listening = false;
            ws2_32.closesocket(this.Handle);
        }

        public virtual void Stop()
        {
            this.Listening = false;
        }

        public virtual void Dispose()
        {
            if (Handle.ToInt32() != 0)
            {
                this.Listening = false;
                this.Connected = false;
                ws2_32.closesocket(Handle);
                ws2_32.WSACleanup();
            }
        }

        public virtual SocketError SetSocketOption(SocketOptionLevel level, SocketOptionName name, int value)
        {
            if (this.Handle == IntPtr.Zero)
                throw new Exception("INVALID_SOCKET");

            int val = value;
            return ws2_32.setsockopt(this.Handle, level, name, ref val, Marshal.SizeOf(value));
        }
    }
}