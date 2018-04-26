using Json;
using System;
using Xunit;

namespace JsonTests
{
    public class NumbersTests
    {
        [Fact]
        public void NumbersTest()
        {
            var number = new Number();

            Assert.Equal((true, ""), number.Match("2"));
            Assert.Equal((true, ""), number.Match("23"));
            Assert.Equal((true, ""), number.Match("-2"));
            Assert.Equal((true, ""), number.Match("-234"));
            Assert.Equal((true, "2"), number.Match("02"));
            Assert.Equal((true, ""), number.Match("0"));
            Assert.Equal((true, ""), number.Match("23.5"));
            Assert.Equal((true, ""), number.Match("-23.5"));
            Assert.Equal((true, ""), number.Match("0.5"));
            Assert.Equal((true, ""), number.Match("-0.5"));
            Assert.Equal((true, ""), number.Match("2e+2"));
            Assert.Equal((true, ""), number.Match("2e-2"));
            Assert.Equal((true, ""), number.Match("3e02"));
            Assert.Equal((true, ""), number.Match("32e+2"));
        }
    }
}
