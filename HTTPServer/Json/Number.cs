using Patterns;

namespace Json
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
            var digit = new Range('0', '9');
            var digits = new Many(digit);
            var minus = new Optional(new Char('-'));
            var nonZeroDigit = new Range('1', '9');
            var onlyZeroDigit = new Char('0');
            var naturalNumber = new Choice(onlyZeroDigit, new Sequence(nonZeroDigit, digits));
            var intNumber = new Sequence(minus, naturalNumber);
            var floatNumber = new Sequence(intNumber, new Optional(new Sequence(new Char('.'), digits)));
            var exponential = new Sequence(new Any("eE"), new Optional(new Any("+-")), digits);
            pattern = new Sequence(floatNumber, new Optional(exponential));
        }

        public (IMatch, string) Match(string s)
        {
            return pattern.Match(s);
        }
    }
}
