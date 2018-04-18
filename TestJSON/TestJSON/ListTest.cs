using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestJSON
{
    public class ListTests
    {
        [Fact]
        public void ListTest()
        {
            var list = new List(new Range('0', '9'), new Char(','));

            Assert.Equal((true, ""), list.Match("1,2"));
            Assert.Equal((true, ","), list.Match("1,2,"));
            Assert.Equal((true, ",1,2"), list.Match(",1,2"));
            Assert.Equal((true, ""), list.Match(""));
            Assert.Equal((true, "x"), list.Match("x"));
            Assert.Equal((true, ""), list.Match("2"));
            Assert.Equal((true, "x"), list.Match("2x"));
            Assert.Equal((true, ";2"), list.Match("1;2"));
        }
    }
}
