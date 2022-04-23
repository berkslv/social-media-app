using System.Linq.Expressions;
using Core.DataAccess;
using Core.Entity.Concrete;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<List<OperationClaim>> GetClaims(User user);
        
    }
}