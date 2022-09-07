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
    [Route("api/universities")]
    [ApiController]
    [ValidateModel]
    public class UniversityController : ControllerExtension
    {
        private IUniversityService _universityService;
        private ILogger<UniversityController> _logger;

        public UniversityController(IUniversityService universityService, ILogger<UniversityController> logger)
        {
            _universityService = universityService;
            _logger = logger;
        }

        /// <summary>
        /// The entire university is returned in a paged manner, according to the pagination parameter.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /universities
        ///
        /// </remarks>
        /// <returns>Paged list of universities</returns>
        /// <response code="200">Paged list of universities</response>
        /// <response code="204">The university is not found and returns an empty body.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] UniversityFilter filter)
        {
            var result = await _universityService.GetList(pagination, filter);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        
        /// <summary>
        /// Returns university with the given id.
        /// </summary>
        /// <param name="universityId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /universities/{universityId}
        ///
        /// </remarks>
        /// <returns>One university</returns>
        /// <response code="200">One university</response>
        /// <response code="204">The university could not be found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{universityId}")]
        public async Task<IActionResult> GetById(int universityId)
        {
            var result = await _universityService.GetById(universityId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Returns all faculties of the university in a paginated form.
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /universities/{universityId}/faculties
        ///
        /// </remarks>
        /// <returns>Paginated faculty list.</returns>
        /// <response code="200">Paginated faculty list.</response>
        /// <response code="204">The university could not be found with the given id or the faculty could not be found under the found university.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{universityId}/faculties")]
        public async Task<IActionResult> GetByIdIncludeFaculty(int universityId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _universityService.GetByIdIncludeFaculty(universityId, pagination);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns all users of the university in a paginated form.
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /universities/{universityId}/users
        ///
        /// </remarks>
        /// <returns>Paginated user list.</returns>
        /// <response code="200">Paginated user list.</response>
        /// <response code="204">University could not be found with the given id, or a user could not be found under the found university.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{universityId}/users")]
        public async Task<IActionResult> GetByIdIncludeUsers(int universityId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _universityService.GetByIdIncludeUser(universityId, pagination);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);

        }


        /// <summary>
        /// Creates a university with the given dto.
        /// </summary>
        /// <param name="universityForCreateDto"></param>
        /// <returns>Newly created university</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /universities
        ///     {
        ///         "name": "Hacılar Üniversitesi",
        ///         "city": "Edirne",
        ///         "foundationYear": 2000
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created university</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin}")]
        [HttpPost]
        public async Task<IActionResult> Add(UniversityForCreateDto universityForCreateDto)
        {
            var result = await _universityService.Add(universityForCreateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);

        }


        /// <summary>
        /// Updates the university with the given dto and id.
        /// </summary>
        /// <param name="universityId"></param>
        /// <param name="universityForUpdateDto"></param>
        /// <returns>Updated university</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /universities/{universityId}
        ///     {
        ///         "name": "Trakya Üniversitesi",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated university</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin}")]
        [HttpPut("{universityId}")]
        public async Task<IActionResult> Update(int universityId, UniversityForUpdateDto universityForUpdateDto)
        {
            var result = await _universityService.Update(universityId, universityForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);

        }


        /// <summary>
        /// Deletes the university with the given id.
        /// </summary>
        /// <param name="universityId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /universities/{universityId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin}")]
        [HttpDelete("{universityId}")]
        public async Task<IActionResult> Delete(int universityId)
        {
            var result = await _universityService.Delete(universityId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}