using System.Net;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(HttpStatusCode statusCode) : base(default, false, statusCode)
        {
        }

        public ErrorDataResult(string message, HttpStatusCode statusCode) : base(default, false, message, statusCode)
        {
        }
    }
}
