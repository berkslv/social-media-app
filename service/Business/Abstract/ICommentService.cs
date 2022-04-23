using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for comment
    /// </summary>
    public interface ICommentService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<CommentDto>> GetById(int commentId);
        
        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<CommentDto>>> GetList(PaginationParameters pagination, CommentFilter filter);
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<CommentDto>> Add(CommentForCreateDto commentForCreateDto, User user);
        
        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int commentId);
        
        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<CommentDto>> Update(int commentId, CommentForUpdateDto commentForUpdateDto);
        
        /// <summary>
        /// Those who like the post are returned as a list.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeLikes(int commentId, PaginationParameters pagination);
        
        /// <summary>
        /// Those who dislike the post will be returned as a list.
        /// </summary>
        Task<IDataListResult<List<UserDto>>> GetByIdIncludeDislikes(int commentId, PaginationParameters pagination);
        
        /// <summary>
        /// The author of the post is retrieved.
        /// </summary>
        Task<IDataResult<UserDto>> GetByIdIncludeAuthor(int commentId);
        
        /// <summary>
        /// The auth user likes it.
        /// </summary>
        Task<IResult> Like(int commentId, User user);
        
        /// <summary>
        /// The auth user dislikes.
        /// </summary>
        Task<IResult> Dislike(int commentId, User user);
    }
}