using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfTagDal : EfEntityRepositoryBase<Tag, HubContext>, ITagDal
    {
        
    }
}