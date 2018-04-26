using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer
{
    public class Program
    {
        private static Socket ConnectSocket(string server, int port)
        {
            Socket socket = null;
            IPHostEntry hostInfo = Dns.GetHostEntry(server);

            IPAddress adress = IPAddress.Parse("127.0.0.1");

            IPEndPoint endpoint = new IPEndPoint(adress, port);
            Socket tempSocket = new Socket(endpoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            tempSocket.Connect(endpoint);

            if (tempSocket.Connected)
            {
                socket = tempSocket;
            }

            return socket;
        }

        private static string SocketSendReceive(string server, int port)
        {
            string request = "GET / HTTP/1.1\r\nHost: " + server +
                "\r\nConnection: Close\r\n\r\n";
            Byte[] bytesSent = Encoding.UTF8.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];

            Socket socket = ConnectSocket(server, port);

            socket.Send(bytesSent, bytesSent.Length, 0);
            int bytes = 0;
            string page = "Default HTML page on " + server + ":\r\n";

            do
            {
                bytes = socket.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0);

            return page;
        }

        static void Main(string[] args)
        {
            string host;
            int port = 2000;

            if (args.Length == 0)
                host = Dns.GetHostName();
            else
                host = args[0];

            string result = SocketSendReceive(host, port);
            Console.WriteLine(result);
            Console.Read();
        }
    }
}
