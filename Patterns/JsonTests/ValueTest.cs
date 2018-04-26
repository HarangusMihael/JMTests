using Json;
using Xunit;

namespace JsonTests
{
    public class ValueTest
    {
        [Fact]
        public void ValueTests()
        {
            var value = new Value();

            Assert.Equal((true, ""), value.Match(@"""\uabcd"""));
            Assert.Equal((true, ""), value.Match("123.50"));
            Assert.Equal((true, ""), value.Match("true"));
            Assert.Equal((true, ""), value.Match("false"));
            Assert.Equal((true, ""), value.Match("null"));
            Assert.Equal((true, ""), value.Match("[]"));
            Assert.Equal((true, ""), value.Match("[1]"));
            Assert.Equal((true, ""), value.Match("[1,2]"));
            Assert.Equal((true, ""), value.Match("[1,2,34.5,null,false,true]"));
            Assert.Equal((true, ""), value.Match("[ ]"));
            Assert.Equal((true, ""), value.Match("[ 1 ]"));
            Assert.Equal((true, ""), value.Match("[1, 2]"));
            Assert.Equal((true, ""), value.Match("[ 1 , 2\t ]\n \r"));
            Assert.Equal((true, ""), value.Match("[1, [1,2, [1,2,3] ] ]"));
            Assert.Equal((true, ""), value.Match("{}"));
            Assert.Equal((true, ""), value.Match("{ }"));
            Assert.Equal((true, ""), value.Match("{\"a\":1}"));
            Assert.Equal((true, ""), value.Match("{\"a\" : 1}"));
            Assert.Equal((true, ""), value.Match("{\"a\":1 , \"b\" : true , \"h\" : 234.56 , \"k\" : {\"e\" : {\"e\" : 34} } } "));
            Assert.Equal((true, ""), value.Match("{\"\u45af\" : 1}"));
        }
    }
}
