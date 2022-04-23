using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for University 
    /// </summary>
    public interface IUniversityService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<UniversityDto>> GetById(int universityId);
        
        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<UniversityDto>>> GetList(PaginationParameters pagination, UniversityFilter filter);
        
        /// <summary>
        /// All faculties affiliated to the university are returned in the form of a list.
        /// </summary>
        Task<IDataListResult<List<FacultyDto>>> GetByIdIncludeFaculty(int universityId, PaginationParameters pagination);
        
        /// <summary>
        /// All users affiliated with the university are returned as a list.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeUser(int universityId, PaginationParameters pagination);
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<UniversityDto>> Add(UniversityForCreateDto universityForCreateDto);
        
        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int universityId);
        
        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<UniversityDto>> Update(int universityId, UniversityForUpdateDto universityForUpdateDto);
    }
}