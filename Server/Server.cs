using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Server
{
    internal class Server
    {

        private ConcurrentDictionary<TcpClient, StreamWriter> allSesion = new ConcurrentDictionary<TcpClient, StreamWriter>();
        readonly TcpListener TcpServer;

        public Server(TcpListener tcpListener)
        {
            TcpServer = tcpListener;
        }

        public void Start()
        {
            TcpServer.Start();
            Task.Run(AcceptClient);
        }

        private async Task AcceptClient()
        {
            TcpClient client = await TcpServer.AcceptTcpClientAsync();
            _ = Task.Run(() => { SessionClient(client); });

        }
        private async Task SessionClient(TcpClient client)
        {
            using (client)
            {
                using (NetworkStream stream = client.GetStream())
                using(StreamReader reader = new StreamReader(stream, UnicodeEncoding.UTF8)) 
                using(StreamWriter writer = new StreamWriter(stream, UnicodeEncoding.UTF8) {AutoFlush = true })
                {
                    allSesion.TryAdd(client, writer);
                    try
                    {
                        string text;
                        while ((text = await reader.ReadLineAsync()) != null) 
                        {
                            Broadcast(text, writer);
                        }
                    }
                    finally
                    {
                    }
                }
            }
        }
        private void Broadcast(string mess, StreamWriter stream)
        {
            foreach (var item in allSesion.Values) 
            {
                if(item != stream)
                {
                    stream.WriteLine(mess);
                }
            }
        }
    }
}
