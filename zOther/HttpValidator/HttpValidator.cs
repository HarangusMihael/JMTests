using Patterns;


namespace HttpValidatorApplication
{
    public class HttpValidator : IPattern
    {
        private readonly IPattern pattern;

        public HttpValidator()
        {
            var keyChoice = new Choice(new Range(' ', '9'), new Range(';', (char)ushort.MaxValue));
            var valueChoice = new Many(new Range(' ', (char)ushort.MaxValue));
            var requestURI = new Sequence(new Many(new Range('!', (char)ushort.MaxValue)), new Char(' '));
            var request = new Sequence(new Text("GET "), requestURI, new Text("HTTP/1.1\r\n"));
            var keyValueChoice = new Many(
                new Sequence(new Many(keyChoice), new Char(':'), new Char(' '), valueChoice, new Text("\r\n")));

            pattern = new Sequence(request, keyValueChoice, new Text("\r\n"));
        }

        public (IMatch, string) Match(string s)
        {
            var succes = new SuccesMatch(s);
            var noMatch = new NoMatch();
            var (match, result) = pattern.Match(s);
            if (!match.Succes)
                return (noMatch, s);
            return pattern.Match(s);
        }
    }
}
