using System.Security.Claims;
using Business.Abstract;
using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using Entity.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/departments")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class DepartmentController : ControllerExtension
    {
        private IDepartmentService _departmentService;
        private IAuthService _authService;
        private ILogger<DepartmentController> _logger;

        public DepartmentController(IDepartmentService departmentService,
                                     IAuthService authService,
                                     ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// The whole department is returned according to the pagination parameter in a paginated manner.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /departments
        ///
        /// </remarks>
        /// <returns>Paged department list</returns>
        /// <response code="200">Paged department list</response>
        /// <response code="204">The department was not found and an empty body is returned.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] DepartmentFilter filter)
        {
            var result = await _departmentService.GetList(pagination, filter);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns the department with the given id.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /departments/{departmentId}
        ///
        /// </remarks>
        /// <returns>One department.</returns>
        /// <response code="200">One department.</response>
        /// <response code="204">The department could not be found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetById(int departmentId)
        {
            var result = await _departmentService.GetById(departmentId);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Returns the faculty of the department with the given id.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /departments/{departmentId}
        ///
        /// </remarks>
        /// <returns>One faculty.</returns>
        /// <response code="200">One faculty.</response>
        /// <response code="204">The department could not be found with the given id or the faculty of the department could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{departmentId}/faculty")]
        public async Task<IActionResult> GetByIdIncludeFaculty(int departmentId)
        {
            var result = await _departmentService.GetByIdIncludeFaculty(departmentId);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns the users of the department with the given id.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /departments/{departmentId}
        ///
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">The department could not be found with the given id or the user of the department could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{departmentId}/users")]
        public async Task<IActionResult> GetByIdIncludeUser(int departmentId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _departmentService.GetByIdIncludeUser(departmentId, pagination);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Creates a department with the given dto.
        /// </summary>
        /// <param name="departmentForCreateDto"></param>
        /// <returns>Newly created department</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /departments
        ///     {
        ///         "departmentCodeId": 1,
        ///         "facultyId": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created department</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPost]
        public async Task<IActionResult> Add(DepartmentForCreateDto departmentForCreateDto)
        {
            var result = await _departmentService.Add(departmentForCreateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Updates the department with the given dto.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentForUpdateDto"></param>
        /// <returns>Updated department</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /departments/{departmentId}
        ///     {
        ///         "departmentCodeId": 2,
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated department</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPut("{departmentId}")]
        public async Task<IActionResult> Update(int departmentId, DepartmentForUpdateDto departmentForUpdateDto)
        {
            var result = await _departmentService.Update(departmentId, departmentForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Deletes the department with the given id.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /departments/{departmentId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> Delete(int departmentId)
        {
            var result = await _departmentService.Delete(departmentId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}