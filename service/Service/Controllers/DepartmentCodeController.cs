using Business.Abstract;
using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/department-codes")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class DepartmentCodeController : ControllerExtension
    {
        private IDepartmentCodeService _departmentCodeService;

        private ILogger<DepartmentCodeController> _logger;
        public DepartmentCodeController(IDepartmentCodeService departmentCodeService, ILogger<DepartmentCodeController> logger)
        {
            _departmentCodeService = departmentCodeService;
            _logger = logger;
        }


        /// <summary>
        /// All department code is returned according to the pagination parameter in a paginated manner.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /department-codes
        ///
        /// </remarks>
        /// <returns>Paginated department code list</returns>
        /// <response code="200">Paginated department code list</response>
        /// <response code="204">The department code is not found and an empty body is returned.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] DepartmentCodeFilter filter)
        {
            var result = await _departmentCodeService.GetList(pagination, filter);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns the department code with the given id.
        /// </summary>
        /// <param name="departmentCodeId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /department-codes/{departmentCodeId}
        ///
        /// </remarks>
        /// <returns>One department code.</returns>
        /// <response code="200">One department code.</response>
        /// <response code="204">The department code could not be found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{departmentCodeId}")]
        public async Task<IActionResult> GetById(int departmentCodeId)
        {
            var result = await _departmentCodeService.GetById(departmentCodeId);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Returns the departments of the department code with the given id.
        /// </summary>
        /// <param name="departmentCodeId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /department-codes/{departmentId}/departments
        ///
        /// </remarks>
        /// <returns>Paged department list</returns>
        /// <response code="200">Paged department list</response>
        /// <response code="204">The department code could not be found with the given id or the department of the department code could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{departmentCodeId}/departments")]
        public async Task<IActionResult> GetByIdIncludeDepartment(int departmentCodeId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _departmentCodeService.GetByIdIncludeDepartment(departmentCodeId, pagination);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Creates department code with given dto.
        /// </summary>
        /// <param name="departmentCodeForCreateDto"></param>
        /// <returns>Newly created department code</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /department-codes
        ///     {
        ///         "name": "Bilgisayar mühendisliği"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created department code</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentCodeForCreateDto departmentCodeForCreateDto)
        {
            var result = await _departmentCodeService.Add(departmentCodeForCreateDto);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// The department code is updated with the given dto and id.
        /// </summary>
        /// <param name="departmentCodeId"></param>
        /// <param name="departmentCodeForUpdateDto"></param>
        /// <returns>Updated department code</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /department-codes/{departmentCodeId}
        ///     {
        ///         "name": "Makine mühendisliği"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated department code</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPut("{departmentCodeId}")]
        public async Task<IActionResult> Update(int departmentCodeId, DepartmentCodeForUpdateDto departmentCodeForUpdateDto)
        {
            var result = await _departmentCodeService.Update(departmentCodeId, departmentCodeForUpdateDto);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Deletes the department with the given id.
        /// </summary>
        /// <param name="departmentCodeId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /department-codes/{departmentCodeId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpDelete("{departmentCodeId}")]
        public async Task<IActionResult> Delete(int departmentCodeId)
        {
            var result = await _departmentCodeService.Delete(departmentCodeId);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}