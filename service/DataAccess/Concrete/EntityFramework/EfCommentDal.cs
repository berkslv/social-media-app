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
    public class EfCommentDal : EfEntityRepositoryBase<Comment, HubContext>, ICommentDal
    {
        public override async Task<Comment> Get(Expression<Func<Comment, bool>> filter)
        {
            using (var context = new HubContext())
            {
                return await context
                    .Set<Comment>()
                    .Include(x => x.Likes)
                    .Include(x => x.Dislikes)
                    .Include(x => x.Author)
                    .SingleOrDefaultAsync(filter);
            }
        }

        public async override Task<IList<Comment>> GetList(PaginationParameters pagination, FilterParameters filter)
        {

            using (var context = new HubContext())
            {
                var _result = filter.Filter == String.Empty
                    ? context
                        .Set<Comment>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Include(x => x.Author)
                    : context
                        .Set<Comment>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Include(x => x.Author)
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

        public override async Task<IList<Comment>> GetList(PaginationParameters pagination, Expression<Func<Comment, bool>> filter = null)
        {
            using (var context = new HubContext())
            {
                var _result = filter == null
                    ? context
                        .Set<Comment>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Include(x => x.Author)
                    : context
                        .Set<Comment>()
                        .Include(x => x.Likes)
                        .Include(x => x.Dislikes)
                        .Include(x => x.Author)
                        .Where(filter);

                var result = pagination == null
                    ? await _result.ToListAsync()
                    : await _result.Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToListAsync();

                return result;
            }
        }

        public async Task<List<User>> GetDislikers(int commentId, PaginationParameters pagination)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Comment>()
                                .Where(x => x.Id == commentId)
                                .SelectMany(x => x.Dislikes)
                                .Select(x => x.User)
                                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                .Take(pagination.PageSize)
                                .ToListAsync();

                return result;
            }
        }

        public async Task<List<User>> GetLikers(int commentId, PaginationParameters pagination)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Comment>()
                                .Where(x => x.Id == commentId)
                                .SelectMany(x => x.Likes)
                                .Select(x => x.User)
                                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                                .Take(pagination.PageSize)
                                .ToListAsync();

                return result;
            }
        }

        public async Task<int> GetLikersCount(int commentId)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Comment>()
                                .Where(x => x.Id == commentId)
                                .SelectMany(x => x.Dislikes)
                                .Select(x => x.User)
                                .CountAsync();

                return result;
            }
        }

        public async Task<int> GetDislikersCount(int commentId)
        {
            using (var context = new HubContext())
            {
                var result = await context
                                .Set<Comment>()
                                .Where(x => x.Id == commentId)
                                .SelectMany(x => x.Dislikes)
                                .Select(x => x.User)
                                .CountAsync();

                return result;
            }
        }
    }
}