using Patterns;

namespace HttpValidatorApplication
{
    public class HttpRequestMatch : IMatch
    {
        private readonly Request request;

        public HttpRequestMatch(SequenceMatch s)
        {
            request = new Request(s);
        }

        public Request Request => request;

        public bool Succes => true;
    }
}
