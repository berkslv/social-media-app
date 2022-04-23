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
    /// <summary>
    /// Faculty için ana servis implementasyonu
    /// </summary>
    public class FacultyManager : IFacultyService
    {
        private IFacultyDal _facultyDal;
        private IUserDal _userDal;
        private IDepartmentDal _departmentDal;
        private IUniversityDal _universityDal;
        private IMapper _mapper;

        public FacultyManager(IFacultyDal facultyDal,
                                IUniversityDal universityDal,
                                IDepartmentDal departmentDal,
                                IUserDal userDal,
                                IMapper mapper)
        {
            _facultyDal = facultyDal;
            _universityDal = universityDal;
            _departmentDal = departmentDal;
            _userDal = userDal;
            _mapper = mapper;
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<FacultyDto>> GetById(int facultyId)
        {
            // Faculty is returned with the given id.
            var faculty = await _facultyDal.Get(p => p.Id == facultyId);

            // Faculty is checked. 
            if (faculty is null)
            {
                return new ErrorDataResult<FacultyDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<FacultyDto>(faculty);

            // The mapped result is returned.
            return new SuccessDataResult<FacultyDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// The Faculty associated with the given University is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<FacultyDto>> GetByUniversityId(int universityId)
        {
            // The University under Faculty with the given University Id is returned.
            var faculty = await _facultyDal.Get(p => p.UniversityId == universityId);

            // University is controlled. 
            if (faculty is null)
            {
                return new ErrorDataResult<FacultyDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<FacultyDto>(faculty);

            // The mapped result is returned.
            return new SuccessDataResult<FacultyDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<FacultyDto>>> GetList(PaginationParameters pagination, FacultyFilter filter)
        {
            // Expression is created with the given filter.
            filter.CreateQuery();

            // List of Faculty is returned with the given id.
            var faculties = await _facultyDal.GetList(pagination, filter);

            // The existence of the List of Faculty is checked. 
            if (!faculties.Any())
            {
                return new ErrorDataListResult<List<FacultyDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Number of Faculty is returned for pagination. 
            var facultiesCount = await _facultyDal.Count(filter);

            // The result is mapped.
            var result = _mapper.Map<List<FacultyDto>>(faculties);

            // The mapped result is returned.
            return new SuccessDataListResult<List<FacultyDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, facultiesCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<FacultyDto>> Add(FacultyForCreateDto facultyForCreateDto)
        {
            // The given Relational field, University, is returned.
            var university = await _universityDal.Get(x => x.Id == facultyForCreateDto.UniversityId);

            // University is controlled.
            if (university is null)
            {
                return new ErrorDataResult<FacultyDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Faculty is created
            var faculty = new Faculty
            {
                Name = facultyForCreateDto.Name,
                Latitude = facultyForCreateDto.Latitude,
                Altitude = facultyForCreateDto.Altitude,
                Address = facultyForCreateDto.Address,
                University = university
            };

            // Added to the created Faculty Database
            var addedFaculty = await _facultyDal.Add(faculty);

            // The added entity returned from the database is mapped.
            var result = _mapper.Map<FacultyDto>(addedFaculty);
            
            // The mapped result is returned.
            return new SuccessDataResult<FacultyDto>(result, Messages.Entity.Added, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int facultyId)
        {
            // Faculty is returned with the given id.
            var faculty = await _facultyDal.Get(x => x.Id == facultyId);

            // Faculty presence is checked.
            if (faculty is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Faculty is deleted.
            await _facultyDal.Delete(faculty);

            // Successful operation is returned.
            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }


        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<FacultyDto>> Update(int facultyId, FacultyForUpdateDto facultyForUpdateDto)
        {
            // It is returned with the Faculty id to be updated.
            var faculty = await _facultyDal.Get(x => x.Id == facultyId);

            // Faculty presence is checked.
            if (faculty is null)
            {
                return new ErrorDataResult<FacultyDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Required fields are updated.
            faculty = _mapper.Map<FacultyForUpdateDto, Faculty>(facultyForUpdateDto, faculty);

            // Faculty is updated.
            var updatedFaculty = await _facultyDal.Update(faculty);

            // The entity that is updated and returned from the database is mapped.
            var result = _mapper.Map<FacultyDto>(updatedFaculty);

            // The mapped result is returned.
            return new SuccessDataResult<FacultyDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// The university containing the given Faculty is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<UniversityDto>> GetByIdIncludeUniversity(int facultyId)
        {
            // Faculty is returned with the given id.
            var faculty = await _facultyDal.Get(x => x.Id == facultyId);

            // Faculty presence is checked.
            if (faculty is null)
            {
                return new ErrorDataResult<UniversityDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The University containing the relevant Faculty is returned.
            var university = await _universityDal.Get(x => x.Faculties.Contains(faculty));
            
            // University presence is checked.
            if (university is null)
            {
                return new ErrorDataResult<UniversityDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The taken University is mapped.
            var result = _mapper.Map<UniversityDto>(university);

            // The mapped result is returned.
            return new SuccessDataResult<UniversityDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// The Departments containing the given Faculty are returned in a paged manner.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<DepartmentDto>>> GetByIdIncludeDepartment(int facultyId, PaginationParameters pagination)
        {
            // The entire Department containing the given Faculty id is returned.
            var departments = await _departmentDal.GetList(pagination, x => x.Id == facultyId);

            // List of Department control is done.
            if (!departments.Any())
            {
                return new ErrorDataListResult<List<DepartmentDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Number is taken for pagination.
            var departmentsCount = await _departmentDal.Count(x => x.Id == facultyId);
            
            // The result is mapped.
            var result = _mapper.Map<List<DepartmentDto>>(departments);

            // The mapped result is returned.
            return new SuccessDataListResult<List<DepartmentDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, departmentsCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// Users containing the given Faculty are returned in a paged manner.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeUser(int facultyId, PaginationParameters pagination)
        {
            // All User containing the given Faculty id is returned.
            var users = await _userDal.GetList(x => x.Id == facultyId);

            // List of User control is done.
            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Number is taken for pagination.
            var userCount = await _userDal.Count(x => x.Id == facultyId);

            // The result is mapped.
            var result = _mapper.Map<List<UserDto>>(users);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, userCount, pagination.PageNumber, pagination.PageSize);
        }
    }
}