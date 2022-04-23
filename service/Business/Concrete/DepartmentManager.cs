using System.Net;
using AutoMapper;
using Business.Abstract;
using Core.Constants;
using Core.Utilities.Query;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private IDepartmentDal _departmentDal;
        private IFacultyDal _facultyDal;
        private IUserDal _userDal;
        private IDepartmentCodeDal _departmentCodeDal;
        private IMapper _mapper;

        public DepartmentManager(IDepartmentDal departmentDal,
                                    IFacultyDal facultyDal,
                                    IDepartmentCodeDal departmentCodeDal,
                                    IUserDal userDal,
                                    IMapper mapper)
        {
            _departmentDal = departmentDal;
            _facultyDal = facultyDal;
            _departmentCodeDal = departmentCodeDal;
            _userDal = userDal;
            _mapper = mapper;
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<DepartmentDto>> GetById(int departmentId)
        {
            // Department is returned with the given id.
            var department = await _departmentDal.Get(p => p.Id == departmentId);

            // Department entity is checked.
            if (department is null)
            {
                return new ErrorDataResult<DepartmentDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<Department, DepartmentDto>(department);

            // The mapped result is returned.
            return new SuccessDataResult<DepartmentDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<DepartmentDto>>> GetList(PaginationParameters pagination, DepartmentFilter filter)
        {
            // Expression is created with the given filter.
            filter.CreateQuery();

            // List of Department is returned with the given id.
            var departments = await _departmentDal.GetList(pagination, filter);

            // List of Department entity is checked. 
            if (!departments.Any())
            {
                return new ErrorDataListResult<List<DepartmentDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Department is returned for pagination. 
            var departmentCount = await _departmentDal.Count(filter);

            // The result is mapped.
            var result = _mapper.Map<List<DepartmentDto>>(departments);

            // The mapped result is returned.
            return new SuccessDataListResult<List<DepartmentDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, departmentCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<DepartmentDto>> Add(DepartmentForCreateDto departmentForCreateDto)
        {
            // Faculty, which is the given Relational field, is returned.
            var faculty = await _facultyDal.Get(x => x.Id == departmentForCreateDto.FacultyId);

            // Faculty is checked.
            if (faculty is null)
            {
                return new ErrorDataResult<DepartmentDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // The DepartmentCode, which is the given Relational field, is returned.
            var departmentCode = await _departmentCodeDal.Get(x => x.Id == departmentForCreateDto.DepartmentCodeId);

            // DepartmentCode is checked.
            if (departmentCode is null)
            {
                return new ErrorDataResult<DepartmentDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }


            // There cannot be more than one department with the same department code under the same faculty.
            var departmentControl = await _departmentDal.Get(x => x.Faculty == faculty && x.DepartmentCode == departmentCode);

            if (departmentControl is not null)
            {
                return new ErrorDataResult<DepartmentDto>(Messages.Entity.NotAdded, HttpStatusCode.BadRequest);
            }

            // Department is created
            var department = new Department
            {
                Faculty = faculty,
                DepartmentCode = departmentCode,
            };

            // It is added to the Department Database.
            var addedDepartment = await _departmentDal.Add(department);

            // Since it contains Join, the data that is added and returned is not fully updated, so it is returned again.
            var gettedDepartment = await _departmentDal.Get(x => x.Id == addedDepartment.Id);

            // The attached data is returned and mapped.
            var result = _mapper.Map<DepartmentDto>(gettedDepartment);

            // The result is returned.
            return new SuccessDataResult<DepartmentDto>(result, Messages.Entity.Added, HttpStatusCode.Created);
        }


        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int departmentId)
        {
            // Department is returned with the given id.
            var department = await _departmentDal.Get(x => x.Id == departmentId);

            // Department is checked.
            if (department is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Department is deleted.
            await _departmentDal.Delete(department);

            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }


        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<DepartmentDto>> Update(int departmentId, DepartmentForUpdateDto departmentForUpdateDto)
        {
            // Department is returned with the given id.
            var department = await _departmentDal.Get(x => x.Id == departmentId);

            // Department entity is checked.
            if (department is null)
            {
                return new ErrorDataResult<DepartmentDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Required fields are mapped.
            var mappedDepartment = _mapper.Map<DepartmentForUpdateDto, Department>(departmentForUpdateDto, department);

            // It is updated.
            var updatedDepartment = await _departmentDal.Update(mappedDepartment);

            // It is returned again because it contains a join.
            var newDepartment = await _departmentDal.Get(x => x.Id == departmentId);

            // The result is mapped.
            var result = _mapper.Map<DepartmentDto>(newDepartment);

            // The mapped result is returned.
            return new SuccessDataResult<DepartmentDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// The Department associated with the given Faculty is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<DepartmentDto>> GetByFacultyId(int facultyId)
        {
            // Department is returned with the given Faculty Id.
            var department = await _departmentDal.Get(x => x.FacultyId == facultyId);

            // Its presence is checked.
            if (department is null)
            {
                return new ErrorDataResult<DepartmentDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<DepartmentDto>(department);

            // The mapped result is returned.
            return new SuccessDataResult<DepartmentDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// Users containing the given Department are returned in a paged manner.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeUser(int departmentId, PaginationParameters pagination)
        {
            // All User containing the given Faculty id is returned.
            var users = await _userDal.GetList(x => x.Id == departmentId);

            // List of User control is done.
            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Number is taken for pagination.
            var usersCount = await _userDal.Count(x => x.Id == departmentId);

            // The result is mapped.
            var result = _mapper.Map<List<UserDto>>(users);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The faculty containing the given Department is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<FacultyDto>> GetByIdIncludeFaculty(int departmentId)
        {
            // The Department is returned with the DepartmentId.
            var department = await _departmentDal.Get(x => x.Id == departmentId);

            // Department control.
            if (department is null)
            {
                return new ErrorDataResult<FacultyDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The Faculty is rotated with the Department.
            var faculty = await _facultyDal.Get(x => x.Departments.Contains(department));

            // Faculty control is done.
            if (faculty is null)
            {
                return new ErrorDataResult<FacultyDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<FacultyDto>(faculty);

            // The mapped result is returned.
            return new SuccessDataResult<FacultyDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }
    }
}