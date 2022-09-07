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
    [Route("api/posts")]
    [ApiController]
    [Authorize]
    [ValidateModel]
    public class PostController : ControllerExtension
    {
        private IPostService _postService;
        private IAuthService _authService;
        private ILogger<PostController> _logger;
        public PostController(IPostService postService, IAuthService authService, ILogger<PostController> logger)
        {
            _postService = postService;
            _authService = authService;
            _logger = logger;
        }

        /// <summary>
        /// The all posts is returned in a paginated manner, according to the pagination parameter.
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="filter"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /posts
        ///
        /// </remarks>
        /// <returns>Paginated post list</returns>
        /// <response code="200">Paginated post list</response>
        /// <response code="204">The post was not found and an empty body is returned.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PaginationParameters pagination, [FromQuery] PostFilter filter)
        {
            var result = await _postService.GetList(pagination, filter);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Returns post with given id.
        /// </summary>
        /// <param name="postId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /posts/{postId}
        /// 
        /// </remarks>
        /// <returns>One post.</returns>
        /// <response code="200">One post.</response>
        /// <response code="204">No post was found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{postId}")]
        public async Task<IActionResult> GetById(int postId)
        {
            var result = await _postService.GetById(postId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// The comments of the post are returned with the given id.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /posts/{postId}/comments
        /// 
        /// </remarks>
        /// <returns>Paginated list of comments</returns>
        /// <response code="200">Paginated list of comments</response>
        /// <response code="204">The post with the given id could not be found or the comment of the post could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{postId}/comments")]
        public async Task<IActionResult> GetByIdIncludeComment(int postId ,[FromQuery] PaginationParameters pagination)
        {
            var result = await _postService.GetByIdIncludeComment(postId, pagination);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Users who liked the post with the given id are returned.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /posts/{postId}/likes
        /// 
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">The post with the given id could not be found or the user who liked the post could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{postId}/likes")]
        public async Task<IActionResult> GetByIdIncludeLikes(int postId ,[FromQuery] PaginationParameters pagination)
        {
            var result = await _postService.GetByIdIncludeLikes(postId, pagination);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Users who do not like the post with the given id are returned.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="pagination"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /posts/{postId}/dislikes
        /// 
        /// </remarks>
        /// <returns>Paginated user list</returns>
        /// <response code="200">Paginated user list</response>
        /// <response code="204">The post with the given id could not be found or the user who did not like the post could not be found.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{postId}/dislikes")]
        public async Task<IActionResult> GetByIdIncludeDislikes(int postId ,[FromQuery] PaginationParameters pagination)
        {
            var result = await _postService.GetByIdIncludeDislikes(postId, pagination);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// The author of the post is retrieved with the given id.
        /// </summary>
        /// <param name="postId"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /posts/{postId}/author
        ///
        /// </remarks>
        /// <returns>One user</returns>
        /// <response code="200">One user</response>
        /// <response code="204">No post was found with the given id.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpGet("{postId}/author")]
        public async Task<IActionResult> GetByIdIncludeAuthor(int postId)
        {
            var result = await _postService.GetByIdIncludeAuthor(postId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Creates post with given dto.
        /// </summary>
        /// <param name="postForCreateDto"></param>
        /// <returns>Newly created post</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /posts
        ///     {
        ///         "content" : "Naber dostlar",
        ///         "tagId" : 1
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Newly created post</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPost]
        public async Task<IActionResult> Add(PostForCreateDto postForCreateDto)
        {
            var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _postService.Add(postForCreateDto, currentUser.Data);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);

        }

        /// <summary>
        /// The post is updated with the given dto.
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="postForUpdateDto"></param>
        /// <returns>Updated post</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /posts/{postId}
        ///     {
        ///         "content" : "Hoba dostlar",
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Updated post</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPut("{postId}")]
        public async Task<IActionResult> Update(int postId, PostForUpdateDto postForUpdateDto)
        {
            var result = await _postService.Update(postId, postForUpdateDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// The post is liked with the given id.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Liked post</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /posts/{postId}/like
        ///
        /// </remarks>
        /// <response code="200">Liked post</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPut("{postId}/like")]
        public async Task<IActionResult> Like(int postId)
        {
            var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _postService.Like(postId, currentUser.Data);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// The post with the given id is not liked.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Disliked post</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /posts/{postId}/dislike
        ///
        /// </remarks>
        /// <response code="200">Disliked post</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpPut("{postId}/dislike")]
        public async Task<IActionResult> Dislike(int postId)
        {
            var currentUser = await _authService.GetLoggedInUser(HttpContext.User);

            var result = await _postService.Dislike(postId, currentUser.Data);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// The post is deleted with the given id.
        /// </summary>
        /// <param name="postId"></param>
        /// <returns>Success result message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /posts/{postId}
        ///
        /// </remarks>
        /// <response code="200">Success result message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Authorize(Roles = $"{Role.Admin},{Role.Business},{Role.Student}")]
        [HttpDelete("{postId}")]
        public async Task<IActionResult> Delete(int postId)
        {
            var result = await _postService.Delete(postId);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

    }
}