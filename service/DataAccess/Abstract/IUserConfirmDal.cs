using Core.DataAccess;
using Core.Entity.Concrete;
using Entity.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserCodeDal : IEntityRepository<UserCode>
    {
    }
}