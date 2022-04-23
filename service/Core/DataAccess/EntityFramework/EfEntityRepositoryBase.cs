using System.Linq.Expressions;
using Core.Entity.Abstract;
using Core.Utilities.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
     where TEntity : class, IEntity, new()
     where TContext : DbContext, new()
    {
        public virtual async Task<TEntity> Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return addedEntity.Entity;
            }
        }

        public async Task<int> Count(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var result = await context.Set<TEntity>().Where(filter).CountAsync();

                return result;
            }
        }

        public async Task<int> Count(FilterParameters filter)
        {
            using (var context = new TContext())
            {
                var result = filter.Filter == String.Empty
                    ? await context.Set<TEntity>().CountAsync()
                    : await context.Set<TEntity>().Where(filter.Filter).CountAsync();

                return result;
            }
        }

        public async Task<int> Count()
        {
            using (var context = new TContext())
            {
                var result = await context.Set<TEntity>().CountAsync();

                return result;
            }
        }
       

        public virtual async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public virtual async Task<IList<TEntity>> GetList(PaginationParameters pagination, FilterParameters filter)
        {
            using (var context = new TContext())
            {
                var _result = filter.Filter == String.Empty
                    ? context.Set<TEntity>()
                    : context.Set<TEntity>().Where(filter.Filter);
                
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

        public virtual async Task<IList<TEntity>> GetList(PaginationParameters pagination, Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var _result = filter == null
                    ? context.Set<TEntity>()
                    : context.Set<TEntity>().Where(filter);
                
                var result = pagination == null
                    ? await _result.ToListAsync()
                    : await _result.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

                return result;
            }
        }

        public virtual async Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var result = filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();

                return result;
            }
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return updatedEntity.Entity;
            }
        }
    }
}