using Patterns;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpValidatorApplication
{
    public class UrlMatch : IMatch
    {
        private Uri uri;

        public UrlMatch(string s)
        {
            uri = new Uri(s, UriKind.RelativeOrAbsolute);
        }

        public Uri Uri
        {
            get => uri; set => uri = value;
        }

        public bool Succes => true;

        public override string ToString()
        {
            return uri.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is UrlMatch)
                return ((UrlMatch)obj).Uri.Equals(uri);

            return base.Equals(obj);
        }
    }
}
