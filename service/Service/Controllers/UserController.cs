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
    [Route("api/users")]
    [ApiController]
    [ValidateModel]
    public class UserController : ControllerExtension
    {
        private IUserService _userService;
        private ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        
        /// <summary>
        /// Verilen id ile kullanıcı döndürür.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /users/me
        ///
        /// </remarks>
        /// <returns>Bir adet kullanıcı.</returns>
        /// <response code="200">Bir adet kullanıcı.</response>
        /// <response code="204">Verilen id ile kullanıcı bulunamamıştır.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("me")]
        public async Task<IActionResult> GetMe()
        {
            var result = await _userService.GetMe(HttpContext.User);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// All users are returned in a paginated manner according to the pagination parameter.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /users
        ///
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">User not found and returns empty body.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] UserFilter filter)
        {
            var result = await _userService.GetList(pagination, filter);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        
        /// <summary>
        /// Returns the user with the given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /users/{userId}
        ///
        /// </remarks>
        /// <returns>One user.</returns>
        /// <response code="200">One user.</response>
        /// <response code="204">The user with the given id could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetById(int userId)
        {
            var result = await _userService.GetById(userId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Verilen dto ile kullanıcı oluşturur.
        /// </summary>
        /// <param name="userForCreateDto"></param>
        /// <returns>Newly created user.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /users
        ///     {
        ///         "email" : "berkslv4@nku.edu.tr",
        ///         "password": "strapiPassword0",
        ///         "name":"Berk selvi",
        ///         "username":"berkselvi_dev_4",
        ///         "role":"Student",
        ///         "facultyId":1,
        ///         "universityId":1,
        ///         "departmentId":1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created user.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin}")]
        [HttpPost]
        public async Task<IActionResult> Add(UserForCreateDto userForCreateDto)
        {
            var result = await _userService.Add(userForCreateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);

        }


        /// <summary>
        /// Updates user with given dto and id.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userForUpdateDto"></param>
        /// <returns>Updated user.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /users/{userId}
        ///     {
        ///         "name": "Trakya Usersi",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated user.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin}")]
        [HttpPut("{userId}")]
        public async Task<IActionResult> Update(int userId, UserForUpdateDto userForUpdateDto)
        {
            var result = await _userService.Update(userId, userForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);

        }


        /// <summary>
        /// Deletes the user with the given id.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /users/{userId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin}")]
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userService.Delete(userId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}