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
    [Route("api/comments")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class CommentController : ControllerExtension
    {
        private ICommentService _commentService;
        private IAuthService _authService;
        private ILogger<CommentController> _logger;
        public CommentController(ICommentService commentService ,IAuthService authService, ILogger<CommentController> logger)
        {
            _commentService = commentService;
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// All comment is returned according to the pagination parameter in a paginated manner.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /comments
        ///
        /// </remarks>
        /// <returns>Paginated list of comments</returns>
        /// <response code="200">Paginated list of comments</response>
        /// <response code="204">No comments found and empty body is returned.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] CommentFilter filter)
        {
            var result = await _commentService.GetList(pagination, filter);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns a comment with the given id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /comments/{commentId}
        /// 
        /// </remarks>
        /// <returns>One comment.</returns>
        /// <response code="200">One comment.</response>
        /// <response code="204">No comments were found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{commentId}")]
        public async Task<IActionResult> GetById(int commentId)
        {
            var result = await _commentService.GetById(commentId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }



        /// <summary>
        /// Users who liked the comment with the given id are returned.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /comments/{commentId}/likes
        /// 
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">The post with the given id could not be found or the user who liked the comment could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{commentId}/likes")]
        public async Task<IActionResult> GetByIdIncludeLikes(int commentId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _commentService.GetByIdIncludeLikes(commentId, pagination);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Users who do not like the comment with the given id are returned.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /comments/{commentId}/dislikes
        /// 
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">The post with the given id could not be found or the user who did not like the comment could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{commentId}/dislikes")]
        public async Task<IActionResult> GetByIdIncludeDislikes(int commentId, [FromQuery] PaginationParameters pagination)
        {
            var result = await _commentService.GetByIdIncludeDislikes(commentId, pagination);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// The author of the comment is retrieved with the given id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /comments/{commentId}/author
        ///
        /// </remarks>
        /// <returns>One user.</returns>
        /// <response code="200">One user.</response>
        /// <response code="204">No post was found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{commentId}/author")]
        public async Task<IActionResult> GetByIdIncludeAuthor(int commentId)
        {
            var result = await _commentService.GetByIdIncludeAuthor(commentId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Creates a comment with the given dto.
        /// </summary>
        /// <param name="commentForCreateDto"></param>
        /// <returns>Newly created comment.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /comments
        ///     {
        ///         "content" : "Naber dostlar",
        ///         "tagId" : 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created comment.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPost]
        public async Task<IActionResult> Add(CommentForCreateDto commentForCreateDto)
        {
            var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _commentService.Add(commentForCreateDto, currentUser.Data);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// The comment is updated with the given dto.
        /// </summary>
        /// <param name="commentId"></param>
        /// <param name="commentForUpdateDto"></param>
        /// <returns>Updated comment</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /comments/{commentId}
        ///     {
        ///         "content" : "Hoba dostlar",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated comment</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPut("{commentId}")]
        public async Task<IActionResult> Update(int commentId, CommentForUpdateDto commentForUpdateDto)
        {
            var result = await _commentService.Update(commentId, commentForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// The post is liked with the given id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns>Liked post</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /comments/{commentId}/like
        ///
        /// </remarks>
        /// <response code="200">Liked post</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPut("{commentId}/like")]
        public async Task<IActionResult> Like(int commentId)
        {
            var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _commentService.Like(commentId, currentUser.Data);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// The post with the given id is disliked.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns>Disliked post</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /comments/{commentId}/dislike
        ///
        /// </remarks>
        /// <response code="200">Disliked post</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPut("{commentId}/dislike")]
        public async Task<IActionResult> Dislike(int commentId)
        {
            var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _commentService.Dislike(commentId, currentUser.Data);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// The post is deleted with the given id.
        /// </summary>
        /// <param name="commentId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /comments/{commentId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete(int commentId)
        {
            var result = await _commentService.Delete(commentId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}