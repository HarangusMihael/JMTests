using Patterns;

namespace HttpValidatorApplication
{
    public class HttpMethodMatch : IMatch
    {
        public HttpMethodMatch(string s)
        {
            switch (s)
            {
                case "GET":
                    Method = HttpMethod.Get;
                    break;
                case "DELETE":
                    Method = HttpMethod.Delete;
                    break;
                case "HEAD":
                    Method = HttpMethod.Head;
                    break;
                case "METHOD":
                    Method = HttpMethod.Method;
                    break;
                case "OPTIONS":
                    Method = HttpMethod.Options;
                    break;
                case "POST":
                    Method = HttpMethod.Post;
                    break;
                case "PUT":
                    Method = HttpMethod.Put;
                    break;
                case "TRACE":
                    Method = HttpMethod.Trace;
                    break;
            }
        }

        public HttpMethod Method { get; }

        public bool Succes => true;

        public override bool Equals(object obj)
        {
            if (obj is HttpMethodMatch)
                return ((HttpMethodMatch)obj).Method.Equals(Method);

            return base.Equals(obj);
        }
    }

}
