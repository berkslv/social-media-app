using System.Net;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }
        public HttpStatusCode StatusCode { get; }
        public object Errors { get; set; }

        public Result(bool success, string message, HttpStatusCode statusCode)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
        }

        public Result(bool success, HttpStatusCode statusCode)
        {
            Success = success;
            StatusCode = statusCode;
        }

        public Result(bool success, string message, object errors, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            Errors = errors;
            StatusCode = statusCode;
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
        
    }
}
