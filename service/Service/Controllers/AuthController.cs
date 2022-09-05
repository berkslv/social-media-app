using System.Net.Mail;
using Business.Abstract;
using Core.Entity.Concrete;
using Core.Extensions;
using Core.Utilities.Mail.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/auth")]
    [ApiController]
    [ValidateModel]
    public class AuthController : ControllerExtension
    {
        private IAuthService _authService;
        private IAuthUserService _userService;
        private IMailService _mailService;
        private ILogger<AuthController> _logger;
        public AuthController(IAuthService authService, 
                                IAuthUserService userService, 
                                IMailService mailService,
                                ILogger<AuthController> logger)
        {
            _authService = authService;
            _userService = userService;
            _mailService = mailService;
            _logger = logger;
        }

        /// <summary>
        /// User login with given dto.
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns>Access token and expiration.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /auth/login
        ///
        /// </remarks>
        /// <response code="200">Access token and expiration.</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);

            if (!userToLogin.Success)
            {
                _logger.LogInformation(userToLogin.Message);
                return ReturnFactory(userToLogin.StatusCode, userToLogin);
            }

            var result = await _authService.CreateAccessToken(userToLogin.Data);
                
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Registered User confirms e-mail address.
        /// </summary>
        /// <param name="userForConfirmDto"></param>
        /// <returns>Successful operation message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /auth/verify
        ///
        /// </remarks>
        /// <response code="200">Successful operation message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("verify")]
        public async Task<IActionResult> Confirm(UserForConfirmDto userForConfirmDto)
        {
            var user = await _userService.GetByMail(userForConfirmDto.Email);

            if (!user.Success)
            {
                _logger.LogInformation(user.Message);
                return ReturnFactory(user.StatusCode, user);
            }

            var result = await _authService.ConfirmVerifyToken(user.Data, userForConfirmDto.Code);
            
            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }

        /// <summary>
        /// Makes a request to reset the registered user password. Password reset code will be sent to your e-mail address.
        /// </summary>
        /// <param name="mail"></param>
        /// <returns>Successful operation message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /auth/forgot-password/{mail}
        ///
        /// </remarks>
        /// <response code="200">Successful operation message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("forgot-password/{mail}")]
        public async Task<IActionResult> ForgotPassword(string mail)
        {
            var user = await _userService.GetByMail(mail);

            if (!user.Success)
            {
                _logger.LogInformation(user.Message);
                return ReturnFactory(user.StatusCode, user);
            }

            var forgotToken = await _authService.CreateForgotToken(user.Data);

            if (!forgotToken.Success)
            {
                _logger.LogInformation(forgotToken.Message);
                return ReturnFactory(forgotToken.StatusCode, forgotToken);
            }

            var mailBody = @"Onay kodu: " + forgotToken.Data + " ";

            var result = await _mailService.SendMail(user.Data.Email,
             user.Data.Name,
             "Şifre yenileme",
             mailBody
             );

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// Resets registered and approved user password
        /// </summary>
        /// <param name="UserForForgetDto"></param>
        /// <returns>Successful operation message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /auth/forgot-password/{mail}
        ///
        /// </remarks>
        /// <response code="200">Successful operation message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(UserForForgetDto UserForForgetDto)
        {
            var user = await _userService.GetByMail(UserForForgetDto.Email);

            if (!user.Success)
            {
                _logger.LogInformation(user.Message);
                return ReturnFactory(user.StatusCode, user);
            }

            var result = await _authService.ConfirmForgotToken(UserForForgetDto);

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }


        /// <summary>
        /// It registers the user to the system with the given information.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <returns>Successful operation message</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /auth/register
        ///
        /// </remarks>
        /// <response code="200">Successful operation message</response>
        /// <response code="400">An unexpected error has occurred.</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            var user = await _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            if (!user.Success)
            {
                _logger.LogInformation(user.Message);
                return ReturnFactory(user.StatusCode, user);
            }

            // Mail confirmation token is generated.
            var confirmationToken = await _authService.CreateVerifyToken(user.Data);

            // Error status is checked while generating the token.
            if (!confirmationToken.Success)
            {
                _logger.LogInformation(confirmationToken.Message);
                return ReturnFactory(confirmationToken.StatusCode, confirmationToken);
            }

            var mailBody = @"Onay kodu: " + confirmationToken.Data + " ";

            var result = await _mailService.SendMail(userForRegisterDto.Email,
             userForRegisterDto.Email,
             "Hesap onaylama",
             mailBody
             );

            _logger.LogInformation(result.Message);
            return ReturnFactory(result.StatusCode, result);
        }
    }
}