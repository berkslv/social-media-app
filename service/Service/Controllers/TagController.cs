using System.Net;
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
    [Route("api/tags")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class TagController : ControllerExtension
    {
        private ITagService _tagService;
        private IAuthService _authService;
        private ILogger<TagController> _logger;
        public TagController(ITagService tagService, IAuthService authService, ILogger<TagController> logger)
        {
            _tagService = tagService;
            _authService = authService;
            _logger = logger;
        }


        /// <summary>
        /// All tags are returned in a paginated manner according to the pagination parameter.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /tags
        ///
        /// </remarks>
        /// <returns>Paginated tag list</returns>
        /// <response code="200">Paginated tag list</response>
        /// <response code="204">Tag not found and empty body is returned.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] TagFilter filter)
        {
            var result = await _tagService.GetList(pagination, filter);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns tag with given id.
        /// </summary>
        /// <param name="tagId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /tags/{tagId}
        ///
        /// </remarks>
        /// <returns>One tag.</returns>
        /// <response code="200">One tag.</response>
        /// <response code="204">No tag found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{tagId}")]
        public async Task<IActionResult> GetById(int tagId)
        {
            var result = await _tagService.GetById(tagId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Returns all posts of the tag in a paginated form.
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /tags/{tagId}/posts
        ///
        /// </remarks>
        /// <returns>Paginated post list.</returns>
        /// <response code="200">Paginated post list.</response>
        /// <response code="204">The tag could not be found with the given id or the post could not be found under the found tag.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Manager},{Role.Student}")]
        [HttpGet("{tagId}/posts")]
        public async Task<IActionResult> GetByIdIncludePost(int tagId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _tagService.GetByIdIncludePost(tagId, pagination);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Creates a tag with the given dto.
        /// </summary>
        /// <param name="tagForCreateDto"></param>
        /// <returns>Newly created tag.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /tags
        ///     {
        ///         "name": "Goygoy",
        ///         "description" : "Sadece goygoy. Ciddi olma!"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created tag.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPost]
        public async Task<IActionResult> Add(TagForCreateDto tagForCreateDto)
        {
            // var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _tagService.Add(tagForCreateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Updates tag with given dto and id.
        /// </summary>
        /// <param name="tagId"></param>
        /// <param name="tagForUpdateDto"></param>
        /// <returns>Updated tag</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /tags/{tagId}
        ///     {
        ///         "name": "Haaarika",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated tag</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpPut("{tagId}")]
        public async Task<IActionResult> Update(int tagId, TagForUpdateDto tagForUpdateDto)
        {
            var result = await _tagService.Update(tagId, tagForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Deletes the tag with the given id.
        /// </summary>
        /// <param name="tagId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /tags/{tagId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Manager}")]
        [HttpDelete("{tagId}")]
        public async Task<IActionResult> Delete(int tagId)
        {
            var result = await _tagService.Delete(tagId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}