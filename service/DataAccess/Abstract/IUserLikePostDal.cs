using System.Linq.Expressions;
using Core.DataAccess;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserLikePostDal : IEntityRepository<UserLikePost>
    {
    }
}