using System;
using Json;

namespace JsonValid
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[0]);
            
            var value = new Value();

            var (itemMatch, itemValue) = value.Match(text);

            Console.WriteLine("{0} {1}", itemMatch, itemValue);
            Console.Read();
        }
    }
}
