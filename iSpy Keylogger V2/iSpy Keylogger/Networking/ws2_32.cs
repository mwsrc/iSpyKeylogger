using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace Networking
{
    public class ws2_32
    {
        public const int SOCKET_ERROR = -1;
        public const int INVALID_SOCKET = ~0;

        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern Int32 WSACleanup();
        [DllImport("Ws2_32.dll")]
        public static extern int WSAStartup(ushort Version, out WSAData Data);
        [DllImport("Ws2_32.dll")]
        public static extern SocketError WSAGetLastError();
        [DllImport("Ws2_32.dll")]
        public static extern IntPtr socket(AddressFamily af, SocketType type, ProtocolType protocol);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern int send(IntPtr SocketHandle, byte[] buf, int len, int flags);
        [DllImport("Ws2_32.dll")]
        public static extern int recv(IntPtr SocketHandle, byte[] buf, int len, int flags);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern int send([In] IntPtr s, [In] byte* buf, [In] int len, [In] int flags);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern int recv([In] IntPtr s, [Out] byte* buf, [In] int len, [In] int flags);
        [DllImport("ws2_32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr accept(IntPtr socketHandle, ref sockaddr_in socketAddress, ref int addressLength);
        [DllImport("Ws2_32.dll")]
        public static extern int listen(IntPtr s, int backlog);
        [DllImport("Ws2_32.dll", CharSet = CharSet.Ansi)]
        public static extern uint inet_addr(string cp);
        [DllImport("Ws2_32.dll")]
        public static extern ushort htons(ushort hostshort);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern int connect(IntPtr SocketHandle, ref sockaddr_in addr, int addrsize);
        [DllImport("Ws2_32.dll")]
        public static extern int closesocket(IntPtr SocketHandle);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern int getpeername(IntPtr SocketHandle, sockaddr_in* addr, int* addrsize);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern int bind(IntPtr SocketHandle, ref sockaddr_in addr, int namelen);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern sbyte* inet_ntoa(int _in);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern ulong htonl(ulong hostlong);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern ulong ntohl(ulong netlong);
        [DllImport("Ws2_32.dll")]
        public static unsafe extern ushort ntohs(ushort netshort);
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static extern SocketError setsockopt([In] IntPtr socketHandle, [In] SocketOptionLevel optionLevel, [In] SocketOptionName optionName, [In] ref int optionValue, [In] int optionLength);

        [DllImport("ws2_32.dll", CharSet = CharSet.Unicode, SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr WSASocket(AddressFamily af, SocketType socket_type, ProtocolType protocol,
                                              IntPtr lpProtocolInfo, Int32 group, SocketConstructorFlags dwFlags);

        [DllImport("ws2_32.dll", SetLastError = true)]
        public static unsafe extern int sendto(IntPtr Socket, byte* buff, int len, SocketFlags flags, sockaddr_in To, int tolen);
        [DllImport("ws2_32.dll", SetLastError = true)]
        public static unsafe extern int recvfrom(IntPtr Socket, byte* buff, int len, SocketFlags flags, ref sockaddr_in To, int tolen);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public unsafe struct WSAData
        {
            public ushort Version;
            public ushort HighVersion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 257)]
            public string Description;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
            public string SystemStatus;
            public ushort MaxSockets;
            public ushort MaxUdpDg;
            sbyte* lpVendorInfo;
        }

        public enum AddressFamily : int
        {
            Unknown = 0,
            InterNetworkv4 = 2,
            Ipx = 4,
            AppleTalk = 17,
            NetBios = 17,
            InterNetworkv6 = 23,
            Irda = 26,
            BlueTooth = 32
        }
        public enum SocketType : int
        {
            Unknown = 0,
            Stream = 1,
            DGram = 2,
            Raw = 3,
            Rdm = 4,
            SeqPacket = 5
        }
        public enum ProtocolType : int
        {
            BlueTooth = 3,
            Tcp = 6,
            Udp = 17,
            ReliableMulticast = 113
        }

        public unsafe struct fd_set
        {
            public const int FD_SETSIZE = 64;
            public uint fd_count;
            public fixed uint fd_array[FD_SETSIZE];
        }

        [Flags]
        public enum SocketConstructorFlags
        {
            WSA_FLAG_MULTIPOINT_C_LEAF = 4,
            WSA_FLAG_MULTIPOINT_C_ROOT = 2,
            WSA_FLAG_MULTIPOINT_D_LEAF = 0x10,
            WSA_FLAG_MULTIPOINT_D_ROOT = 8,
            WSA_FLAG_OVERLAPPED = 1
        }


        /// <summary>
        /// Internet socket address structure.
        /// </summary>
        public struct sockaddr_in
        {
            /// <summary>
            /// Protocol family indicator.
            /// </summary>
            public short sin_family;
            /// <summary>
            /// Protocol port.
            /// </summary>
            public ushort sin_port;
            /// <summary>
            /// Actual address value.
            /// </summary>
            public int sin_addr;
            /// <summary>
            /// Address content list.
            /// </summary>
            //[MarshalAs(UnmanagedType.LPStr, SizeConst=8)]
            //public string sin_zero;
            public long sin_zero;
        }

        public enum SocketFlags
        {
            Broadcast = 0x400,
            ControlDataTruncated = 0x200,
            DontRoute = 4,
            MaxIOVectorLength = 0x10,
            Multicast = 0x800,
            None = 0,
            OutOfBand = 1,
            Partial = 0x8000,
            Peek = 2,
            Truncated = 0x100
        }
    }
}