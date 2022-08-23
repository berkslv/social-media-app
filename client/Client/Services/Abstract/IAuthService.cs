using System.Diagnostics;
using System.Net.Http.Headers;
using Client.Models;
using Client.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Services;

public interface IAuthService
{
        Task<UserForRegisterModel> Register(UserForRegisterModel userForRegisterModel,string password);
        
        Task<UserForLoginModel> Login(UserForLoginModel userForLoginModel);
        
        Task<UserForConfirmModel> ConfirmVerifyToken(UserForConfirmModel userForConfirmModel, string verifyToken);
        
        Task<UserForForgetModel> ConfirmForgotToken(UserForForgetModel UserForForgetModel, string forgotToken);
}
