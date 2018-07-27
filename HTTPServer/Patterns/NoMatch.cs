namespace Patterns
{
    public class NoMatch : IMatch
    {
        public bool Succes => false;

        public override bool Equals(object obj)
        {
            var result = obj is NoMatch;
            return result;
        }
    }
}
