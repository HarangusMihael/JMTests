using System;
using System.Collections.Generic;
using System.Text;

namespace TestJSON
{
    class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public (bool, string) Match(string s)
        {
            string temp = s;
            foreach (var pattern in patterns)
            {
                var (isMatching, remaining) = pattern.Match(temp);
                if (!isMatching)
                    return (false, s);
                temp = remaining;
            }
            return (true, temp);
        }
    }
}
