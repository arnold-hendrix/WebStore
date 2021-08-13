using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebStoreServer
{
    public class WebStoreClientHandler
    {
        private static IList<string> products = new List<string>() {"Bread", "Cereal", "Butter", "Avocados", "Olive oil", "Toothpaste" };
        // ststic field for products to keep one copy.
        private static IDictionary<string, int> productInventory = GetProducts();  // I removed it from constructor because I realized
        // the random values were resetting with every new instance.
        private static IList<string> customerOrders = new List<string>();
        private static string userName;
        private static IDictionary<int, string> customerAccount = new Dictionary<int, string>()
        {
            { 1000, "arnold"},
            { 1001, "hendrix"},
            { 1002, "arnold-hendrix"},
        };
        private static IList<WebStoreClientHandler> CurrentClients { get; } = new List<WebStoreClientHandler>();
        private readonly TcpClient tcpClient;
        private readonly CancellationToken cancellationToken;
        public WebStoreClientHandler(TcpClient _tcpClient, CancellationToken _cancellationToken)
        {
            tcpClient = _tcpClient;
            cancellationToken = _cancellationToken;
            // productInventory = GetProducts();
            CurrentClients.Add(this);
        }

        public void Connect()
        {
            int accountNum = 0;
            List<string> productList = new List<string>();

            using (tcpClient)
            {
                try
                {
                    NetworkStream stream = tcpClient.GetStream();
                    StreamReader reader = new StreamReader(stream);
                    StreamWriter writer = new StreamWriter(stream);
                    cancellationToken.Register(stream.Close);
                    while (!cancellationToken.IsCancellationRequested)  // runs until thread is cancelled.
                    {
                        string accountNo = reader.ReadLine();  // read user account input.
                        if (Int32.TryParse(accountNo, out int num))  // input verification.
                        {
                            accountNum = num;
                            if (customerAccount.ContainsKey(accountNum))  // if the entered account number exists.
                            {
                                userName = customerAccount[accountNum];  // return user name associated with account number.
                                Console.WriteLine($"CONNECTED: {userName}");
                                writer.WriteLine(userName);  // send user name to client.
                                writer.Flush();
                                foreach (KeyValuePair<string, int> pair in productInventory)
                                {
                                    productList.Add($"{pair.Key},{pair.Value}");
                                }
                                Console.WriteLine("PRODUCTS:" + string.Join("|", productList));
                                writer.WriteLine("PRODUCTS:" + string.Join("|", productList));  // send product list to client.
                                writer.Flush();
                                while (!cancellationToken.IsCancellationRequested)  // listen for client orders unless session is ended.
                                {
                                    string order = reader.ReadLine();  // receive client order.
                                    if (productInventory.ContainsKey(order))  // check if the order exists in inventory.
                                    {
                                        if (productInventory[order] > 0)  // ensure there is at least one quantity left of order
                                        {
                                            customerOrders.Add($"{order},1,{userName}");  // create record of order.
                                            productInventory[order]--;
                                            Console.WriteLine("DONE");
                                            Console.WriteLine("ORDERS:" + string.Join("|", customerOrders));
                                            writer.WriteLine("ORDERS:" + string.Join("|", customerOrders));
                                            writer.Flush();
                                        }
                                        else  // error message if product quantity is 0.
                                        {
                                            Console.WriteLine("NOT_AVAILABLE");
                                            writer.WriteLine("NOT_AVAILABLE");
                                            writer.Flush();
                                        }
                                    }
                                    else // error message for invalid product orders.
                                    {
                                        Console.WriteLine("NOT_VALID");
                                        writer.WriteLine("NOT_VALID");
                                        writer.Flush();
                                    }
                                }
                            }
                            else  // error message for invalid account number.
                            {
                                Console.WriteLine("CONNECT_ERROR");
                                writer.WriteLine("CONNECT_ERROR");
                                writer.Flush();
                            }
                        }
                        else  // error message for invalid account number.
                        {
                            Console.WriteLine("CONNECT_ERROR");
                            writer.WriteLine("CONNECT_ERROR");
                            writer.Flush();
                        }              
                    }
                }
                catch (IOException) // Exception takes us out of the loop, so client handler thread will end
                {
                    Console.WriteLine("DISCONNECT");
                }
                catch (ObjectDisposedException)
                {
                    Console.WriteLine("DISCONNECT"); // May occur if read  or write is attempted after stream is closed
                }
                catch (OutOfMemoryException)
                {
                    // Catch buffer overflow exception
                    // Connection will close upon leaving the using block
                }
                finally
                {
                    CurrentClients.Remove(this);  // remove current client after session ends.
                }
            }
        }
        private static IDictionary<string, int> GetProducts()  // get products with random inventory amount
        {
            IDictionary<string, int> productInventory = new Dictionary<string, int>();
            Random rand = new Random();
            foreach(var product in products)
            {
                productInventory.Add(product, rand.Next(1, 4));
            }
            return productInventory;
        }
    }
}
