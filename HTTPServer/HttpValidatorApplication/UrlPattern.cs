using Patterns;
using System;

namespace HttpValidatorApplication
{
    public class UrlPattern : IPattern
    {
        private readonly IPattern pattern;

        public UrlPattern()
        {
            pattern = new Sequence(new Many(new Range('!', (char)ushort.MaxValue)));

        }

        public (IMatch, string) Match(string s)
        {
            var (uriMatch, uriRemaining) = pattern.Match(s);

            if (!uriMatch.Succes)
                return (new NoMatch(), s);

            if (Uri.IsWellFormedUriString(uriMatch.ToString(), UriKind.RelativeOrAbsolute))
                return (new UrlMatch(uriMatch.ToString()), uriRemaining);

            return (new NoMatch(), s);
        }
    }
}
