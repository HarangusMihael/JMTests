using Patterns;

namespace Json
{
    public class String : IPattern 
    {
        private readonly IPattern pattern;

        public String()
        {
            var hexaDigits = new Sequence(
                             new Char('\\'), 
                             new Char('u'), 
                             new Many(new Choice(new Range('0','9'), new Range('A','F'), new Range('a','f')), 4, 4));
            var quotationReverse = new Choice(
                                   hexaDigits,
                                   new Text("\\\""),
                                   new Text("\\\\"),
                                   new Text("\\/"),
                                   new Text("\\b"),
                                   new Text("\\f"),
                                   new Text("\\n"),
                                   new Text("\\r"),
                                   new Text("\\t"),
                                   new Range('#', (char)ushort.MaxValue),
                                   new Range(' ', '!'));
            pattern = new Sequence(new Char('"'), new Optional(quotationReverse), new Char('"'));
        }

        public (IMatch, string) Match(string s)
        {
            return pattern.Match(s);
        }
    }
}
