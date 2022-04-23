using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Query;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfDepartmentDal : EfEntityRepositoryBase<Department, HubContext>, IDepartmentDal
    {
        public override async Task<Department> Get(Expression<Func<Department, bool>> filter)
        {
            using (var context = new HubContext())
            {
                return await context
                    .Set<Department>()
                    .Include(x => x.DepartmentCode)
                    .Include(x => x.Faculty)
                    .SingleOrDefaultAsync(filter);
            }
        }

        public async override Task<IList<Department>> GetList(PaginationParameters pagination, FilterParameters filter)
        {

            using (var context = new HubContext())
            {
                var _result = filter.Filter == String.Empty
                    ? context
                        .Set<Department>()
                        .Include(x => x.DepartmentCode)
                        .Include(x => x.Faculty)
                    : context
                        .Set<Department>()
                        .Include(x => x.DepartmentCode)
                        .Include(x => x.Faculty)
                        .Where(filter.Filter);
                
                if (filter.OrderBy is not null)
                {
                    _result = _result.OrderBy(filter.OrderBy);
                }

                var result = pagination == null
                    ? await _result.ToListAsync()
                    : await _result.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

                return result;
            }
        }

        public override async Task<IList<Department>> GetList(PaginationParameters pagination, Expression<Func<Department, bool>> filter = null)
        {
            using (var context = new HubContext())
            {
                var _result = filter == null
                    ? context   
                        .Set<Department>()
                        .Include(x => x.DepartmentCode)
                        .Include(x => x.Faculty)
                    : context
                        .Set<Department>()
                        .Include(x => x.DepartmentCode)
                        .Include(x => x.Faculty)
                        .Where(filter);

                var result = pagination == null
                    ? await _result.ToListAsync()
                    : await _result.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

                return result;
            }
        }

        public override async Task<IList<Department>> GetList(Expression<Func<Department, bool>> filter = null)
        {
            using (var context = new HubContext())
            {
                var result = filter == null
                    ? await context
                        .Set<Department>()
                        .Include(x => x.DepartmentCode)
                        .Include(x => x.Faculty)
                        .ToListAsync()
                    : await context
                        .Set<Department>()
                        .Include(x => x.DepartmentCode)
                        .Include(x => x.Faculty)
                        .Where(filter)
                        .ToListAsync();

                return result;
            }
        }
    }
}