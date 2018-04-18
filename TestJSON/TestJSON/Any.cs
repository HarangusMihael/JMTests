using System;
using System.Collections.Generic;

namespace TestJSON
{
    internal class Any : IPattern
    {
        private IPattern pattern;
        private Char[] characters;

        public Any(string text)
        {
            int i = 0;
            characters = new Char[text.Length];
            foreach(char c in text)
            {
                characters[i] = new Char(c);
                i++;
            }
            pattern = new Choice(characters);
        }

        public (bool, string) Match(string s)
        {
            return pattern.Match(s);
        }
    }
}