using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class RangeTests
    {
        [Fact]
        public void RangeTest()
        {
            var (match, remaining) = new Range('0', '9').Match("1");

            Assert.True(match.Succes);
            Assert.Equal("", remaining);
        }

        [Fact]
        public void NotInRangeTest()
        {
            var (match, remaining) = new Range('0', '9').Match("a");

            Assert.False(match.Succes);
            Assert.Equal("a", remaining);
        }

        [Fact]
        public void InRangeTest()
        {
            var (match, remaining) = new Range('a', 'd').Match("c");

            Assert.True(match.Succes);
            Assert.Equal("", remaining);
        }

        [Fact]
        public void EmptyStringTest()
        {
            var n = new Range('a', 'd');

            Assert.Equal((new NoMatch(), ""), n.Match(""));
        }
    }
}
