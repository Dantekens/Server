using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal static class CreateTcpSockets
    {
        static public TcpListener PersonalSockets(string ip, int port) => new TcpListener(IPAddress.Parse(ip), port);
        static public TcpListener LocalhostSockets(int port) => new TcpListener(IPAddress.Parse("127.0.0.1"), port);
    }
}
