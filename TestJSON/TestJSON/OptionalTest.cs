using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestJSON
{
    public class OptionalTests
    {
        [Fact]
        public void OptionalTest()
        {
            var optional = new Many(new Char('-'), 0, 1);

            Assert.Equal((true, "5"), optional.Match("-5"));
            Assert.Equal((true, "5"), optional.Match("5"));
        }

        [Fact]
        public void OptionalSequanceTest()
        {
            var optional = new Many(new Sequence(new Char('a'), new Char('b')), 0, 1);

            Assert.Equal((true, "c"), optional.Match("abc"));
            Assert.Equal((true, "xbc"), optional.Match("xbc"));

        }
    }
}
