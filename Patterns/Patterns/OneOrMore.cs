namespace Patterns
{
    public class OneOrMore
    {
        private readonly IPattern pattern;      

        public OneOrMore(IPattern pattern)
        {
           this.pattern = new Many(pattern, 1);
        }

        public (bool, string) Match(string s)
        {
            return pattern.Match(s);
        }

    }
}