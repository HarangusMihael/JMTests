using System;
using System.Collections.Generic;
using System.Text;

namespace TestJSON
{
    class Choice : IPattern
    {
        private readonly IPattern[] patterns;

        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
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
    }
}
