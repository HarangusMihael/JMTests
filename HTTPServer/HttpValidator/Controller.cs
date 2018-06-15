using System;
using System.IO;

namespace HttpValidatorApplication
{
    public class Controller : IProcess
    {
        IDisk dependency;
        private string index = "index.html";

        public Controller(IDisk dependency)
        {
            this.dependency = dependency;
        }

        public Response Process(Request request)
        {
            string requestPath = "";

            if (request.Method.Equals(HttpMethod.Get))
            {
                Response response = new Response(ResponseTypes.OK);

                requestPath = request.Uri.ToString();

                byte[] result = null;

                try
                {
                    result = dependency.VerifyPath(requestPath);
                }

                catch (IOException)
                {

                    if (!requestPath.EndsWith(index))
                    {
                        request.Uri = new Uri(requestPath + index, UriKind.RelativeOrAbsolute);
                        return Process(request);
                    }

                    return new Response(ResponseTypes.NotFound)
                    {
                        Body = "NOT FOUND"
                    };

                }

                response.SetBody(result);
                return response;
            }

            return new Response(ResponseTypes.BadRequest);
        }
    }
}
