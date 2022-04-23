using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message, HttpStatusCode statusCode) : base(false, message, statusCode)
        {
        }

        public ErrorResult(HttpStatusCode statusCode) : base(false, statusCode)
        {
        }

    }
}
