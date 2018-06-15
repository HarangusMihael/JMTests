using HttpValidatorApplication;
using Patterns;
using System;
using System.Text;
using Xunit;

namespace HttpValidatorTests
{
    public class ControllerTest
    {
        [Fact]
        public void StatusTest()
        {
            Controller controller = new Controller(new MockDisk());
            
            var value = new HttpRequestPattern();

            var (match, remaining) = value.Match("GET /test.htm HTTP/1.1\r\n");

            var response = controller.Process(((HttpRequestMatch)match).Request);
                       
            Assert.Equal(ResponseTypes.OK, response.Type);
        }

        [Fact]
        public void NotFoundStatusTest()
        {
            Controller controller = new Controller(new MockDisk());

            var value = new HttpRequestPattern();

            var (match, remaining) = value.Match("GET /test/index.html HTTP/1.1\r\n");

            var response = controller.Process(((HttpRequestMatch)match).Request);

            Assert.Equal(ResponseTypes.NotFound, response.Type);
        }

        [Fact]
        public void BadRequestTest()
        {
            Controller controller = new Controller(new MockDisk());

            var value = new HttpRequestPattern();

            var (match, remaining) = value.Match("PUT /test.htm HTTP/1.1\r\n");

            var response = controller.Process(((HttpRequestMatch)match).Request);

            Assert.Equal(ResponseTypes.BadRequest, response.Type);
        }

        [Fact]
        public void ResponseTest()
        {
            Controller controller = new Controller(new MockDisk());

            var value = new HttpRequestPattern();

            var (match, remaining) = value.Match("GET /test.htm HTTP/1.1\r\n");

            var response = controller.Process(((HttpRequestMatch)match).Request);       

            Assert.Equal("HTTP/1.1 200 OK\r\nContent-Length: 0\r\n\r\n", Encoding.UTF8.GetString(response.Result));
        }
    }
}
