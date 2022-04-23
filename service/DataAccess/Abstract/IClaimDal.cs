using System.Linq.Expressions;
using Core.DataAccess;
using Core.Entity.Concrete;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IClaimDal : IEntityRepository<UserOperationClaim>
    {
        Task<OperationClaim> GetClaim(Expression<Func<OperationClaim, bool>> filter);
    }
}