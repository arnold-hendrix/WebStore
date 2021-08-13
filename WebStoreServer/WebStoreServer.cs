using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStoreServer
{
    public class WebStoreServer
    {
        private readonly CancellationToken cancellationToken;
        public IPAddress ServerIp { get; set; } = IPAddress.Any; // Default to any local ip
        public int ServerPort { get; set; } = 55055; // Default to port 55055
        public WebStoreServer(CancellationToken _cancellationToken) => cancellationToken = _cancellationToken;
        public void Start()
        {
            try
            {
                TcpListener listener = new TcpListener(ServerIp, ServerPort);
                listener.Start(); // Once the listener is started, the client can connect and send data.  More than one client can connect.
                cancellationToken.Register(listener.Stop); // Stop the server port listener if a cancellation is requested
                while (!cancellationToken.IsCancellationRequested)
                {
                    TcpClient tcpClient = listener.AcceptTcpClient(); // Get the next ready client connection, or wait for a client connection if no new clients are connected
                    WebStoreClientHandler wsClientHandler = new WebStoreClientHandler(tcpClient, cancellationToken);  // client handler object.
                    Thread clientHandlerThread = new Thread(wsClientHandler.Connect);
                    clientHandlerThread.Start();  // run tcp client Start method from a new thread.
                }
            }
            catch (SocketException) // Exception takes us out of the loop, server connection handler thread will end
            {
                // SocketException may occur when listener is started or stopped
            }
        }

    }
}
