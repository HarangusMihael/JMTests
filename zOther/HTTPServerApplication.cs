using HttpServer1;
using System;
using System.IO;

namespace HTTPServerApplication
{
    class HttpServerApplication
    { 

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

            HttpServer server = new HttpServer(Convert.ToInt32(args[0]), args[1]);
            Console.WriteLine("Server started succesfully");
            server.Start();
           
        }
    }
}
