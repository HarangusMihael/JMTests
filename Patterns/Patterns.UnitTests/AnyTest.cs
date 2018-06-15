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
            var (match, remaining) = new Any("abc").Match("abc");
            var any = new Any("abc");

            Assert.True(match.Succes);
            Assert.Equal("bc", remaining);
            Assert.Equal((new SuccesMatch("b"), "c"), any.Match("bc"));
            Assert.Equal((new NoMatch(), "dc"), any.Match("dc"));
        }
    }
}
