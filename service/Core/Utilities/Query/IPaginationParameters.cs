using Core.Entity.Abstract;

namespace Core.Utilities.Query
{
    public interface IPaginationParameters
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}