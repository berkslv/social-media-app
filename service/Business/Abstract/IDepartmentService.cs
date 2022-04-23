using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for Department
    /// </summary>
    public interface IDepartmentService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<DepartmentDto>> GetById(int departmentId);

        /// <summary>
        /// Users containing the given Department are returned in a paged manner.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeUser(int departmentId, PaginationParameters pagination);

        /// <summary>
        /// The faculty containing the given Department is returned.
        /// </summary>
        Task<IDataResult<FacultyDto>> GetByIdIncludeFaculty(int departmentId);

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<DepartmentDto>>> GetList(PaginationParameters pagination, DepartmentFilter filter);

        /// <summary>
        /// The Department associated with the given Faculty is returned.
        /// </summary>
        Task<IDataResult<DepartmentDto>> GetByFacultyId(int facultyId);

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<DepartmentDto>> Add(DepartmentForCreateDto departmentForCreateDto);

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int departmentId);

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<DepartmentDto>> Update(int departmentId, DepartmentForUpdateDto departmentForUpdateDto);
    }
}