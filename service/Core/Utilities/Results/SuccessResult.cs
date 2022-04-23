using System.Net;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(HttpStatusCode statusCode) : base(true, statusCode)
        {
        }

        public SuccessResult(string message, HttpStatusCode statusCode) : base(true, message, statusCode)
        {
        }
    }
}
