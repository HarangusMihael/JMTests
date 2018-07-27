using HttpValidatorApplication;
using Patterns;
using Xunit;

namespace HttpValidatorTests
{
    public class HttpMethodPatternTest
    {
        [Fact]
        public void GetTest()
        {
            var request = new HttpMethodPattern();

            var method = new HttpMethodMatch("GET");

            Assert.Equal((method,""), request.Match("GET"));
            Assert.Equal((method," /"), request.Match("GET /"));
        }

        [Fact]
        public void DeleteTest()
        {
            var request = new HttpMethodPattern();

            var method = new HttpMethodMatch("DELETE");

            Assert.Equal((method, " /"), request.Match("DELETE /"));
        }

        [Fact]
        public void NoMatchTest()
        {
            var request = new HttpMethodPattern();

            Assert.Equal((new NoMatch(), "text"), request.Match("text"));
        }
    }
}
