using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestJSON
{
    public class TextTests
    {
        [Fact]
        public void TextTest()
        {
            var text = new Text("abc");
            Assert.Equal((true, ""), text.Match("abc"));
            Assert.Equal((false, "ac"), text.Match("ac"));
        }
    }
}
