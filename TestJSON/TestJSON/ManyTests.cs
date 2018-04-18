using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestJSON
{
    public class ManyTests
    {
        [Fact]
        public void ManyTest()
        {
            var many = new Many(new Sequence(new Char('a'), new Char('b')), 1, 2);
            Assert.Equal((true, "c"), many.Match("ababc"));
        }

        [Fact]
        public void NoMatchTest()
        {
            var many = new Many(new Sequence(new Char('a'), new Char('b')), 0, 0);
            Assert.Equal((true, "xababc"), many.Match("xababc"));
        }

        [Fact]
        public void NumberOfMatchesTest()
        {
            var many = new Many(new Char('a'), 1, 1);
            Assert.Equal((true, "bc"), many.Match("abc"));
        }

        [Fact]
        public void MatchOnceTest()
        {
            var many = new Many(new Sequence(new Char('a'), new Char('b')), 1, 1);
            Assert.Equal((true, "abc"), many.Match("ababc"));
        }

        [Fact]
        public void MatchTwiceTest()
        {
            var many = new Many(new Sequence(new Char('a'), new Char('b')), 2, 2);
            Assert.Equal((false, "ab"), many.Match("ab"));
        }
    }
}
