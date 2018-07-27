using Xunit;

namespace Patterns.UnitTests
{
    public class SequanceMatchTests
    {
        [Fact]
        public void CanBeComparedToASucessMatch()
        {
            var successMatch = new SuccesMatch("test");
            var match = new SequenceMatch(new[] { successMatch });
            Assert.Equal<IMatch>(match, successMatch);
        }

        [Fact]
        public void ComposedSequanceMatchBeComparedToASucessMatch()
        {
            var successMatch = new SuccesMatch("test");
            var match = new SequenceMatch(new[] {
                new SuccesMatch("te"),
                new SuccesMatch("st")
            });
            Assert.Equal<IMatch>(match, successMatch);
        }
    }
}
