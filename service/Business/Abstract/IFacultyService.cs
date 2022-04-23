using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for Faculty
    /// </summary>
    public interface IFacultyService
    {

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<FacultyDto>> GetById(int facultyId);

        /// <summary>
        /// The university containing the given Faculty is returned.
        /// </summary>
        Task<IDataResult<UniversityDto>> GetByIdIncludeUniversity(int facultyId);

        /// <summary>
        /// The Departments containing the given Faculty are returned in a paged manner.
        /// </summary>
        Task<IDataListResult<List<DepartmentDto>>> GetByIdIncludeDepartment(int facultyId, PaginationParameters pagination);

        /// <summary>
        /// Users containing the given Faculty are returned in a paged manner.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeUser(int facultyId, PaginationParameters pagination);

        /// <summary>
        /// The Faculty associated with the given University is returned.
        /// </summary>
        Task<IDataResult<FacultyDto>> GetByUniversityId(int universityId);

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<FacultyDto>>> GetList(PaginationParameters pagination, FacultyFilter filter);

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<FacultyDto>> Add(FacultyForCreateDto facultyForCreateDto);

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int facultyId);

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<FacultyDto>> Update(int facultyId, FacultyForUpdateDto facultyForUpdateDto);
    }
}