using Core.Utilities.Query;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for Tag 
    /// </summary>
    public interface ITagService
    {
        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        Task<IDataResult<TagDto>> GetById(int tagId);
        
        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        Task<IDataListResult<List<TagDto>>> GetList(PaginationParameters pagination, TagFilter filter);
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        Task<IDataResult<TagDto>> Add(TagForCreateDto tagForCreateDto);
        
        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        Task<IResult> Delete(int tagId);
        
        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        Task<IDataResult<TagDto>> Update(int tagId, TagForUpdateDto tagForUpdateDto);
        
        /// <summary>
        /// All Posts linked to the tag are returned as a list.
        /// </summary>
        Task<IDataListResult<List<PostDto>>> GetByIdIncludePost(int tagId, PaginationParameters pagination);
    }
}