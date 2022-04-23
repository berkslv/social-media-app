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
    public class DepartmentCodeManager : IDepartmentCodeService
    {
        private IDepartmentCodeDal _departmentCodeDal;
        private IDepartmentDal _departmentDal;
        private IMapper _mapper;

        public DepartmentCodeManager(IDepartmentCodeDal departmentCodeDal, IDepartmentDal departmentDal, IMapper mapper)
        {
            _departmentCodeDal = departmentCodeDal;
            _departmentDal = departmentDal;
            _mapper = mapper;
        }


        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<DepartmentCodeDto>> GetById(int departmentCodeId)
        {
            // DepartmentCode is returned with the given id.
            var departmentCode = await _departmentCodeDal.Get(p => p.Id == departmentCodeId);

            // DepartmentCode is checked
            if (departmentCode is null)
            {
                return new ErrorDataResult<DepartmentCodeDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped
            var result = _mapper.Map<DepartmentCodeDto>(departmentCode);

            // The mapped result is returned.
            return new SuccessDataResult<DepartmentCodeDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<DepartmentCodeDto>>> GetList(PaginationParameters pagination, DepartmentCodeFilter filter)
        {
            // Expression is created with the given filter.
            filter.CreateQuery();

            // The List of DepartmentCode is returned paginated.
            var departmentCodes = await _departmentCodeDal.GetList(pagination, filter);

            // If no DepartmentCode is found.
            if (!departmentCodes.Any())
            {
                return new ErrorDataListResult<List<DepartmentCodeDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // All DepartmentCodes are taken for pagination.
            var departmentCodesCount = await _departmentCodeDal.Count(filter);

            // The result is mapped.
            var result = _mapper.Map<List<DepartmentCodeDto>>(departmentCodes);

            // The mapped result is returned.
            return new SuccessDataListResult<List<DepartmentCodeDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, departmentCodesCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<DepartmentCodeDto>> Add(DepartmentCodeForCreateDto departmentCodeForCreateDto)
        {
            // DepartmentCode with the same name is returned.
            var department = await _departmentCodeDal.Get(x => x.Name == departmentCodeForCreateDto.Name);

            // New DepartmentCode is not created if such entity exists 
            // because more than one DepartmentCode with the same name is not created.
            if (department is not null)
            {
                return new ErrorDataResult<DepartmentCodeDto>(Messages.Entity.NotAdded, HttpStatusCode.BadRequest);
            }

            // DepartmentCode is created with the given dto.
            var departmentCode = new DepartmentCode
            {
                Name = departmentCodeForCreateDto.Name,
            };

            // The created DepartmentCode is added to the database, and the DepartmentCode added to the database is returned.
            var addedDepartmentCode = await _departmentCodeDal.Add(departmentCode);

            // The returned DepartmentCode is mapped.
            var result = _mapper.Map<DepartmentCodeDto>(addedDepartmentCode);

            // The mapped result is returned.
            return new SuccessDataResult<DepartmentCodeDto>(result, Messages.Entity.Added, HttpStatusCode.Created);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int departmentCodeId)
        {
            // DepartmentCode is returned with the given id.
            var departmentCode = await _departmentCodeDal.Get(x => x.Id == departmentCodeId);

            // Check if DepartmentCode exists.
            if (departmentCode is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // DepartmentCode is deleted.
            await _departmentCodeDal.Delete(departmentCode);

            // Successful result is returned.
            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }


        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<DepartmentCodeDto>> Update(int departmentCodeId, DepartmentCodeForUpdateDto departmentCodeForUpdateDto)
        {
            // DepartmentCode is returned with the given id.
            var departmentCode = await _departmentCodeDal.Get(x => x.Id == departmentCodeId);

            // Check if DepartmentCode exists.
            if (departmentCode is null)
            {
                return new ErrorDataResult<DepartmentCodeDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Required fields are updated.
            var mappedDepartmentCode = _mapper.Map<DepartmentCodeForUpdateDto, DepartmentCode>(departmentCodeForUpdateDto, departmentCode);

            // DepartmentCode is updated in database, updated entity returns.
            var updatedDepartmentCode = await _departmentCodeDal.Update(mappedDepartmentCode);

            // The returning DepartmentCode is mapped.
            var result = _mapper.Map<DepartmentCodeDto>(updatedDepartmentCode);

            // The mapped entity is returned.
            return new SuccessDataResult<DepartmentCodeDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// All departments connected to the department code are returned as a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<DepartmentDto>>> GetByIdIncludeDepartment(int departmentCodeId, PaginationParameters pagination)
        {
            // All Departments that match the given departmentCodeId are returned.
            var departments = await _departmentDal.GetList(x => x.Id == departmentCodeId);

            // It is checked whether there is a returning Department.
            if (!departments.Any())
            {
                return new ErrorDataListResult<List<DepartmentDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The number of relevant Departments is taken for paging.
            var departmentsCount = await _departmentDal.Count(x => x.Id == departmentCodeId);

            // The result is mapped.
            var result = _mapper.Map<List<DepartmentDto>>(departments);

            // Map edilen sonuç döünlür.
            return new SuccessDataListResult<List<DepartmentDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, departmentsCount, pagination.PageNumber, pagination.PageSize);
        }
    }
}