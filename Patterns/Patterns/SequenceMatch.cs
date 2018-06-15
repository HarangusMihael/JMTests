using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Patterns
{
    public class SequenceMatch : IMatch
    {
        public SequenceMatch(IEnumerable<IMatch> list)
        {
            Elements = list;
        }

        public IEnumerable<IMatch> Elements { get; }

        public bool Succes => true;

        public override bool Equals(object obj)
        {
            var other = obj as IMatch;
            if (other != null)
                return ToString().Equals(obj.ToString());
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return Elements.Aggregate("", (s, m) => s + m.ToString());
        }
    }
}
