using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebStoreClient
{
    public class WebStoreServerHandler
    {
        public string HostName { get; set; } = "localhost"; // Default host name
        public int HostPort { get; set; } = 55055;  // port number
        private TcpClient tcpClient = null;
        public StreamReader reader;
        public StreamWriter writer;
        public bool IsClosed => null == tcpClient;

        public void Start()  // connect tcp client
        {
            try
            {
                tcpClient = new TcpClient(); // assign new tcp client
                tcpClient.Connect(HostName, HostPort);  // attempt to connect to server
                NetworkStream stream = tcpClient.GetStream();  // get IO stream
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);
            }
            catch (SocketException se)  // connection error exception.
            {
                tcpClient = null;
                throw new InvalidOperationException("Server Unavailable", se);
            }
        }
        public void Exit()
        {
            tcpClient?.Close();
            tcpClient = null;  // set tcp client to null to end connection.
        }
    }
}
