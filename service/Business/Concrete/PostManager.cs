using System.Linq.Expressions;
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
    /// Post için ana servis implementasyonu
    /// </summary>
    public class PostManager : IPostService
    {
        private IPostDal _postDal;
        private ICommentDal _commentDal;
        private IUserDal _userDal;
        private ITagDal _tagDal;
        private IPostHasTagDal _postHasTagDal;
        private IUserLikePostDal _userLikePostDal;
        private IUserDislikePostDal _userDislikePostDal;
        private IMapper _mapper;

        public PostManager(IPostDal postDal,
                                ICommentDal commentDal,
                                ITagDal tagDal,
                                IPostHasTagDal postHasTagDal,
                                IUserDal userDal,
                                IUserLikePostDal userLikePostDal,
                                IUserDislikePostDal userDislikePostDal,
                                IMapper mapper)
        {
            _postDal = postDal;
            _commentDal = commentDal;
            _tagDal = tagDal;
            _postHasTagDal = postHasTagDal;
            _userDal = userDal;
            _userLikePostDal = userLikePostDal;
            _userDislikePostDal = userDislikePostDal;
            _mapper = mapper;
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<PostDto>> GetById(int postId)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(p => p.Id == postId);

            Console.WriteLine(post.Likes.FindAll(x => x.UserId == 1).Any());
            // The post is checked. 
            if (post is null)
            {
                return new ErrorDataResult<PostDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped.
            var result = _mapper.Map<PostDto>(post);

            // The mapped result is returned.
            return new SuccessDataResult<PostDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<PostDto>>> GetList(PaginationParameters pagination, PostFilter filter)
        {
            // Query is created with the given filter.
            filter.CreateQuery();

            // The List of Post is returned paginated.
            var posts = await _postDal.GetList(pagination, filter);

            // The existence of List of Post is checked.
            if (!posts.Any())
            {
                return new ErrorDataListResult<List<PostDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The number of Posts is taken for pagination.
            var postsCount = await _postDal.Count(filter);

            // The result is mapped.
            var result = _mapper.Map<List<PostDto>>(posts);

            // The mapped result is returned.
            return new SuccessDataListResult<List<PostDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, postsCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<PostDto>> Add(PostForCreateDto postForCreateDto, User user)
        {
            // Tags, the given relational entity, are returned.
            for (int i = 0; i < postForCreateDto.TagId.Count; i++)
            {
                var tag = await _tagDal.Get(x => x.Id == postForCreateDto.TagId[i]);

                // Tag existence is checked.
                if (tag is null)
                {
                    return new ErrorDataResult<PostDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);

                }
            }

            // The post is created.
            var post = new Post()
            {
                Content = postForCreateDto.Content,
                AuthorId = user.Id,
            };

            // The created Post is sent to the database.
            var addedPost = await _postDal.Add(post);

            // The given tags are created one by one as relation.
            for (int i = 0; i < postForCreateDto.TagId.Count; i++)
            {
                var tag = await _tagDal.Get(x => x.Id == postForCreateDto.TagId[i]);

                // An associative m-m entity is created with the returned post and the pulled Tag from VB.
                var postHasTag = new PostHasTag()
                {
                    Post = addedPost,
                    Tag = tag
                };

                // The created entity is sent to the database.
                _ = _postHasTagDal.Add(postHasTag);
            }

            var newPost = await _postDal.Get(x => x.Id == addedPost.Id);

            // Post returned from VB is mapped.
            var result = _mapper.Map<PostDto>(newPost);

            // The mapped result is returned.
            return new SuccessDataResult<PostDto>(result, Messages.Entity.Added, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int postId)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post check is done.
            if (post is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // The post is deleted.
            _ = _postDal.Delete(post);

            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<PostDto>> Update(int postId, PostForUpdateDto postForUpdateDto)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataResult<PostDto>(Messages.Entity.NotUpdated, HttpStatusCode.BadRequest);
            }

            // All related entities under tags with m-m fields are deleted.
            for (int i = 0; i < post.Tags.Count; i++)
            {
                var postHasTag = await _postHasTagDal.Get(x => x.TagId == post.Tags[i].TagId && x.PostId == postId);

                await _postHasTagDal.Delete(postHasTag);
            }

            // Required fields are updated.
            post.Content = postForUpdateDto.Content;

            // The given tags are recreated one by one, relationally.
            for (int i = 0; i < postForUpdateDto.TagId.Count; i++)
            {
                var tag = await _tagDal.Get(x => x.Id == postForUpdateDto.TagId[i]);

                // An associative m-m entity is created with the returned post and the pulled Tag from VB.
                var postHasTag = new PostHasTag()
                {
                    Post = post,
                    Tag = tag
                };

                // The created entity is sent to the database.
                _ = _postHasTagDal.Add(postHasTag);
            }

            // The updated Post is sent to the database.
            await _postDal.Update(post);

            var gettedPost = await _postDal.Get(x => x.Id == postId);

            // Güncellenip Post returned from VB is mapped.
            var result = _mapper.Map<PostDto>(gettedPost);

            // The mapped result is returned.
            return new SuccessDataResult<PostDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// Comments under the post are returned as a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<CommentDto>>> GetByIdIncludeComment(int postId, PaginationParameters pagination)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataListResult<List<CommentDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // List of Comment under Post is returned with the given Post id.
            var comment = await _commentDal.GetList(pagination, x => x.PostId == postId);

            // Comment existence is checked.
            if (!comment.Any())
            {
                return new ErrorDataListResult<List<CommentDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The number of comments is taken for pagination.
            var commentCount = await _commentDal.Count(x => x.PostId == postId);

            // Comment mapped.
            var result = _mapper.Map<List<CommentDto>>(comment);

            // The mapped result is returned.
            return new SuccessDataListResult<List<CommentDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, commentCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// Those who like the post are returned as a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeLikes(int postId, PaginationParameters pagination)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Likers (List of User) under Post are returned with the given Post id.
            var users = await _postDal.GetLikers(postId, pagination);

            // Likers control is done.
            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Number of Likers is taken for pagination.
            var usersCount = await _postDal.GetLikersCount(postId);

            // Likers are mapped.
            var result = _mapper.Map<List<UserDto>>(users);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// Those who dislike the post will be returned as a list.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetByIdIncludeDislikes(int postId, PaginationParameters pagination)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Dislikers (List of User) under Post is returned with the given Post id.
            var users = await _postDal.GetDislikers(postId, pagination);

            // Dislikers are checked.
            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Number of Dislikers is taken for paging.
            var usersCount = await _postDal.GetDislikersCount(postId);

            // Dislikers are mapped.
            var result = _mapper.Map<List<UserDto>>(users);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The author of the post is retrieved.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<UserDto>> GetByIdIncludeAuthor(int postId)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The Author under Post is returned from the User table with the given postId.
            var author = await _userDal.Get(x => x.Id == post.AuthorId);

            // The Author entity is checked.
            if (author is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // Author is mapped.
            var result = _mapper.Map<UserDto>(author);

            // The mapped result is returned.
            return new SuccessDataResult<UserDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// Auth olmuş kullanıcı like eder beğenir.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<PostDto>> Like(int postId, User user)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataResult<PostDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // If the same user disliked the same post, it will be returned.
            // In case you like the post you disliked
            var userDislikePost = await _userDislikePostDal.Get(x => x.Post == post && x.User == user);

            // The dislikes are deleted.
            if (userDislikePost is not null)
            {
                await _userDislikePostDal.Delete(userDislikePost);
            }

            // This is returned if the same user liked the same post.
            // In case of like the same post twice
            var gettedUserLikePost = await _userLikePostDal.Get(x => x.User == user && x.Post == post);

            // A like ensures that no action is taken.
            if (gettedUserLikePost is not null)
            {
                return new ErrorDataResult<PostDto>(Messages.Entity.Found, HttpStatusCode.OK);
            }

            // Like is created.
            var userLikePost = new UserLikePost()
            {
                User = user,
                Post = post
            };

            // The created like is sent to the database.
            await _userLikePostDal.Add(userLikePost);

            // The liked post is returned.
            var likedPost = await _postDal.Get(x => x.Id == postId);

            // Post returned from VB is mapped.
            var result = _mapper.Map<PostDto>(likedPost);

            // The operation is reported as successful.
            return new SuccessDataResult<PostDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// Auth olmuş kullanıcı dislike eder beğenir.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IDataResult<PostDto>> Dislike(int postId, User user)
        {
            // Post is returned with the given id.
            var post = await _postDal.Get(x => x.Id == postId);

            // Post existence is checked.
            if (post is null)
            {
                return new ErrorDataResult<PostDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // This is returned if the same user liked the same post.
            // In case you dislike the post you like.
            var userLikePost = await _userLikePostDal.Get(x => x.Post == post && x.User == user);

            // The like is deleted.
            if (userLikePost is not null)
            {
                await _userLikePostDal.Delete(userLikePost);
            }

            // If the same user disliked the same post, it will be returned.
            // In case of disliking the same post twice.
            var gettedUserDislikePost = await _userDislikePostDal.Get(x => x.User == user && x.Post == post);

            // The disliked ensures that no action is taken.
            if (gettedUserDislikePost is not null)
            {
                return new ErrorDataResult<PostDto>(Messages.Entity.Found, HttpStatusCode.OK);
            }

            // Dislike is created.
            var userDislikePost = new UserDislikePost()
            {
                User = user,
                Post = post
            };

            // The created Dislike is sent to the database.
            await _userDislikePostDal.Add(userDislikePost);

            // The unliked post is returned.
            var likedPost = await _postDal.Get(x => x.Id == postId);

            // Post returned from VB is mapped.
            var result = _mapper.Map<PostDto>(likedPost);

            // The operation is reported as successful.
            return new SuccessDataResult<PostDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }
    }
}