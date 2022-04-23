using System.Net;
using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using Core.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Query;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;
using Entity.Filter;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IMapper _mapper;
        private IUserDal _userDal;
        private IClaimDal _claimDal;

        public UserManager(IUserDal userDal, IMapper mapper, IClaimDal claimDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _claimDal = claimDal;
        }

        public async Task<IDataResult<UserDto>> GetMe(ClaimsPrincipal user)
        {
            var _id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (_id is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            int id = Int32.Parse(_id);

            var gettedUser = await _userDal.Get(x => x.Id == id);

            if (gettedUser is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            var result = _mapper.Map<User, UserDto>(gettedUser);

            return new SuccessDataResult<UserDto>(result, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataResult<UserDto>> GetById(int userId)
        {
            // User is returned with the given id.
            var user = await _userDal.Get(x => x.Id == userId);

            // If User is not found
            if (user is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // The result is mapped
            var result = _mapper.Map<UserDto>(user);

            // The mapped result is returned.
            return new SuccessDataResult<UserDto>(result, Messages.Entity.Found, HttpStatusCode.OK);
        }

        /// <summary>
        /// All entities are returned in a paginated manner according to the query parameter.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="204"></response>
        public async Task<IDataListResult<List<UserDto>>> GetList(PaginationParameters pagination, UserFilter filter)
        {
            // Expression is created with the given filter.
            filter.CreateQuery();

            // List of User is returned paginated.
            var users = await _userDal.GetList(pagination, filter);

            // If no User is found.
            if (!users.Any())
            {
                return new ErrorDataListResult<List<UserDto>>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            // All Users are taken for paging.
            var usersCount = await _userDal.Count(filter);

            // The found User is mapped.
            var result = _mapper.Map<List<UserDto>>(users);

            // The mapped result is returned.
            return new SuccessDataListResult<List<UserDto>>(result, Messages.Entity.Found, HttpStatusCode.OK, usersCount, pagination.PageNumber, pagination.PageSize);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        /// <response code="201"></response>
        public async Task<IDataResult<UserDto>> Add(UserForCreateDto userForCreateDto)
        {
            var controlUser = await _userDal.Get(x => x.Email == userForCreateDto.Email || x.Username == userForCreateDto.Username);

            if (controlUser is not null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotAdded, HttpStatusCode.BadRequest);
            }

            // It is created by hashing the password.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForCreateDto.Password, out passwordHash, out passwordSalt);

            // User is created with the given dto.
            var user = new User
            {
                Email = userForCreateDto.Email,
                Name = userForCreateDto.Name,
                Username = userForCreateDto.Username,
                UniversityId = userForCreateDto.UniversityId,
                FacultyId = userForCreateDto.FacultyId,
                Role = userForCreateDto.Role,
                DepartmentId = userForCreateDto.DepartmentId,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };

            // The created User is added to the database, and the User added to the database is returned.
            var addedUser = await _userDal.Add(user);

            // Claim is returned with the given user role
            var claim = await _claimDal.GetClaim(x => x.Name == addedUser.Role);

            // If there is no claim, an error is returned.
            if (claim is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // User Claim and m-m are combined in the table.
            await _claimDal.Add(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = claim.Id
            });

            // The returning User is mapped.
            var result = _mapper.Map<UserDto>(addedUser);

            // The mapped result is returned.
            return new SuccessDataResult<UserDto>(result, Messages.Entity.Added, HttpStatusCode.Created);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        /// <response code="200"></response>
        /// <response code="400"></response>
        public async Task<IResult> Delete(int userId)
        {
            // User is returned with the given id.
            var user = await _userDal.Get(x => x.Id == userId);

            // Check if there is a user.
            if (user is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Claim is returned with the role of the old user to be deleted.
            var claimToDelete = await _claimDal.GetClaim(x => x.Name == user.Role);

            // If there is no claim, an error is returned.
            if (claimToDelete is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // The join data of the old user's role is returned.
            var userClaimToDelete = await _claimDal.Get(x => x.UserId == user.Id && x.OperationClaimId == claimToDelete.Id);

            // If there is no claim, an error is returned.
            if (userClaimToDelete is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }   

            // Join data is deleted.
            await _claimDal.Delete(userClaimToDelete);

            // The user is deleted.
            await _userDal.Delete(user);

            // Successful result is returned.
            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        /// <response code="400"></response>
        /// <response code="200"></response>
        public async Task<IDataResult<UserDto>> Update(int userId, UserForUpdateDto userForUpdateDto)
        {
            // User is returned with the given id.
            var user = await _userDal.Get(x => x.Id == userId);

            // Check if there is a user.
            if (user is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // Claim is returned with the role of the old user to be deleted.
            var claimToDelete = await _claimDal.GetClaim(x => x.Name == user.Role);

            // If there is no claim, an error is returned.
            if (claimToDelete is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // The join data of the old user's role is returned.
            var userClaimToDelete = await _claimDal.Get(x => x.UserId == user.Id && x.OperationClaimId == claimToDelete.Id);

            // If there is no claim, an error is returned.
            if (userClaimToDelete is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }   

            // Join data is deleted.
            await _claimDal.Delete(userClaimToDelete);


            // It is created by hashing the password.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForUpdateDto.Password, out passwordHash, out passwordSalt);

            // Required fields are updated.
            var mappedUser = _mapper.Map<UserForUpdateDto, User>(userForUpdateDto, user);

            mappedUser.PasswordHash = passwordHash;
            mappedUser.PasswordSalt = passwordSalt;

            // The user is updated.
            var updatedUser = await _userDal.Update(mappedUser);

            // The new claim is returned.
            var claim = await _claimDal.GetClaim(x => x.Name == mappedUser.Role);

            // If the claim is not found
            if (claim is null)
            {
                return new ErrorDataResult<UserDto>(Messages.Entity.NotFound, HttpStatusCode.BadRequest);
            }

            // User Claim and m-m are combined in the table.
            await _claimDal.Add(new UserOperationClaim
            {
                UserId = user.Id,
                OperationClaimId = claim.Id
            });

            // The returning User is mapped.
            var result = _mapper.Map<UserDto>(updatedUser);

            // The mapped entity is returned.
            return new SuccessDataResult<UserDto>(result, Messages.Entity.Updated, HttpStatusCode.OK);
        }


    }
}