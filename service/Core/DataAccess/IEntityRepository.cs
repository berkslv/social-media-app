using System.Linq.Expressions;
using Core.Entity.Abstract;
using Core.Utilities.Query;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T: class, IEntity,new()
    {
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<IList<T>> GetList(PaginationParameters pagination, FilterParameters filter);
        Task<IList<T>> GetList(PaginationParameters pagination, Expression<Func<T, bool>> filter = null);
        Task<IList<T>> GetList(Expression<Func<T, bool>> filter = null);
        Task<int> Count();
        Task<int> Count(FilterParameters filter);
        Task<int> Count(Expression<Func<T, bool>> filter);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}