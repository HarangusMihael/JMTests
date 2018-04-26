using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class AnyTests
    {
        [Fact]
        public void AnyTest()
        {
            var any = new Any("abc");
            Assert.Equal((true, "bc"), any.Match("abc"));
            Assert.Equal((true, "c"), any.Match("bc"));
            Assert.Equal((false, "dc"), any.Match("dc"));
        }
    }
}
