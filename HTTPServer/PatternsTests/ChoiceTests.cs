using Xunit;

namespace Patterns
{
    public class ChoiceFacts
    {
        [Fact]
        public void ChoiceWithSingleMatchingPattern()
        {
            var (match, remaining) = new Choice(new Char('a')).Match("abc");
            Assert.True(match.Succes);
            Assert.Equal("bc", remaining);
        }

        [Fact]
        public void ChoiceWithMultipleMatchingPatterns()
        {
            var (match, remaining) = new Choice(new Range('1', '9'), new Char('b')).Match("bc");
            Assert.True(match.Succes);
            Assert.Equal("c", remaining);
        }

        [Fact]
        public void NoMatchingPatterns()
        {
            var (match, remaining) = new Choice(new Range('1', '9'), new Char('b')).Match("-3bc");
            Assert.False(match.Succes);
            Assert.Equal("-3bc", remaining);
        }

        [Fact]
        public void ChoiceOfSequances()
        {
         var (match, remaining) = new Choice(
                new Sequence(new Char('a'), new Char('b')),
                new Sequence(new Char('1'), new Char('2'))).Match("abx");

           Assert.True(match.Succes);
           Assert.Equal("x", remaining);
        }

        [Fact]
        public void FalseChoiceOfSequances()
        {
            var (match, remaining) = new Choice(
                   new Sequence(new Char('a'), new Char('b')),
                   new Sequence(new Char('1'), new Char('2'))).Match("xbc");

             Assert.False(match.Succes);
             Assert.Equal("xbc", remaining);

        }

        [Fact]
        public void AddNewPattern()
        {
            var choice = new Choice(new Range('1', '9'));
            choice.Add(new Char('b'));

            Assert.Equal((new SuccesMatch("3"), "bc"), choice.Match("3bc"));
            Assert.Equal((new SuccesMatch("b"), "3c"), choice.Match("b3c"));
            Assert.Equal((new NoMatch(), "c"), choice.Match("c"));
        }
    }
}