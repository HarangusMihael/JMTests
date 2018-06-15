using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Char : IPattern
    {
        private char toMatch;

        public Char(char character)
        {
            toMatch = character;
        }

        public (IMatch, string) Match(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] != toMatch)
                return (new NoMatch(), s);

            return (new SuccesMatch(s[0].ToString()), s.Substring(1));
        }
    }
}
