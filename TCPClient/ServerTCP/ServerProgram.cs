using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerTCP
{
    class ServerProgram 
    {
        static void Main(string[] args)
        {
            TcpListener server = null;
            IPAddress adress = IPAddress.Parse("127.0.0.1");

            server = new TcpListener(adress, 2000);
         
            server.Start();
            byte[] bytes = new byte[256];
            int bytesRead = 0;
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                bytesRead = stream.Read(bytes, 0, bytes.Length);

                stream.Write(bytes, 0, bytesRead);
                client.Close();
            }
        }

    }
}
