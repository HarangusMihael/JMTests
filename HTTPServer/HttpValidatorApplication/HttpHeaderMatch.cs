using Patterns;
using System;
using System.Collections.Generic;

namespace HttpValidatorApplication
{
    public class HttpHeaderMatch : IMatch
    {
        private Dictionary<string, string> headers = new Dictionary<string, string>();

        public HttpHeaderMatch(Dictionary<string, string> d)
        {
            headers = d;
        }

        public Dictionary<string, string> Header => headers;

        public bool Succes => true;

        public override bool Equals(object obj)
        {
            bool result = true;
            if (obj is HttpHeaderMatch)
            {
                if (((HttpHeaderMatch)obj).Header.Count == headers.Count)
                {
                    foreach (var pair in headers)
                    {
                        string value;
                        if (((HttpHeaderMatch)obj).Header.TryGetValue(pair.Key, out value))
                        {
                            if (pair.Value != value)
                                result = false;
                        }
                        else if (!((HttpHeaderMatch)obj).Header.TryGetValue(pair.Key, out value))
                            result = false;
                    }
                }
                return result;
            }
            return base.Equals(obj);
        }
    }
}
