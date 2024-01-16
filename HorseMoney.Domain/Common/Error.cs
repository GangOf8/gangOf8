using System.Net;

namespace HorseMoney.Domain.Common
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public Error(HttpStatusCode httpStatusCode, string message)
        {
            StatusCode = (int)httpStatusCode;
            Message = message;
        }

        public static readonly Error None = new(HttpStatusCode.Continue, string.Empty);
    }
}
