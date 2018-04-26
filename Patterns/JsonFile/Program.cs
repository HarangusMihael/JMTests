using System;
using Json;

namespace JsonFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\ii\Desktop\Programming\JMTests\Patterns\JsonFile\Json.txt");

            var value = new Value();

            var (itemMatch, itemValue) = value.Match(text);

            Console.WriteLine("{0}", itemMatch);
            Console.Read();
        }
    }
}
