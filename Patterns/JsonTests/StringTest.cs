using Json;
using Xunit;

namespace JsonTests
{
    public class StringTest
    {
        [Fact]
        public void StringTests()
        {
            var newString = new String();

            Assert.Equal((true, ""), newString.Match("\"\""));
            Assert.Equal((false, "\""), newString.Match("\""));
            Assert.Equal((false, "\\"), newString.Match("\\"));
            Assert.Equal((true, ""), newString.Match(@"""\\"""));
            Assert.Equal((true, ""), newString.Match("\"\\\\\""));
            Assert.Equal((true, ""), newString.Match("\"\\/\""));
            Assert.Equal((true, ""), newString.Match("\"\\f\""));
            Assert.Equal((true, ""), newString.Match("\"\\n\""));
            Assert.Equal((true, ""), newString.Match("\"\\r\""));
            Assert.Equal((true, ""), newString.Match("\"\\t\""));
            Assert.Equal((true, ""), newString.Match("\"a\""));
            Assert.Equal((true, ""), newString.Match("\"!\""));
            Assert.Equal((true, ""), newString.Match("\" \""));
            Assert.Equal((true, ""), newString.Match("\"\\u14FF\""));
            Assert.Equal((false, "\"\\u14FF5\""), newString.Match("\"\\u14FF5\""));
            Assert.Equal((true, ""), newString.Match("\"\\u14ab\""));

        }

    }
}
