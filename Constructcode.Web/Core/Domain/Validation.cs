using System.Net;

namespace Constructcode.Web.Core.Domain
{
    public class Validation
    {
        public bool IsValid { get; }
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }

        public int StatusCodeAsIntegar => (int) StatusCode;

        public Validation(bool isValid)
        {
            IsValid = isValid;
        }

        public Validation(bool isValid, string message, HttpStatusCode statusCode)
        {
            IsValid = isValid;
            Message = message;
            StatusCode = statusCode;
        }
    }
}