using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Patterns
{
    public class SequenceTests
    {
        [Fact]
        public void SequenceTest()
        {
            var sequence = new Sequence(new Range('1', '9'), new Char('a'), new Char('b'));

            Assert.Equal((new SuccesMatch("2ab"), ""), sequence.Match("2ab"));
            Assert.Equal((new SuccesMatch("2ab"), "x"), sequence.Match("2abx"));
            Assert.Equal((new NoMatch(), "5ac"), sequence.Match("5ac"));
            Assert.Equal((new NoMatch(), "bc"), sequence.Match("bc"));
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

            Assert.Equal((new SuccesMatch("2ab"), ""), sequence.Match("2ab"));
        }
    }
}
