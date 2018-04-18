using System;
using System.Collections.Generic;
using System.Text;

namespace TestJSON
{
    class Char : IPattern
    {
        private char toMatch;

        public Char(char character)
        {
            toMatch = character;
        }

        public (bool, string) Match(string s)
        {
            if (string.IsNullOrEmpty(s) || s[0] != toMatch)
                return (false, s);
            
            return (true, s.Substring(1));
        }
    }
}
