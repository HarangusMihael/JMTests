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

        public (bool, string) Match(string s)
        {
            foreach (var pattern in patterns)
            {
                var (isMatching, remaining) = pattern.Match(s);
                if (isMatching)
                    return (true, remaining);
            }
            return (false, s);
        }

        public void Add(IPattern pattern)
        {
            patterns.Add(pattern);
        }
    }
}
