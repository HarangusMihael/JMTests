using Xunit;

namespace Patterns
{
    public class ChoiceFacts
    {
        [Fact]
        public void ChoiceWithSingleMatchingPattern()
        {
            var choice = new Choice(new Char('a'));
            Assert.Equal((true, "bc"), choice.Match("abc"));
        }

        [Fact]
        public void ChoiceWithMultipleMatchingPatterns()
        {
            var choice = new Choice(new Range('1', '9'), new Char('b'));
            Assert.Equal((true, "c"), choice.Match("bc"));
        }

        [Fact]
        public void NoMatchingPatterns()
        {
            var choice = new Choice(new Range('1', '9'), new Char('b'));
            Assert.Equal((false, "-3bc"), choice.Match("-3bc"));
        }

        [Fact]
        public void ChoiceOfSequances()
        {
            var choice = new Choice(
                new Sequence(new Char('a'), new Char('b')),
                new Sequence(new Char('1'), new Char('2')));

            Assert.Equal((true, "x"), choice.Match("abx"));
            Assert.Equal((true, "x"), choice.Match("12x"));
            Assert.Equal((false, "xbc"), choice.Match("xbc"));

        }

        [Fact]
        public void AddNewPattern()
        {
            var choice = new Choice(new Range('1', '9'));
            choice.Add(new Char('b'));
            Assert.Equal((true, "bc"), choice.Match("3bc"));
            Assert.Equal((true, "3c"), choice.Match("b3c"));
            Assert.Equal((false, "c"), choice.Match("c"));
        }
    }
}