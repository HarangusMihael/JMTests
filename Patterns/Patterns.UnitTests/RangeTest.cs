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
            var n = new Range('0', '9');

            Assert.Equal((true, ""), n.Match("1"));
        }

        [Fact]
        public void NotInRangeTest()
        {
            var n = new Range('0', '9');

            Assert.Equal((false, "a"), n.Match("a"));
        }

        [Fact]
        public void InRangeTest()
        {
            var n = new Range('a', 'd');

            Assert.Equal((true, ""), n.Match("c"));
        }

        [Fact]
        public void EmptyStringTest()
        {
            var n = new Range('a', 'd');

            Assert.Equal((false, ""), n.Match(""));
        }
    }
}
