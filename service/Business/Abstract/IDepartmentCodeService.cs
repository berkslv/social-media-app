using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for Department Code
    /// </summary>
    public interface IDepartmentCodeService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<DepartmentCodeDto>> GetById(int departmentCodeId);
        
        /// <summary>
        /// All departments connected to the department code are returned as a list.
        /// </summary>
        Task<IDataListResult<List<DepartmentDto>>> GetByIdIncludeDepartment(int departmentCodeId, PaginationParameters pagination);
        
        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<DepartmentCodeDto>>> GetList(PaginationParameters pagination, DepartmentCodeFilter filter);
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<DepartmentCodeDto>> Add(DepartmentCodeForCreateDto departmentCodeForCreateDto);
        
        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int departmentCodeId);
        
        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<DepartmentCodeDto>> Update(int departmentCodeId, DepartmentCodeForUpdateDto departmentCodeForUpdateDto);
    }
}