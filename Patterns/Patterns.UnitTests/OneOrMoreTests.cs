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

            Assert.Equal((new SuccesMatch("abab"), "c"), oneOrMore.Match("ababc"));
            Assert.Equal((new SuccesMatch("a"), "dc"), oneOrMore.Match("adc"));
        }

        [Fact]
        public void OneOrMoreFalseTest()
        {
            var oneOrMore = new OneOrMore(new Choice(new Char('a'), new Char('b')));

            Assert.Equal((new NoMatch(), "xd"), oneOrMore.Match("xd"));
        }
    }
}
