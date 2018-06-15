using HttpValidatorApplication;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace HTTPServerApplication
{
    class HTTPServer
    {
        private int port;
        string path;
        TcpListener listener;

        public HTTPServer(int clientPort, string clientPath)
        {
            port = clientPort;
            path = clientPath;
        }

        void Start()
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

        static string HelpFunction()
        {
            string result = "Introduce a valid port number and a path directory:\n" +
                            "ex.:100 C:\\Users\\ii\\Desktop\\Programming\\JMTests\\Server";
            return result;
        }

        public static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Introduce a PORT number and a PATH directory");
                Console.WriteLine(HelpFunction());
                return;
            }

            if (!int.TryParse(args[0], out int c))
            {
                Console.WriteLine("Port must be a valid number");
                Console.WriteLine(HelpFunction());
                return;
            }

            if (!Directory.Exists(args[1]))
            { 
                Console.WriteLine("The introduced PATH directory does not exist");
                Console.WriteLine(HelpFunction());
                return;
            }

            HTTPServer server = new HTTPServer(Convert.ToInt32(args[0]), args[1]);
            Console.WriteLine("Server started succesfully");
            server.Start();
            
        }
    }
}
