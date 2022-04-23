using System.Net;
using AutoMapper;
using Business.Abstract;
using Core.Constants;
using Core.Utilities.Query;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Concrete
{
    /// <summary>
    /// Tag için ana servis implementasyonu
    /// </summary>
    public class TagManager : ITagService
    {
        private ITagDal _tagDal;
        private IPostDal _postDal;
        private IPostHasTagDal _postHasTagDal;
        private IMapper _mapper;

        public TagManager(ITagDal tagDal,
                                IPostDal postDal,
                                IPostHasTagDal postHasTagDal,
                                IMapper mapper)
        {
            _tagDal = tagDal;
            _postDal = postDal;
            _postHasTagDal = postHasTagDal;
            _mapper = mapper;
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<TagDto>> GetById(int tagId)
        {
            // Tag is returned with the given id.
            var tag = await _tagDal.Get(p => p.Id == tagId);

            // If Tag is not found
            if (tag is null)
            {
                return new ErrorDataResult<TagDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<TagDto>(tag);

            // The mapped result is returned.
            return new SuccessDataResult<TagDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<TagDto>>> GetList(PaginationParameters pagination, TagFilter filter)
        {
            // Expression is created with the given filter.
            filter.CreateQuery();

            // List of Tag is returned paginated.
            var tags = await _tagDal.GetList(pagination, filter);

            // If Tag is not found
            if (!tags.Any())
            {
                return new ErrorDataListResult<List<TagDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The number of tags is taken for pagination.
            var tagsCount = await _tagDal.Count(filter);

            // The result is mapped.
            var result = _mapper.Map<List<TagDto>>(tags);

            // The mapped result is returned.
            return new SuccessDataListResult<List<TagDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, tagsCount, pagination.PageNumber, pagination.PageSize);
        }
        
        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        public async Task<IDataResult<TagDto>> Add(TagForCreateDto tagForCreateDto)
        {
            // The tag is created.
            var tag = new Tag
            {
                Name = tagForCreateDto.Name,
                Description = tagForCreateDto.Description
            };

            // The created tag is added to the database.
            var addedTag = await _tagDal.Add(tag);

            // Added Tag returning from database is mapped.
            var result = _mapper.Map<TagDto>(addedTag);

            // The mapped result is returned.
            return new SuccessDataResult<TagDto>(result, Messages.Entity.Added, HttpStatusCode.OK);
        }


        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int tagId)
        {
            // Tag is returned with the given id.
            var tag = await _tagDal.Get(x => x.Id == tagId);

            // Tag existence is checked.
            if (tag is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The tag is deleted.
            _ = _tagDal.Delete(tag);

            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<TagDto>> Update(int tagId, TagForUpdateDto tagForUpdateDto)
        {
            // Tag is returned with the given id.
            var tag = await _tagDal.Get(x => x.Id == tagId);

            // Tag existence is checked.
            if (tag is null)
            {
                return new ErrorDataResult<TagDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Required fields are updated.
            var mappedTag = _mapper.Map<TagForUpdateDto, Tag>(tagForUpdateDto, tag);

            // The updated Tag is sent to the database.
            var updatedTag = await _tagDal.Update(mappedTag);

            // Updated Tag returned from database is mapped.
            var result = _mapper.Map<TagDto>(updatedTag);

            // The mapped result is returned.
            return new SuccessDataResult<TagDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// All Posts linked to the tag are returned as a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<PostDto>>> GetByIdIncludePost(int tagId, PaginationParameters pagination)
        {
            // It is returned from the relational table with the given id.
            var postHasTag = await _postHasTagDal.Get(x => x.TagId == tagId);
            
            // The relational object existence is checked.
            if (postHasTag is null)
            {
                return new ErrorDataListResult<List<PostDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }
            
            // A List of Post with the corresponding relationship is returned
            var posts = await _postDal.GetList(pagination, x => x.Tags.Contains(postHasTag));

            // The existence of List of Post is checked.
            if (!posts.Any())
            {
                return new ErrorDataListResult<List<PostDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Pieces are taken for pagination.
            var postsCount = await _postDal.Count(x => x.Tags.Contains(postHasTag));

            // The result is mapped.
            var result = _mapper.Map<List<PostDto>>(posts);

            // The mapped result is returned.
            return new SuccessDataListResult<List<PostDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, postsCount, pagination.PageNumber, pagination.PageSize); 
        }
    }
}