using HttpValidatorApplication;
using System;
using System.Collections.Generic;
using Xunit;

namespace HttpValidatorTests
{
    public class RequestTest
    {
        [Fact]
        public void Test()
        {
            var request = new HttpRequestPattern();

            var requestToMatch = request.Match("GET http://142.42.1.1 HTTP/1.1\r\nHost: 127.0.0.1:2000\r\ntext: 1\r\n\r\n");

            var result = (HttpRequestMatch)requestToMatch.Item1;

            HttpMethod method = HttpMethod.Get;
            HttpMethod falseMethod = HttpMethod.Put;

            Uri url = (new UrlMatch("http://142.42.1.1")).Uri;
            Uri falseUrl = (new UrlMatch("http://142.42.1")).Uri;

            Dictionary<string, string> header = new Dictionary<string, string>();
            header.Add("Host", " 127.0.0.1:2000");
            header.Add("text", " 1");

            Dictionary<string, string> falseHeader = new Dictionary<string, string>();
            falseHeader.Add("Host", " 127.0.0.1:2000");
            falseHeader.Add("tet", " 1");


            Assert.Equal(method, result.Request.Method);
            Assert.NotEqual(falseMethod, result.Request.Method);
            Assert.Equal(url, result.Request.Uri);
            Assert.NotEqual(falseUrl, result.Request.Uri);
            Assert.Equal(header, result.Request.Headers);
            Assert.NotEqual(falseHeader, result.Request.Headers);
        }
    }
}
