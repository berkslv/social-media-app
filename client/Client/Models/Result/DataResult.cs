using System.Net;
using Client.Models.Abstract;

namespace Client.Models
{
    public class DataResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public object Errors { get; set; }
        public object Data { get; set; }
    }
}