using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class ListTests
    {
        [Fact]
        public void ListTest()
        {
            var list = new List(new Range('0', '9'), new Char(','));

            Assert.Equal((new SuccesMatch("1,2"), ""), list.Match("1,2"));
            Assert.Equal((new SuccesMatch("1,2"), ","), list.Match("1,2,"));
            Assert.Equal((new SuccesMatch(""), ",1,2"), list.Match(",1,2"));
            Assert.Equal((new SuccesMatch(""), ""), list.Match(""));
            Assert.Equal((new SuccesMatch(""), "x"), list.Match("x"));
            Assert.Equal((new SuccesMatch("2"), ""), list.Match("2"));
            Assert.Equal((new SuccesMatch("2"), "x"), list.Match("2x"));
            Assert.Equal((new SuccesMatch("1"), ";2"), list.Match("1;2"));
        }
    }
}
