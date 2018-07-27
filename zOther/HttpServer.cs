using HttpValidatorApplication;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HttpServer1
{
    public class HttpServer
    {
        private int port;
        string path;
        TcpListener listener;

        public HttpServer(int clientPort, string clientPath)
        {
            port = clientPort;
            path = clientPath;
        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, port);

            listener.Start();

            var value = new HttpRequestPattern();
            var controller = new Controller(new ExternalDisk(path));
            while (true)
            {
                var client = listener.AcceptTcpClient();

                var stream = client.GetStream();

                var (match, remaining) = value.Match(ReadHeaders(stream));
                var response = match.Succes
                    ? controller.Process(((HttpRequestMatch)match).Request)
                    : new Response(ResponseTypes.BadRequest) { Body = "Bad Request" };

                var data = response.Result;
                stream.Write(data, 0, data.Length);
                stream.Close();
            }
        }

        private static string ReadHeaders(NetworkStream stream)
        {
            byte[] bytes = new byte[256];

            string text = "";

            int bytesRead;
            do
            {
                bytesRead = stream.Read(bytes, 0, bytes.Length);
                text += Encoding.ASCII.GetString(bytes, 0, bytesRead);
            } while (!text.Contains("\r\n\r\n") && bytesRead > 0);

            return text;
        }
    }
}
