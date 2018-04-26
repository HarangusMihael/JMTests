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

        public (bool, string) Match(string s)
        {
            var numberOfAparitions = 0;
            string temp = s;

            var (isMatching, remaining) = pattern.Match(temp);
           
            while (isMatching && numberOfAparitions < max)
            {
                if (temp == "")
                    break;
                numberOfAparitions++;
                (isMatching, remaining) = pattern.Match(temp);
                temp = remaining;
            }

            if (numberOfAparitions < min)
                return (false, s);

            return (true, temp);
        }
    }
}