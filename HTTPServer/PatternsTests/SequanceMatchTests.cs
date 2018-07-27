using Xunit;

namespace Patterns
{
    public class SequanceMatchTests
    {
        [Fact]
        public void CanBeComparedToASucessMatch()
        {
            var successMatch = new SuccesMatch("test");
            var match = new SequenceMatch(new[] { successMatch });
            Assert.True(match.Equals(successMatch));
        }

        [Fact]
        public void ComposedSequanceMatchBeComparedToASucessMatch()
        {
            var successMatch = new SuccesMatch("test");
            var match = new SequenceMatch(new[] {
                new SuccesMatch("te"),
                new SuccesMatch("st")
            });
            Assert.True(match.Equals(successMatch));
        }
    }
}
