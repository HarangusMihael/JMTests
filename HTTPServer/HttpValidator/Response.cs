using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HttpValidatorApplication
{
    public class Response
    {
        private Dictionary<string, string> headers = new Dictionary<string, string>();
        private ResponseTypes responseType;
        private byte[] body;

        public Response(ResponseTypes type)
        {
            responseType = type;
        }

        public void AddHeader(string key, string value)
        {
            headers[key] = value;
        }

        public string HeaderToString()
        {
            return string.Join("\r\n", headers.Select(x => $"{x.Key}: {x.Value}"));
        }

        public void SetBody(byte[] body)
        {
            this.body = body;
            AddHeader("Content-Length", body.Length.ToString());
        }

        public string Body
        {
            set => SetBody(value);
        }

        public void SetBody(string body)
        {
            SetBody(Encoding.UTF8.GetBytes(body));
        }

        public static string GetDescription(Enum value)
        {
            return value
                    .GetType()
                    .GetMember(value.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()
                    .Description;
        }

        public byte[] ResultBytes()
        {
            var headersAsString = "HTTP/1.1" + " " + GetDescription(responseType) + "\r\n" +
                                   HeaderToString() + "\r\n";

            if (headers.Count != 0)
            {
                headersAsString += "\r\n";
            }

            var array = Encoding.ASCII.GetBytes(headersAsString);
            if (body != null)
            {
                int arrayLength = array.Length;

                Array.Resize(ref array, array.Length + body.Length);

                body.CopyTo(array, arrayLength);
            }

            return array;
        }

        public byte[] Result => ResultBytes();

        public ResponseTypes Type => responseType;
    }
}
