namespace Patterns
{
    public class Text : IPattern
    {
        private IPattern pattern;
        private Char[] characters;

        public Text(string text)
        {
            int i = 0;
            characters = new Char[text.Length];
            foreach (char c in text)
            {
                characters[i] = new Char(c);
                i++;
            }
            pattern = new Sequence(characters);
        }

        public (bool, string) Match(string s)
        {
            return pattern.Match(s);
        }
    }
}