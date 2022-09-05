using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, HubContext>, IUserDal
    {
        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            using (var context = new HubContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.Id
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
                
                return await result.ToListAsync();

            }
        }

        public override async Task<User> Get(Expression<Func<User, bool>> filter)
        {
            using (var context = new HubContext())
            {
                return await context
                    .Set<User>()
                    .Include(x => x.University)
                    .Include(x => x.Faculty)
                    .Include(x => x.Department)
                    .ThenInclude(x => x.DepartmentCode)
                    .SingleOrDefaultAsync(filter);
            }
        }
    }
}