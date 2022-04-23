using System.Net;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, HttpStatusCode statusCode) : base(data, true, statusCode)
        {
        }

        public SuccessDataResult(T data, string message, HttpStatusCode statusCode) : base(data, true, message, statusCode)
        {
        }
    }
}
