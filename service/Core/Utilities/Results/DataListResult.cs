using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Core.Utilities.Results
{
    public class DataListResult<T> : Result, IDataListResult<T>
    {
        public DataListResult(T data, bool success, string message, HttpStatusCode statusCode, int count, int pageNumber, int pageSize) : base(success, message, statusCode)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = data;
        }
        public DataListResult(T data, bool success, HttpStatusCode statusCode, int count, int pageNumber, int pageSize) : base(success, statusCode)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            Data = data;
        }

        public DataListResult(T data, bool success, string message, HttpStatusCode statusCode) : base(success, message, statusCode)
        {
            Data = data;
        }

        public DataListResult(T data, bool success, HttpStatusCode statusCode) : base(success, statusCode)
        {
            Data = data;
        }


        public T Data { get; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        [Range(1, 10)]
        public int PageSize { get; set; }
        public bool HasNext => CurrentPage < TotalPages;
        public bool HasPrevious => CurrentPage > 1;
    }
}
