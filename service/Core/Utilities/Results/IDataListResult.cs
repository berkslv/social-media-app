namespace Core.Utilities.Results
{
    public interface IDataListResult<out T> : IResult
    {
        T Data { get; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
        int TotalPages { get; set; }
        int TotalCount { get; set; }
    }
}
