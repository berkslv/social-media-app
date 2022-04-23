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
    public class CommentManager : ICommentService
    {
        private IPostDal _postDal;
        private ICommentDal _commentDal;
        private IUserDal _userDal;
        private ITagDal _tagDal;
        private IUserLikeCommentDal _userLikeCommentDal;
        private IUserDislikeCommentDal _userDislikeCommentDal;
        private IMapper _mapper;

        public CommentManager(IPostDal postDal,
                                ICommentDal commentDal,
                                ITagDal tagDal,
                                IUserDal userDal,
                                IUserLikeCommentDal userLikeCommentDal,
                                IUserDislikeCommentDal userDislikeCommentDal,
                                IMapper mapper)
        {
            _postDal = postDal;
            _commentDal = commentDal;
            _tagDal = tagDal;
            _userDal = userDal;
            _userLikeCommentDal = userLikeCommentDal;
            _userDislikeCommentDal = userDislikeCommentDal;
            _mapper = mapper;
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<CommentDto>> GetById(int commentId)
        {
            // Post is returned with the given id.
            var comment = await _commentDal.Get(p => p.Id == commentId);

            // The post is checked. 
            if (comment is null)
            {
                return new ErrorDataResult<CommentDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<CommentDto>(comment);

            // The mapped result is returned.
            return new SuccessDataResult<CommentDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<CommentDto>>> GetList(PaginationParameters pagination, CommentFilter filter)
        {
            filter.CreateQuery();

            // The List of Post is returned paginated.
            var comments = await _commentDal.GetList(pagination, filter);

            // The existence of List of Post is checked.
            if (!comments.Any())
            {
                return new ErrorDataListResult<List<CommentDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The number of Posts is taken for pagination.
            var commentsCount = await _commentDal.Count(filter);

            // The result is mapped.
            var result = _mapper.Map<List<CommentDto>>(comments);

            // The mapped result is returned.
            return new SuccessDataListResult<List<CommentDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, commentsCount, pagination.PageNumber, pagination.PageSize);
        }


        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        public async Task<IDataResult<CommentDto>> Add(CommentForCreateDto commentForCreateDto, User user)
        {
            // The post is created.
            var comment = new Comment()
            {
                Content = commentForCreateDto.Content,
                PostId = commentForCreateDto.PostId,
                AuthorId = user.Id
            };

            // The created Post is sent to the database.
            var addedComment = await _commentDal.Add(comment);

            // Post returned from VB is mapped.
            var result = _mapper.Map<CommentDto>(addedComment);

            // The mapped result is returned.
            return new SuccessDataResult<CommentDto>(result, Messages.Entity.Added, HttpStatusCode.Created);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int commentId)
        {
            // Post is returned with the given id.
            var comment = await _commentDal.Get(x => x.Id == commentId);

            // Post check is done.
            if (comment is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // The post is deleted.
            _ = _commentDal.Delete(comment);

            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<CommentDto>> Update(int commentId, CommentForUpdateDto commentForUpdateDto)
        {
            // Post is returned with the given id.
            var comment = await _commentDal.Get(x => x.Id == commentId);

            // Post existence is checked.
            if (comment is null)
            {
                return new ErrorDataResult<CommentDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Required fields are updated.
            var mappedComment = _mapper.Map<CommentForUpdateDto, Comment>(commentForUpdateDto, comment);

            // The updated Post is sent to the database.
            await _commentDal.Delete(comment);
            var updatedComment = await _commentDal.Add(mappedComment);

            // Güncellenip Post returned from VB is mapped.
            var result = _mapper.Map<CommentDto>(updatedComment);

            // The mapped result is returned.
            return new SuccessDataResult<CommentDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }


        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeLikes(int commentId, PaginationParameters pagination)
        {
            // get comment
            var comment = await _commentDal.Get(x => x.Id == commentId);

            if (comment is null)
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var users = await _commentDal.GetLikers(commentId, pagination);

            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var usersCount = await _commentDal.GetLikersCount(commentId);

            var result = _mapper.Map<List<UserDto>>(users);

            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeDislikes(int commentId, PaginationParameters pagination)
        {
            var comment = await _commentDal.Get(x => x.Id == commentId);

            if (comment is null)
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var users = await _commentDal.GetDislikers(commentId, pagination);

            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var usersCount = await _commentDal.GetDislikersCount(commentId);

            var result = _mapper.Map<List<UserDto>>(users);

            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<UserDto>> GetByIdIncludeAuthor(int commentId)
        {
            var comment = await _commentDal.Get(x => x.Id == commentId);

            if (comment is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var author = await _userDal.Get(x => x.Id == comment.AuthorId);

            if (author is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var result = _mapper.Map<UserDto>(author);

            return new SuccessDataResult<UserDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Like(int commentId, User user)
        {
            var comment = await _commentDal.Get(x => x.Id == commentId);

            if (comment is null)
            {
                return new ErrorDataResult<CommentDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // If the same await disliked the post, it will be deleted.
            var userDislikeComment = await _userDislikeCommentDal.Get(x => x.Comment == comment && x.User == user);

            if (userDislikeComment is not null)
            {
                await _userDislikeCommentDal.Delete(userDislikeComment);
            }

            // If it has thrown like await before, it cannot throw it again.
            var gettedUserLikeComment = await _userLikeCommentDal.Get(x => x.User == user && x.Comment == comment);

            if (gettedUserLikeComment is not null)
            {
                return new ErrorDataResult<CommentDto>(Messages.Entity.Found, HttpStatusCode.OK);
            }

            var userLikeComment = new UserLikeComment()
            {
                User = user,
                Comment = comment
            };

            await _userLikeCommentDal.Add(userLikeComment);

            var likedComment = await _commentDal.Get(x => x.Id == commentId);

            var result = _mapper.Map<CommentDto>(likedComment);

            return new SuccessDataResult<CommentDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Dislike(int commentId, User user)
        {
            var comment = await _commentDal.Get(x => x.Id == commentId);

            if (comment is null)
            {
                return new ErrorDataResult<CommentDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // If the same await liked the post, it will be deleted.
            var userLikeComment = await _userLikeCommentDal.Get(x => x.Comment == comment && x.User == user);

            if (userLikeComment is not null)
            {
                await _userLikeCommentDal.Delete(userLikeComment);
            }

            // Eğer daha önce dislike await attıysa tekrar atamaz.
            var gettedUserDislikeComment = await _userDislikeCommentDal.Get(x => x.User == user && x.Comment == comment);

            if (gettedUserDislikeComment is not null)
            {
                return new ErrorDataResult<CommentDto>(Messages.Entity.Found, HttpStatusCode.OK);
            }

            var userDislikeComment = new UserDislikeComment()
            {
                User = user,
                Comment = comment
            };

            await _userDislikeCommentDal.Add(userDislikeComment);

            var dislikedComment = await _commentDal.Get(x => x.Id == commentId);

            var result = _mapper.Map<CommentDto>(dislikedComment);

            return new SuccessDataResult<CommentDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }
    }
}