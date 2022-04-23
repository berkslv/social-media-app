using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Utilities.Query;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPostDal : EfEntityRepositoryBase<Post, HubContext>, IPostDal
    {
        public override async Task<Post> Get(Expression<Func<Post, bool>> filter)
        {
            using (var context = new HubContext())
            {
                return await context
                    .Set<Post>()
                    .Include(x => x.Likes)
                    .Include(x => x.Dislikes)
                    .Include(x => x.Tags)
                    .SingleOrDefaultAsync(filter);
            }
        }

        public async override Task<IList<Post>> GetList(PaginationParameters pagination, FilterParameters filter)
        {

            using (var context = new HubContext())
            {
                var _result = filter.Filter == String.Empty
                    ? context
                        .Set<Post>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Include(x => x.Tags)
                    : context
                        .Set<Post>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Include(x => x.Tags)
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

        public override async Task<IList<Post>> GetList(PaginationParameters pagination, Expression<Func<Post, bool>> filter = null)
        {
            using (var context = new HubContext())
            {
                var _result = filter == null
                    ? context   
                        .Set<Post>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                    : context
                        .Set<Post>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Where(filter);

                var result = pagination == null
                    ? await _result.ToListAsync()
                    : await _result.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

                return result;

            }
        }

        public async Task<List<User>> GetDislikers(int postId, PaginationParameters pagination)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Post>()
                                .Where(x => x.Id == postId)
                                .SelectMany(x => x.Dislikes)
                                .Select(x => x.User)
                                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                .Take(pagination.PageSize)
                                .ToListAsync();

                return result;
            }
        }

        public async Task<List<User>> GetLikers(int postId, PaginationParameters pagination)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Post>()
                                .Where(x => x.Id == postId)
                                .SelectMany(x => x.Likes)
                                .Select(x => x.User)
                                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                .Take(pagination.PageSize)
                                .ToListAsync();

                return result;
            }
        }

        public async Task<int> GetLikersCount(int postId)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Post>()
                                .Where(x => x.Id == postId)
                                .SelectMany(x => x.Dislikes)
                                .Select(x => x.User)
                                .CountAsync();

                return result;
            }
        }

        public async Task<int> GetDislikersCount(int postId)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Post>()
                                .Where(x => x.Id == postId)
                                .SelectMany(x => x.Dislikes)
                                .Select(x => x.User)
                                .CountAsync();

                return result;
            }
        }
    }
}