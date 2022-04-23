using System.Net;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        HttpStatusCode StatusCode { get; }
        object Errors { get; set; }
    }
}
