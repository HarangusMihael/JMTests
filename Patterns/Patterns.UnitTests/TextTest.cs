using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class TextTests
    {
        [Fact]
        public void TextTest()
        {
            var text = new Text("abc");

            Assert.Equal((new SuccesMatch("abc"), ""), text.Match("abc"));
            Assert.Equal((new NoMatch(), "ac"), text.Match("ac"));
        }
    }
}
