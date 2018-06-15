using System.ComponentModel;

namespace HttpValidatorApplication
{
    public enum ResponseTypes
    {
        [Description("200 OK")]
        OK,
        [Description("400 BAD REQUEST")]
        BadRequest,
        [Description("404 NOT FOUND")]
        NotFound
    }
}
