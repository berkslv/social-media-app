using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for Post
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<PostDto>> GetById(int postId);
        
        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<PostDto>>> GetList(PaginationParameters pagination, PostFilter filter);
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<PostDto>> Add(PostForCreateDto postForCreateDto, User user);
        
        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int postId);
        
        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<PostDto>> Update(int postId, PostForUpdateDto postForUpdateDto);
        
        /// <summary>
        /// Comments under the post are returned as a list.
        /// </summary>
        Task<IDataListResult<List<CommentDto>>> GetByIdIncludeComment(int postId, PaginationParameters pagination);
        
        /// <summary>
        /// Those who like the post are returned as a list.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeLikes(int postId, PaginationParameters pagination);
        
        /// <summary>
        /// Those who dislike the post will be returned as a list.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeDislikes(int postId, PaginationParameters pagination);
        
        /// <summary>
        /// The author of the post is retrieved.
        /// </summary>
        Task<IDataResult<UserDto>> GetByIdIncludeAuthor(int postId);
        
        /// <summary>
        /// The auth user likes it.
        /// </summary>
        Task<IDataResult<PostDto>> Like(int postId, User user);
        
        /// <summary>
        /// The auth user dislikes.
        /// </summary>
        Task<IDataResult<PostDto>> Dislike(int postId, User user);

    }
}