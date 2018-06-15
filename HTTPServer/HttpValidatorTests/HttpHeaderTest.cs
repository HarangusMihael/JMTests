using HttpValidatorApplication;
using System.Collections.Generic;
using Xunit;

namespace HttpValidatorTests
{
    public class HttpHeaderTest
    {
        [Fact]
        public void Test()
        {
            var header = new HttpHeaderPattern();

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            dictionary.Add("Host", " 127.0.0.1");
            dictionary.Add("text", " 1");

            var result = new HttpHeaderMatch(dictionary);

            Assert.Equal((result, ""), header.Match("Host: 127.0.0.1\r\ntext: 1\r\n\r\n"));
        }
    }
}
