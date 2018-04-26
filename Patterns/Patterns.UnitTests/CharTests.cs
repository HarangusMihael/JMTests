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
            var n = new Char('0');

            Assert.Equal((true,""), n.Match("0"));
        }

        [Fact]
        public void FalseZeroCharTest()
        {
            var n = new Char('a');

            Assert.Equal((false, "0"), n.Match("0"));
        }

        [Fact]
        public void EmptyStringTest()
        {
            var n = new Char('0');

            Assert.Equal((false, ""), n.Match(""));
        }

        [Fact]
        public void CharTest()
        {
            var n = new Char('1');

            Assert.Equal((true, "3"), n.Match("13"));
        }

        [Fact]
        public void NoMatchTest()
        {
            var n = new Char('0');

            Assert.Equal((false, "123"), n.Match("123"));
        }

    }
}
