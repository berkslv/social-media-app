using System.Diagnostics;
using System.Net.Http.Headers;
using Client.Models;
using Client.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Services;

public interface IPostService
{
        Task<PostModel> GetById(int postId);
        
        Task<PostModel> GetList();
        
        Task<PostModel> Add(PostForCreateModel postForCreateModel);
        
        Task<IResult> Delete(int postId);
        
        Task<PostModel> Update(int postId, PostForUpdateModel postForUpdateModel);
        
        Task<CommentModel> GetByIdIncludeComment(int postId);
        
        Task<PostModel> Like(int postId);
        
        Task<PostModel> Dislike(int postId);
}
