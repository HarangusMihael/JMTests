using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;

        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public (IMatch, string) Match(string s)
        {
            var noMatch = new NoMatch();
            var list = new List<IMatch>();
            var temp = s;
            foreach (var pattern in patterns)
            {
                var (isMatching, remaining) = pattern.Match(temp);
                if (!isMatching.Succes)
                    return (noMatch, s);
                temp = remaining;
                list.Add(isMatching);
            }
            var succes = new SequenceMatch(list);
            return (succes, temp);
        }
    }
}
