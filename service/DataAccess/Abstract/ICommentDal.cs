using Core.DataAccess;
using Core.Utilities.Query;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        Task<List<User>> GetLikers(int commentId, PaginationParameters pagination);
        Task<int> GetLikersCount(int commentId);
        Task<List<User>> GetDislikers(int commentId, PaginationParameters pagination);
        Task<int> GetDislikersCount(int commentId);
    }
}