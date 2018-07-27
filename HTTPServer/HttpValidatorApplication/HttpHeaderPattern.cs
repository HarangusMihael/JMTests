using Patterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HttpValidatorApplication
{
    public class HttpHeaderPattern : IPattern
    {
        private readonly IPattern pattern;

        public HttpHeaderPattern()
        {
            var keyChoice = new Choice(new Range(' ', '9'), new Range(';', (char)ushort.MaxValue));
            var valueChoice = new Many(new Range(' ', (char)ushort.MaxValue));
            var keyValueChoice = new Many(
                new Sequence(new Many(keyChoice), new Patterns.Char(':'), new Patterns.Char(' '), valueChoice, new Text("\r\n")));
            pattern = new Sequence(keyValueChoice, new Text("\r\n"));
        }

        public (IMatch, string) Match(string s)
        {
            var (headerMatch, headerRemain) = pattern.Match(s);

            if (!headerMatch.Succes)
                return (new NoMatch(), s);

            var dictionary = Regex.Split(s, "\r\n")
               .Where(str => !string.IsNullOrEmpty(str))
                .ToDictionary(this.ExtractFieldName, this.ExtractFieldValue);

            return (new HttpHeaderMatch(dictionary), headerRemain);
        }

        private string ExtractFieldName(string arg)
        {
               
            return arg.Substring(0, arg.IndexOf(":"));
        }

        private string ExtractFieldValue(string arg)
        {
            return arg.Substring(arg.IndexOf(":") + 1);
        }
    }
}
