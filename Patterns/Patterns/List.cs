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

        public (bool, string) Match(string s)
        {
            var (isMatching, remaining) = element.Match(s);
            if (!isMatching)
                return (true, s);
            return list.Match(remaining);

        }
    }
}