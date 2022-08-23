using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using Client.Models;
using Client.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Services;

public class PostService : IPostService
{
    public Task<PostModel> GetById(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<PostModel> GetList()
    {
        throw new NotImplementedException();
    }

    public Task<PostModel> Add(PostForCreateModel postForCreateModel)
    {
        throw new NotImplementedException();
    }

    public Task<IResult> Delete(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<PostModel> Update(int postId, PostForUpdateModel postForUpdateModel)
    {
        throw new NotImplementedException();
    }

    public Task<CommentModel> GetByIdIncludeComment(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<PostModel> Like(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<PostModel> Dislike(int postId)
    {
        throw new NotImplementedException();
    }
}
