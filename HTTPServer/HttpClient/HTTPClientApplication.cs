using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpClient
{
    class HTTPClientProgram
    {
        static void ConnectClient(string server, string message)
        {
            using (TcpClient client = new TcpClient("127.0.0.1", 2000))
            {
                byte[] data = Encoding.ASCII.GetBytes(message);

                using (NetworkStream stream = client.GetStream())
                {
                    stream.Write(data, 0, data.Length);
                    int bytes = 0;
                    string responseData = String.Empty;
                    do
                    {
                        data = new Byte[256];
                        bytes = stream.Read(data, 0, data.Length);
                        responseData += Encoding.ASCII.GetString(data, 0, bytes);
                    } while (bytes > 0);
                    Console.WriteLine("Received: {0}", responseData);
                }
            }
        }

        static void Main(string[] args)
        {
            string host;
            string message = "GET / HTTP/1.1";

            if (args.Length == 0)
                host = Dns.GetHostName();
            else
                host = args[0];

            ConnectClient(host, message);

            Console.Read();
        }
    } 
}
