using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class OneOrMoreTests
    {
        [Fact]
        public void OneOrMoreTest()
        {
            var oneOrMore = new OneOrMore(new Choice(new Char('a'), new Char('b')));
            Assert.Equal((true, "c"), oneOrMore.Match("ababc"));
            Assert.Equal((true, "dc"), oneOrMore.Match("adc"));
        }

        [Fact]
        public void OneOrMoreFalseTest()
        {
            var oneOrMore = new OneOrMore(new Choice(new Char('a'), new Char('b')));
            Assert.Equal((false, "xd"), oneOrMore.Match("xd"));
        }
    }
}
