using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entity.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserCodeDal : EfEntityRepositoryBase<UserCode, HubContext>, IUserCodeDal
    {
        
    }
}