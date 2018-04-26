using Patterns;

namespace Json
{
    public class Value : IPattern
    {
        private readonly Choice pattern;

        public Value()
        {
            var text = new String();
            var number = new Number();
            var trueValue = new Text("true");
            var falseValue = new Text("false");
            var nullValue = new Text("null");
            var space = new Many(new Any(" \t\r\n"));
            pattern = new Choice(text, number, trueValue, falseValue, nullValue);

            var separator = new Sequence(space, new Char(','), space);
            var list = new List(pattern, separator);
            var array = new Sequence(space, new Char('['), space, list, space, new Char(']'), space);

            var objectSeparator = new Sequence(space, new Char(':'), space);
            var stringValue = new Sequence(text, objectSeparator, pattern);
            var objectList = new List(stringValue, separator);
            var objectValue = new Sequence(space, new Char('{'), space, objectList, space, new Char('}'),space);

            pattern.Add(array);
            pattern.Add(objectValue);
        }

        public (bool, string) Match(string s)
        {
            return pattern.Match(s);
        }
    }
}
