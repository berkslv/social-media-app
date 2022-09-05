using System.Net;
using Business.Abstract;
using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Query;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/faculties")]
    [ApiController]
    [ValidateModel]
    public class FacultyController : ControllerExtension
    {
        private IFacultyService _facultyService;

        private ILogger<FacultyController> _logger;
        public FacultyController(IFacultyService facultyService, ILogger<FacultyController> logger)
        {
            _facultyService = facultyService;
            _logger = logger;
        }

        /// <summary>
        /// The entire faculty is returned in a paginated manner according to the pagination parameter.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /faculties
        ///
        /// </remarks>
        /// <returns>Paginated faculty list</returns>
        /// <response code="200">Paginated faculty list</response>
        /// <response code="204">The faculty is not found and the empty body is returned.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] FacultyFilter filter)
        {
            var result = await _facultyService.GetList(pagination, filter);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }
        

        /// <summary>
        /// Returns faculty with the given id.
        /// </summary>
        /// <param name="facultyId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /faculties/{facultyId}
        ///
        /// </remarks>
        /// <returns>One faculty.</returns>
        /// <response code="200">One faculty.</response>
        /// <response code="204">The faculty could not be found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{facultyId}")]
        public async Task<IActionResult> GetById(int facultyId)
        {
            var result = await _facultyService.GetById(facultyId);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns the university of the faculty with the given id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /faculties/{facultyId}/university
        ///
        /// </remarks>
        /// <returns>One university.</returns>
        /// <response code="200">One university.</response>
        /// <response code="204">The faculty could not be found with the given id or a university of the faculty could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{facultyId}/university")]
        public async Task<IActionResult> GetByIdIncludeUniversity(int facultyId)
        {
            var result = await _facultyService.GetByIdIncludeUniversity(facultyId);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns the departments of the faculty with the given id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /faculties/{facultyId}/departments
        ///
        /// </remarks>
        /// <returns>Paged department list</returns>
        /// <response code="200">Paged department list</response>
        /// <response code="204">The faculty could not be found with the given id or a department of the faculty could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{facultyId}/departments")]
        public async Task<IActionResult> GetByIdIncludeDepartment(int facultyId, [FromQuery] PaginationParameters pagination)
        {
            Console.WriteLine(facultyId);
            var result = await _facultyService.GetByIdIncludeDepartment(facultyId, pagination);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns users of faculty with given id
        /// </summary>
        /// <param name="facultyId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /faculties/{facultyId}/users
        ///
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">The faculty could not be found with the given id or a user of the faculty could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{facultyId}/users")]
        public async Task<IActionResult> GetByIdIncludeUsers(int facultyId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _facultyService.GetByIdIncludeUser(facultyId, pagination);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Creates a faculty with the given dto.
        /// </summary>
        /// <param name="facultyForCreateDto"></param>
        /// <returns>Newly created faculty</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /faculties
        ///     {
        ///         "name": "Çorlu mühendislik",
        ///         "altitude": 21.213124,
        ///         "latitude": 43.213412,
        ///         "address": "Çorlu, silahtarağa mah.",
        ///         "universityId": 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created faculty</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPost]
        public async Task<IActionResult> Add(FacultyForCreateDto facultyForCreateDto)
        {
            var result = await _facultyService.Add(facultyForCreateDto);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Updates faculty with given dto and id.
        /// </summary>
        /// <param name="facultyId"></param>
        /// <param name="facultyForUpdateDto"></param>
        /// <returns>Updated faculty</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /faculties/{facultyId}
        ///     {
        ///         "name": "Çorlu mimarlık",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated faculty</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPut("{facultyId}")]
        public async Task<IActionResult> Update(int facultyId, FacultyForUpdateDto facultyForUpdateDto)
        {
            var result = await _facultyService.Update(facultyId, facultyForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Deletes the faculty with the given id.
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /faculties/{facultyId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpDelete("{facultyId}")]
        public async Task<IActionResult> Delete(int facultyId)
        {
            var result = await _facultyService.Delete(facultyId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}