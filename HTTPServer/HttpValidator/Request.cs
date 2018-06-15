using Patterns;
using System;
using System.Collections.Generic;

namespace HttpValidatorApplication
{
    public class Request
    {
        HttpMethod method;
        Dictionary<string, string> headers;

        public Request(SequenceMatch match)
        {
            foreach (var element in match.Elements)
            {
                if (element is HttpMethodMatch)
                    method = ((HttpMethodMatch)element).Method;
                if (element is UrlMatch)
                    Uri = ((UrlMatch)element).Uri;
                if (element is HttpHeaderMatch)
                    headers = ((HttpHeaderMatch)element).Header;
            }
        }



        public HttpMethod Method => method;
        public Uri Uri { get; set; }
        public Dictionary<string, string> Headers => headers; 
    }
}
