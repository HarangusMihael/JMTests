using Patterns;

namespace HttpValidatorApplication
{
    public class HttpRequestPattern : IPattern
    {
        private readonly IPattern pattern;

        public HttpRequestPattern()
        {
            pattern = new Sequence(new HttpMethodPattern(),
                      new Char(' '), new UrlPattern(), 
                      new Char(' '), new Text("HTTP/1.1"), 
                      new HttpHeaderPattern());

        }

        public (IMatch, string) Match(string s)
        {
            var (match, remaining) = pattern.Match(s);

            if (!match.Succes)
                return (new NoMatch(), s);

            return (new HttpRequestMatch((SequenceMatch)match), remaining);
        }
    }
}
