using System.Security.Claims;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entity.Concrete;
using Entity.Dtos;

namespace Business.Abstract
{
    /// <summary>
    /// Main service for Auth 
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// It first puts the user into DB validation with the given Dto and Password information. Then password hashes, creates a user, Claims with the role in the dto and adds it to the m-m UserClaim table.
        /// </summary>
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto,string password);
        
        /// <summary>
        /// DB dependent validation processes are done when starting the registration process.
        /// </summary>
        Task<IResult> RegisterValidation(UserForRegisterDto userForRegisterDto);
        
        /// <summary>
        /// Authenticates user with given dto.
        /// </summary>
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        
        /// <summary>
        /// Generates Access Token with the given user.
        /// </summary>
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
        
        /// <summary>
        /// Generates Verify Token with the given user.
        /// </summary>
        Task<IDataResult<string>> CreateVerifyToken(User user);
        
        /// <summary>
        /// The previously generated Verify Token is verified with the user.
        /// </summary>
        Task<IResult> ConfirmVerifyToken(User user, string verifyToken);
        
        /// <summary>
        /// The user in the context is returned.
        /// </summary>
        Task<IDataResult<User>> GetLoggedInUser(ClaimsPrincipal user);
        
        /// <summary>
        /// Generates Forgot Token with the given user.
        /// </summary>
        Task<IDataResult<string>> CreateForgotToken(User user);
        
        /// <summary>
        /// The user is updated with the previously generated verification code.
        /// </summary>
        Task<IResult> ConfirmForgotToken(UserForForgetDto UserForForgetDto);
    }
}