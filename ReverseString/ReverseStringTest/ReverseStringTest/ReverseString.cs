using System;
using Xunit;

namespace ReverseStringTest
{
    public class ReverseStringTest
    {
        [Fact]
        public void Test1()
        {
            string input = "abc";
            Assert.Equal("cba", ReverseString(input));
        }

        string ReverseString(string input)
        {
            if (input.Length > 0)
                return input[input.Length - 1] + ReverseString(input.Substring(0, input.Length - 1));
            else
            return input;
        }

    }
}
