using System.Security.Claims;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;

namespace Business.Abstract
{
    /// <summary>
    /// Helper service for Auth using User. 
    /// </summary>
    public interface IAuthUserService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<User>> GetById(int userId);

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<User> Add(User user);

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IResult> Update(User user);

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(User user);

        /// <summary>
        /// Returns the users role.
        /// </summary>
        Task<List<OperationClaim>> GetClaims(User user);

        /// <summary>
        /// Retrieves user by mail
        /// </summary>
        Task<IDataResult<User>> GetByMail(string email);

        /// <summary>
        /// Retrieves user by username
        /// </summary>
        Task<IDataResult<User>> GetByUsername(string username);
    }
}