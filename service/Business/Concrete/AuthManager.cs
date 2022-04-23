using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Business.Abstract;
using Core.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IAuthUserService _authUserService;
        private IUserCodeDal _userCodeDal;
        private IClaimDal _claimDal;
        private IUniversityService _universityService;
        private IFacultyService _facultyService;
        private IDepartmentService _departmentService;

        private ITokenHelper _tokenHelper;

        public AuthManager(IAuthUserService authUserService,
                            ITokenHelper tokenHelper,
                            IUniversityService universityService,
                            IFacultyService facultyService,
                            IDepartmentService departmentService,
                            IUserCodeDal userCodeDal,
                            IClaimDal claimDal
        )
        {
            _authUserService = authUserService;
            _tokenHelper = tokenHelper;
            _universityService = universityService;
            _facultyService = facultyService;
            _departmentService = departmentService;
            _userCodeDal = userCodeDal;
            _claimDal = claimDal;
        }

        /// <summary>
        /// It first puts the user into DB validation with the given Dto and Password information. Then password hashes, creates a user, Claims with the role in the dto and adds it to the m-m UserClaim table.
        /// </summary>
        public async Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            // Validation is done before registration.
            var validate = await this.RegisterValidation(userForRegisterDto);

            if (!validate.Success)
            {
                return new ErrorDataResult<User>(validate.Message, HttpStatusCode.BadRequest);
            }

            // It is created by hashing the password.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            // The user is created.
            var _user = new User
            {
                Email = userForRegisterDto.Email,
                Role = userForRegisterDto.Role,
                Name = userForRegisterDto.Name,
                Username = userForRegisterDto.Username,
                UniversityId = userForRegisterDto.UniversityId,
                FacultyId = userForRegisterDto.FacultyId,
                DepartmentId = userForRegisterDto.DepartmentId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = false
            };

            // The user is added to the database.
            var user = await _authUserService.Add(_user);

            // Claim is returned with the given user role. If there is no Claim, an error
            var claim = await _claimDal.GetClaim(x => x.Name == userForRegisterDto.Role);

            // If there is no claim, an error is returned.
            if (claim is null)
            {
                return new ErrorDataResult<User>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // User Claim and m-m are combined in the table.
            await _claimDal.Add(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = claim.Id
            });

            return new SuccessDataResult<User>(user, Messages.Auth.UserRegistered, HttpStatusCode.OK);
        }

        /// <summary>
        /// Authenticates user with given dto.
        /// </summary>
        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            // The user is returned with the given e-mail.
            var user = (await _authUserService.GetByMail(userForLoginDto.Email)).Data;

            // The presence of the user is checked.
            if (user is null)
            {
                return new ErrorDataResult<User>(Messages.Auth.UserNotFound, HttpStatusCode.BadRequest);
            }

            // The verification status of the account is checked.
            if (!user.Status)
            {
                return new ErrorDataResult<User>("Giriş yapmadan önce hesabını doğrula", HttpStatusCode.BadRequest);
            }

            // The password is confirmed.
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.Auth.PasswordError, HttpStatusCode.BadRequest);
            }

            return new SuccessDataResult<User>(user, Messages.Auth.SuccessfulLogin, HttpStatusCode.OK);
        }

        /// <summary>
        /// Generates Access Token with the given user.
        /// </summary>
        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            // Claim information of the user is returned.
            var claims = await _authUserService.GetClaims(user);

            // Access tokens are generated with Claim and User.
            var accessToken = _tokenHelper.CreateToken(user, claims);

            // The role is added to the data.
            accessToken.Role = user.Role;

            // Access token is returned.
            return new SuccessDataResult<AccessToken>(accessToken, Messages.Auth.AccessTokenCreated, HttpStatusCode.OK);
        }

        /// <summary>
        /// Generates Verify Token with the given user.
        /// </summary>
        public async Task<IDataResult<string>> CreateVerifyToken(User user)
        {
            // The nanoId is generated.
            var nanoId = Nanoid.Nanoid.Generate("1234567890", 6);

            // The User Code is created.
            var userCode = new UserCode
            {
                Code = nanoId,
                UserId = user.Id
            };

            // User Code is saved.
            await _userCodeDal.Add(userCode);

            return new SuccessDataResult<string>(data: nanoId, HttpStatusCode.OK);
        }

        /// <summary>
        /// The previously generated Verify Token is verified with the user.
        /// </summary>
        public async Task<IResult> ConfirmVerifyToken(User user, string verifyToken)
        {
            // The UserCode containing User and Code at the same time is returned.
            var result = await _userCodeDal.Get(x => x.UserId == user.Id && x.Code == verifyToken);

            // The UserCode entity is queried.
            if (result is null)
            {
                return new ErrorResult("Doğrulama kodu yanlış", HttpStatusCode.BadRequest);
            }
            
            // The Status field of the user is checked. If true, it exits the function.
            if (user.Status)
            {
                return new ErrorResult("Hesap zaten doğrulanmış", HttpStatusCode.BadRequest);
            }

            // The Status field of the user who has not yet been authenticated is set to true.
            user.Status = true;

            // The user is updated.
            var updatedUser = await _authUserService.Update(user);

            // Update success is checked.
            if (!updatedUser.Success)
            {
                return new ErrorResult("Doğrulama sırasında bir hata oluştu, Daha sonra tekrar deneyiniz.", HttpStatusCode.BadRequest);
            }

            return new SuccessResult("Hesabın başarıyla doğrulandı", HttpStatusCode.OK);
        }

        /// <summary>
        /// The user in the context is returned.
        /// </summary>
        public async Task<IDataResult<User>> GetLoggedInUser(ClaimsPrincipal user)
        {
            var _id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (_id is null)
            {
                return new ErrorDataResult<User>("Bir hata oluştu.", HttpStatusCode.BadRequest);
            }

            int id = Int32.Parse(_id);
            var result = await _authUserService.GetById(id);

            if (!result.Success)
            {
                return new ErrorDataResult<User>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            return new SuccessDataResult<User>(result.Data, HttpStatusCode.OK);
        }

        /// <summary>
        /// Generates Verify Token with the given user.
        /// </summary>
        public async Task<IDataResult<string>> CreateForgotToken(User user)
        {
            // The nanoId is generated.
            var nanoId = Nanoid.Nanoid.Generate("1234567890", 6);

            // The User Code is created.
            var userCode = new UserCode
            {
                Code = nanoId,
                UserId = user.Id
            };

            // User Code is saved.
            await _userCodeDal.Add(userCode);

            return new SuccessDataResult<string>(data: nanoId, HttpStatusCode.OK);
        }

        /// <summary>
        /// The user is updated with the previously generated verification code.
        /// </summary>
        public async Task<IResult> ConfirmForgotToken(UserForForgetDto UserForForgetDto)
        {
            // The user is returned with the mail given with the dto.
            var user = await _authUserService.GetByMail(UserForForgetDto.Email);

            // User presence is checked.
            if (!user.Success)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // UserCode is returned by using Code and User together.
            var result = await _userCodeDal.Get(x => x.UserId == user.Data.Id && x.Code == UserForForgetDto.Code);

            // Check if there is a matching entity.
            if (result is null)
            {
                return new ErrorResult("Doğrulama kodu yanlış", HttpStatusCode.BadRequest);
            }

            // The new password is hashed.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(UserForForgetDto.Password, out passwordHash, out passwordSalt);

            // The password is updated.
            user.Data.PasswordHash = passwordHash;
            user.Data.PasswordSalt = passwordSalt;

            // The user is updated.
            await _authUserService.Update(user.Data);
            
            return new SuccessResult("Şifren başarıyla güncellendi.", HttpStatusCode.OK);
        }

        /// <summary>
        /// DB dependent validation processes are done when starting the registration process.
        /// </summary>
        public async Task<IResult> RegisterValidation(UserForRegisterDto userForRegisterDto)
        {
            // It is returned from the database using the user's mail and username.
            var byMail = await _authUserService.GetByMail(userForRegisterDto.Email);
            var byUsername = await _authUserService.GetByUsername(userForRegisterDto.Username);

            // User presence is checked.
            if (byMail.Success || byUsername.Success)
            {
                return new ErrorResult(Messages.Auth.UserAlreadyExists, HttpStatusCode.BadRequest);
            }

            // Student user validation is done
            if (userForRegisterDto.Role == Role.Student)
            {
                // The e-mail address is created.
                var mailAddress = new MailAddress(userForRegisterDto.Email);

                // It is checked that the e-mail address contains the .edu extension.
                if (!mailAddress.Host.Contains(".edu"))
                {
                    return new ErrorResult("Üniversite mail adresin yoksa seni kabul edemeyiz.", HttpStatusCode.BadRequest);
                }

                // Relational field will be returned from University, Faculty and Department VB.
                var university = await _universityService.GetById((int)userForRegisterDto.UniversityId);
                var faculty = await _facultyService.GetById((int)userForRegisterDto.FacultyId);
                var department = await _departmentService.GetById((int)userForRegisterDto.DepartmentId);

                // It is checked whether there are assets with the given information.
                if (!university.Success || !faculty.Success || !department.Success)
                {
                    return new ErrorResult("Lütfen girilen eğitim bilgilerini kontrol ediniz.", HttpStatusCode.BadRequest);
                }

                // The faculty of the given university is checked.
                var facultyControl = _facultyService.GetByUniversityId((int)userForRegisterDto.UniversityId);

                if (facultyControl is null)
                {
                    return new ErrorResult("Bu üniversitenin böyle bir fakültesi bulunmuyor.", HttpStatusCode.BadRequest);
                }

                // The department of the given faculty is checked.
                var departmentControl = _departmentService.GetByFacultyId((int)userForRegisterDto.FacultyId);

                if (departmentControl is null)
                {
                    return new ErrorResult("Bu üniversitenin böyle bir bölümü bulunmuyor.", HttpStatusCode.BadRequest);
                }
            }

            return new SuccessResult(HttpStatusCode.OK);
        }

    }
}