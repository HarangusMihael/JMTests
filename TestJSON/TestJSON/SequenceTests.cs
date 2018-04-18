using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TestJSON
{
    public class SequenceTests
    {
        [Fact]
        public void SequenceTest()
        {
            var sequence = new Sequence(new Range('1', '9'), new Char('a'), new Char('b'));
            Assert.Equal((true, ""), sequence.Match("2ab"));
            Assert.Equal((true, "x"), sequence.Match("2abx"));
            Assert.Equal((false, "5ac"), sequence.Match("5ac"));
            Assert.Equal((false, "bc"), sequence.Match("bc"));
        }

        [Fact]
        public void SequanceOfSequance()
        {
            var sequence = new Sequence(
                new Range('1', '9'),
                new Sequence(
                    new Char('a'),
                    new Char('b')
                )
           );
            Assert.Equal((true, ""), sequence.Match("2ab"));
        }
    }
}
