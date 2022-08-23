using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using Client.Models;
using Client.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Client.Services;

public class AuthService : IAuthService
{
    public Task<UserForForgetModel> ConfirmForgotToken(UserForForgetModel UserForForgetModel, string forgotToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserForConfirmModel> ConfirmVerifyToken(UserForConfirmModel userForConfirmModel, string verifyToken)
    {
        throw new NotImplementedException();
    }

    public Task<UserForLoginModel> Login(UserForLoginModel userForLoginModel)
    {
        throw new NotImplementedException();
    }

    public Task<UserForRegisterModel> Register(UserForRegisterModel userForRegisterModel, string password)
    {
        throw new NotImplementedException();
    }
}
