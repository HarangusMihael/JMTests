using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class ManyTests
    {
        [Fact]
        public void ManyTest()
        {
            var (match, remaining) = new Many(new Sequence(new Char('a'), new Char('b')), 1, 2).Match("ababc");

            Assert.True(match.Succes);
            Assert.Equal("c", remaining);
        }

        [Fact]
        public void NoMatchTest()
        {
            var (match, remaining) = new Many(new Sequence(new Char('a'), new Char('b')), 0, 0).Match("xababc");

            Assert.True(match.Succes);
            Assert.Equal("xababc", remaining);
        }

        [Fact]
        public void NumberOfMatchesTest()
        {
            var (match, remaining) = new Many(new Char('a'), 1, 1).Match("abc");

            Assert.True(match.Succes);
            Assert.Equal("bc", remaining);
        }

        [Fact]
        public void MatchOnceTest()
        {
            var (match, remaining) = new Many(new Sequence(new Char('a'), new Char('b')), 1, 1).Match("ababc");

            Assert.True(match.Succes);
            Assert.Equal("abc", remaining);
        }

        [Fact]
        public void MatchTwiceTest()
        {
            var (match, remaining) = new Many(new Sequence(new Char('a'), new Char('b')), 2, 2).Match("ab");

            Assert.False(match.Succes);
            Assert.Equal("ab", remaining);
        }
    }
}
