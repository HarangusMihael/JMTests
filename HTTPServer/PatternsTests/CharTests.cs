using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class CharTests
    { 
        [Fact]
        public void ZeroCharTest()
        {
            var (match, remaining) = new Char('0').Match("0");
            Assert.True(match.Succes);
            Assert.Equal("", remaining);
        }

        [Fact]
        public void FalseZeroCharTest()
        {
            var (match, remaining) = new Char('a').Match("0");
            Assert.False(match.Succes);
            Assert.Equal("0", remaining);
        }

        [Fact]
        public void EmptyStringTest()
        {
            var n = new Char('0');

            Assert.Equal((new NoMatch(), ""), n.Match(""));
        }

        [Fact]
        public void CharTest()
        {
            var (match, remaining) = new Char('1').Match("13");
            Assert.True(match.Succes);
            Assert.Equal("3", remaining);
        }

        [Fact]
        public void NoMatchTest()
        {
            var n = new Char('0');

            Assert.Equal((new NoMatch(), "123"), n.Match("123"));
        }

    }
}
