using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns
{
    public class SuccesMatch : IMatch
    {
        string result;
        public SuccesMatch(string s)
        {
            this.result = s;
        }
        public bool Succes => true;

        public string Result => result;

        public override bool Equals(object obj)
        {
            var other = obj as IMatch;
            if (other != null)
                return ToString().Equals(obj.ToString());
            return base.Equals(obj);
        }

        public override string ToString()
        {
            return result;
        }
    }
}
