using HttpValidatorApplication;
using System.Text;
using Xunit;

namespace HttpValidatorTests
{
    public class ResponseTest
    {
        [Fact]
        public void Test()
        {
            ResponseTypes type = ResponseTypes.OK;

            Response response = new Response(type);

            Assert.Equal("HTTP/1.1 200 OK\r\n\r\n", Encoding.ASCII.GetString(response.Result));
        }

        [Fact]
        public void AddHeadersTest()
        {

            Response response = new Response(ResponseTypes.OK);

            response.AddHeader("Connection", "close");
            

            Assert.Equal("HTTP/1.1 200 OK\r\nConnection: close\r\n\r\n", 
                          Encoding.ASCII.GetString(response.Result));
        }

        [Fact]
        public void ModifyHeaderTest()
        {

            Response response = new Response(ResponseTypes.OK);

            response.AddHeader("Connection", "open");

            byte[] array = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nConnection: open\r\n\r\n");

            Assert.Equal(array, response.Result);
        }

        [Fact]
        public void BodyTest()
        {

            Response response = new Response(ResponseTypes.OK);

            string body = "test";

            response.AddHeader("Connection", "open");
            response.SetBody(body);

            var array = "HTTP/1.1 200 OK\r\nConnection: open\r\nContent-Length: "+ body.Length + "\r\n\r\n" +  body;

            Assert.Equal(array, Encoding.UTF8.GetString(response.Result));
        }
    }
}
