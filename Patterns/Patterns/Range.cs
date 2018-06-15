using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Range : IPattern
    {
        private char leftElement;
        private char rightElement;

        public Range(char left, char right)
        {
            leftElement = left;
            rightElement = right;
        }

        public (IMatch, string) Match(string s)
        {
            var noMatch = new NoMatch();

            if (string.IsNullOrEmpty(s))
                return (noMatch, s);

            if (leftElement <= s[0] && s[0] <= rightElement)
                return (new SuccesMatch(s[0].ToString()), s.Substring(1));

            return (noMatch, s);
        }
    }
}
