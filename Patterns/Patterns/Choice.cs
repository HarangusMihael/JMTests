using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Choice : IPattern
    {
        private readonly List<IPattern> patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = new List<IPattern>(patterns);           
        }

        public (IMatch, string) Match(string s)
        {
            var noMatch = new NoMatch();
            foreach (var pattern in patterns)
            {
                var (match, remaining) = pattern.Match(s);
                if (match.Succes)
                {
                    return (match, remaining);
                }
            }
            return (noMatch, s);
        }

        public void Add(IPattern pattern)
        {
            patterns.Add(pattern);
        }
    }
}
