namespace Patterns
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        private int min = 0;
        private int max = 0;

        public Many(IPattern pattern, int minAparitions = 0, int maxAparitions = int.MaxValue)
        {
            this.pattern = pattern;
            this.min = minAparitions;
            this.max = maxAparitions;
        }

        public (IMatch, string) Match(string s)
        {
            var noMatch = new NoMatch();

            var numberOfAparitions = 0;
            string temp = s;
            string consume = "";

            var (isMatching, remaining) = pattern.Match(temp);
           
            while (isMatching.Succes && numberOfAparitions < max)
            {
                if (temp == "")
                    break;
                numberOfAparitions++;
                (isMatching, remaining) = pattern.Match(temp);
                if (isMatching.Succes)
                {
                    consume += isMatching;
                }
                temp = remaining;
            }

            if (numberOfAparitions < min)
                return (noMatch, s);

            if (numberOfAparitions == 0)
                return (new SuccesMatch(""), temp);

            return (new SuccesMatch(consume), temp);
        }
    }
}