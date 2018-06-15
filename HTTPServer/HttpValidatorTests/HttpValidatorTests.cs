using HttpValidatorApplication;
using Patterns;
using System.Collections.Generic;
using Xunit;

namespace HttpValidatorTests
{
    public class HttpValidatorTests
    {
        [Fact]
        public void Test()
        {
            var value = new HttpValidator();

            Assert.Equal((new SuccesMatch("GET /kk/kk HTTP/1.1\r\nHost   :   127.0.0.1:2000\r\ntext: 1\r\n\r\n"), ""), 
                          value.Match("GET /kk/kk HTTP/1.1\r\nHost   :   127.0.0.1:2000\r\ntext: 1\r\n\r\n"));
        }

        [Fact]
        public void SecondTest()
        {
            var value = new HttpValidator();

            Assert.Equal((new SuccesMatch("GET / HTTP/1.1\r\nHost: 127.0.0.1:2000\r\ntext: 1\r\ntext2: 2\r\n\r\n"), ""),
                          value.Match("GET / HTTP/1.1\r\nHost: 127.0.0.1:2000\r\ntext: 1\r\ntext2: 2\r\n\r\n"));
        }

        [Fact]
        public void FalseTest()
        {
            var value = new HttpValidator();

         //  Assert.Equal((new NoMatch(), "GET / HTTP/1.1\r\n Host: 127.0.0.1:2000 text text: 1\r\n\r\n"), 
         //                   value.Match("GET / HTTP/1.1\r\n Host: 127.0.0.1:2000 text text: 1\r\n\r\n"));
        }

        [Fact]
        public void EndTest()
        {
            var value = new HttpValidator();

            Assert.Equal((new SuccesMatch("GET / HTTP/1.1\r\nHost: 127.0.0.1:2000\r\n\r\n"), ""), 
                              value.Match("GET / HTTP/1.1\r\nHost: 127.0.0.1:2000\r\n\r\n"));
        }

    }
}
