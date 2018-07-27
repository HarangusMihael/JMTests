using System.Collections.Generic;

namespace Patterns
{
    public class List : IPattern
    {
        private IPattern element;
        private IPattern list;

        public List(IPattern elementPattern, IPattern separatorPattern)
        {
            element = elementPattern;
            list = new Many(new Sequence(separatorPattern, elementPattern));
        }

        public (IMatch, string) Match(string s)
        {
            var (match, remaining) = element.Match(s);
            if (!match.Succes)
                return (new SuccesMatch(""), s);

            var (remainingMatch, remainingList) = list.Match(remaining);
            if (!remainingMatch.Succes)
                return (match, remaining);
            return (new SuccesMatch(match.ToString() + remainingMatch.ToString()), remainingList);
        }
    }
}