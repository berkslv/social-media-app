
using System.Net;

namespace Core.Utilities.Results
{
    public class SuccessDataListResult<T> : DataListResult<T>
    {
        public SuccessDataListResult(T data, HttpStatusCode statusCode) : base(data, true, statusCode)
        {
        }

        public SuccessDataListResult(T data, string message, HttpStatusCode statusCode) : base(data, true, message, statusCode)
        {
        }

        public SuccessDataListResult(T data, HttpStatusCode statusCode, int count, int pageNumber, int pageSize) : base(data, true, statusCode, count, pageNumber, pageSize)
        {
        }

        public SuccessDataListResult(T data, string message, HttpStatusCode statusCode, int count, int pageNumber, int pageSize) : base(data, true, message, statusCode, count, pageNumber, pageSize)
        {
        }
    }
}