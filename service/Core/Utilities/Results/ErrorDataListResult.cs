using System.Net;

namespace Core.Utilities.Results
{
    public class ErrorDataListResult<T> : DataListResult<T>
    {
        public ErrorDataListResult(HttpStatusCode statusCode) : base(default, false, statusCode)
        {
        }

        public ErrorDataListResult(string message, HttpStatusCode statusCode) : base(default, false, message, statusCode)
        {
        }

        public ErrorDataListResult(HttpStatusCode statusCode, int count, int pageNumber, int pageSize) : base(default, false, statusCode, count, pageNumber, pageSize)
        {
        }

        public ErrorDataListResult(string message, HttpStatusCode statusCode, int count, int pageNumber, int pageSize) : base(default, false, message, statusCode, count, pageNumber, pageSize)
        {
        }
    }
}