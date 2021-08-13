using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStoreServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            WebStoreServer server = new WebStoreServer(cancellationTokenSource.Token);
            Thread serverThread = new Thread(server.Start);
            serverThread.Start();
            while (serverThread.IsAlive && (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Q))  // shutdown with Q keypress or when thread ends.
                ;
            cancellationTokenSource.Cancel();
            Console.ReadKey();
        }
    }
}
