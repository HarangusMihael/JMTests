using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerApplication
{
    class ServerClass
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var host = Dns.GetHostName();
            IPAddress adress = IPAddress.Parse("127.0.0.1");
            IPEndPoint endpoint = new IPEndPoint(adress, 2000);
            serverSocket.Bind(endpoint);
            serverSocket.Listen(10);
            while (true)
            {
                var clientSocket = serverSocket.Accept();
                byte[] bytesReceived = new byte[8];
                var bytesRead = 0;
                string recieved = null;
                do
                {
                    if (clientSocket.Available == 0)
                        break;
                    bytesRead = clientSocket.Receive(bytesReceived, bytesReceived.Length, 0);
                    recieved = recieved + Encoding.ASCII.GetString(bytesReceived, 0, bytesRead);
                } while (bytesRead > 0);

                Console.WriteLine(recieved);
                var payload = "<h1>Test</h1>";
                var bytesToSend = Encoding.ASCII.GetBytes($"HTTP 200 OK\r\nContent-Length: {payload.Length}\r\nConnection: close\r\n\r\n" + payload);                
                clientSocket.Send(bytesToSend);
                clientSocket.Close();
            }
        }
    }
}
