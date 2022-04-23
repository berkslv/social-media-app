using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfClaimDal : EfEntityRepositoryBase<UserOperationClaim, HubContext>, IClaimDal
    {
        public async Task<OperationClaim> GetClaim(Expression<Func<OperationClaim, bool>> filter)
        {
            using (var context = new HubContext())
            {
                return await context.Set<OperationClaim>().SingleOrDefaultAsync(filter);
            }
        }
    }
}