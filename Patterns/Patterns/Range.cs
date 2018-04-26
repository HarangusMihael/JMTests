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

        public (bool, string) Match(string s)
        {
            if (string.IsNullOrEmpty(s))
                return (false, s);

            if (leftElement <= s[0] && s[0] <= rightElement)
                return (true, s.Substring(1));

            return (false, s);
        }
    }
}
