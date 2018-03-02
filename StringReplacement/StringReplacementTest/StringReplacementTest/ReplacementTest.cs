using System;
using Xunit;

namespace StringReplacementTest
{
    public class StringReplacement
    {
        [Fact]
        public void ReplacementTest()
        {
            string input = "abcd";
            string replacement = "gg";
            Assert.Equal("aggcd", ElementReplacement(input, replacement, "b",""));

        }
        string ElementReplacement(string input,string replacement,string character,string result)
        {
            if (input == "")
                return result;     
            if (Convert.ToString(input[0]) == character)
                return ElementReplacement(input.Substring(1), replacement, character, result += replacement);
            else
                return ElementReplacement(input.Substring(1), replacement, character, result += input[0]);               
        }
    }
}
