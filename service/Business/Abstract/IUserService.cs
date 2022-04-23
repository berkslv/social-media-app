using System.Security.Claims;
using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for User 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<UserDto>> GetById(int userId);
        
        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetList(PaginationParameters pagination, UserFilter filter);
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<UserDto>> Add(UserForCreateDto userForCreateDto);
        
        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int userId);
        
        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<UserDto>> Update(int userId, UserForUpdateDto userForUpdateDto);
        
        /// <summary>
        /// Returns the user who came with the token.
        /// </summary>
        Task<IDataResult<UserDto>> GetMe(ClaimsPrincipal user);
    }
}