using Patterns;

namespace HttpValidatorApplication
{
    public class HttpMethodPattern : IPattern
    {
        private readonly IPattern pattern;

        public HttpMethodPattern()
        {
            pattern = new Choice(new Text("GET"), new Text("DELETE"),
                                 new Text("HEAD"), new Text("METHOD"),
                                 new Text("OPTIONS"), new Text("POST"),
                                 new Text("PUT"), new Text("TRACE"));

        }

        public (IMatch, string) Match(string s)
        {
            var (match, remaining) = pattern.Match(s);

            if (!match.Succes)
                return (new NoMatch(), s);

            return (new HttpMethodMatch(match.ToString()), remaining);
        }
    }
}
