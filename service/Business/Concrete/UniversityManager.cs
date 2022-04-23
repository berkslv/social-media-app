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
using Microsoft.AspNetCore.Mvc;

namespace Business.Concrete
{
    /// <summary>
    /// University için ana servis implementasyonu
    /// </summary>
    public class UniversityManager : IUniversityService
    {
        private IUniversityDal _universityDal;
        private IFacultyDal _facultyDal;
        private IMapper _mapper;
        private IUserDal _userDal;

        public UniversityManager(IUniversityDal universityDal, IFacultyDal facultyDal, IUserDal userDal, IMapper mapper)
        {
            _universityDal = universityDal;
            _facultyDal = facultyDal;
            _userDal = userDal;
            _mapper = mapper;
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<UniversityDto>> GetById(int universityId)
        {
            // University is returned with the given id.
            var university = await _universityDal.Get(p => p.Id == universityId);

            // If University is not found
            if (university is null)
            {
                return new ErrorDataResult<UniversityDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped
            var result = _mapper.Map<UniversityDto>(university);

            // The mapped result is returned.
            return new SuccessDataResult<UniversityDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UniversityDto>>> GetList(PaginationParameters pagination, UniversityFilter filter)
        {
            // Expression is created with the given filter.
            filter.CreateQuery();

            // The List of University is returned paginated.
            var universities = await _universityDal.GetList(pagination, filter);

            // If no University is found.
            if (!universities.Any())
            {
                return new ErrorDataListResult<List<UniversityDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // All University pieces are taken for pagination.
            var universitiesCount = await _universityDal.Count(filter);

            // The University found is mapped.
            var result = _mapper.Map<List<UniversityDto>>(universities);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UniversityDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, universitiesCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        public async Task<IDataResult<UniversityDto>> Add(UniversityForCreateDto universityForCreateDto)
        {
            // The University is created with the given dto.
            var university = new University
            {
                Name = universityForCreateDto.Name,
                City = universityForCreateDto.City.ToString(),
                FoundationYear = universityForCreateDto.FoundationYear,
            };

            // The created University is added to the database, and the University added to the database is returned.
            var addedUniversity = await _universityDal.Add(university);

            // Rotating University is mapped.
            var result = _mapper.Map<UniversityDto>(addedUniversity);
            
            // The mapped result is returned.
            return new SuccessDataResult<UniversityDto>(result, Messages.Entity.Added, HttpStatusCode.Created);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int universityId)
        {
            // University is returned with the given id.
            var university = await _universityDal.Get(x => x.Id == universityId);
            
            // Check if there is a university.
            if (university is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // University is deleted.
            await _universityDal.Delete(university);

            // Successful result is returned.
            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="400"></response>
        /// <response code="200"></response>
        public async Task<IDataResult<UniversityDto>> Update(int universityId, UniversityForUpdateDto universityForUpdateDto)
        {
            // University is returned with the given id.
            var university = await _universityDal.Get(x => x.Id == universityId);

            // Check if there is a university.
            if (university is null)
            {
                return new ErrorDataResult<UniversityDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Required fields are updated.
            var mappedUniversity = _mapper.Map<UniversityForUpdateDto, University>(universityForUpdateDto, university);

            // The University is updated in the database, the updated entity returns.
            var updatedUniversity = await _universityDal.Update(mappedUniversity);

            // The returning University is mapped.
            var result = _mapper.Map<UniversityDto>(updatedUniversity);

            // The mapped entity is returned.
            return new SuccessDataResult<UniversityDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// All faculties affiliated to the university are returned in the form of a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<FacultyDto>>> GetByIdIncludeFaculty(int universityId, PaginationParameters pagination)
        {
            // All Faculties that match the given UniversityId are returned.
            var faculties = await _facultyDal.GetList(pagination, x => x.UniversityId == universityId);

            // It is checked if there are any returning Faculties.
            if (!faculties.Any())
            {
                return new ErrorDataListResult<List<FacultyDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // All Faculty numbers are taken for paging.
            var facultiesCount = await _facultyDal.Count(x => x.UniversityId == universityId);

            // The result is mapped.
            var result = _mapper.Map<List<FacultyDto>>(faculties);

            // The mapped result is returned.
            return new SuccessDataListResult<List<FacultyDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, facultiesCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// All users affiliated with the university are returned as a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeUser(int universityId, PaginationParameters pagination)
        {
            // All Users that match the given UniversityId are returned.
            var users = await _userDal.GetList(pagination, x => x.UniversityId == universityId);
            
            // It is checked if there are any returning Users.
            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // All Users are taken for paging.
            var usersCount = await _userDal.Count(x => x.UniversityId == universityId);

            // The result is mapped.
            var result = _mapper.Map<List<UserDto>>(users);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }
    }
}