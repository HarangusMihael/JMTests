using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class OptionalTests
    {
        [Fact]
        public void OptionalTest()
        {
            var optional = new Many(new Char('-'), 0, 1);

            Assert.Equal((new SuccesMatch("-"), "5"), optional.Match("-5"));
            Assert.Equal((new SuccesMatch(""), "5"), optional.Match("5"));
        }

        [Fact]
        public void OptionalSequanceTest()
        {
            var optional = new Many(new Sequence(new Char('a'), new Char('b')), 0, 1);

            Assert.Equal((new SuccesMatch("ab"), "c"), optional.Match("abc"));
            Assert.Equal((new SuccesMatch(""), "xbc"), optional.Match("xbc"));
        }
    }
}
