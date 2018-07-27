using HttpValidatorApplication;
using Patterns;
using Xunit;

namespace HttpValidatorTests
{
    public class UrlTest
    {
        [Fact]
        public void AbsoluteUriTest()
        {
            var adress = new UrlPattern();

            var valid = new UrlMatch("http://142.42.1.1");

            Assert.Equal((valid, ""), adress.Match("http://142.42.1.1"));
        }

        [Fact]
        public void InvalidUriTest()
        {
            var adress = new UrlPattern();

            Assert.Equal((new NoMatch(), "http:// 124.42."), adress.Match("http:// 124.42."));
            Assert.Equal((new NoMatch(), "http://#"), adress.Match("http://#"));
          //  Assert.Equal((new NoMatch(), "///"), adress.Match("///"));
        }

    }
}
