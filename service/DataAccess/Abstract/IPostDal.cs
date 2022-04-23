using System.Linq.Expressions;
using Core.DataAccess;
using Core.Utilities.Query;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IPostDal : IEntityRepository<Post>
    {
        Task<List<User>> GetLikers(int postId, PaginationParameters pagination);
        Task<int> GetLikersCount(int postId);
        Task<List<User>> GetDislikers(int postId, PaginationParameters pagination);
        Task<int> GetDislikersCount(int postId);
    }
}