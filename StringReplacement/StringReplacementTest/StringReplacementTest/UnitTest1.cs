using System;
using Xunit;

namespace StringReplacementTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string input = "abcd";
            string replacement = "gg";
            Assert.Equal("aggcd", ElementReplacement(input, replacement, 1));

        }

        string ElementReplacement(string input,string replacement, int n)
        {
            string result = string.Empty;
            if (result.Length== n)          
                result+= replacement;
            if (result.Length < input.Length + replacement.Length)            
                return result+=input[0] + ElementReplacement(input.Substring(0,input.Length-1), replacement, n);
            else
                return result;
        }

    }
}
