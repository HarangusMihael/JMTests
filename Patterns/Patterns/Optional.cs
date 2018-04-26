using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Optional : IPattern
    {
        private readonly IPattern pattern;

        public Optional(IPattern pattern)
        {
            this.pattern = new Many(pattern, 0, 1);
        }

        public (bool, string) Match(string s)
        {
            return pattern.Match(s);
        }
    }
}
