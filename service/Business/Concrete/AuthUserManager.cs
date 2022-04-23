using System.Net;
using System.Security.Claims;
using AutoMapper;
using Business.Abstract;
using Core.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Dtos;

namespace Business.Concrete
{
    public class AuthUserManager : IAuthUserService
    {
        private IMapper _mapper;
        private IUserDal _userDal;

        public AuthUserManager(IUserDal userDal, IMapper mapper)
        {
            _userDal = userDal;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns the users role.
        /// </summary>
        public async Task<List<OperationClaim>> GetClaims(User user)
        {
            return await _userDal.GetClaims(user);
        }

        /// <summary>
        /// The given entity with dto is added to the database.
        /// </summary>
        public async Task<User> Add(User user)
        {
            return await _userDal.Add(user);
        }

        /// <summary>
        /// Retrieves user by mail
        /// </summary>
        public async Task<IDataResult<User>> GetByMail(string email)
        {
            var result = await _userDal.Get(u => u.Email == email);

            if (result is null)
            {
                return new ErrorDataResult<User>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            return new SuccessDataResult<User>(result, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is updated with the given dto.
        /// </summary>
        public async Task<IResult> Update(User user)
        {
            await _userDal.Update(user);

            return new SuccessResult(Messages.Entity.Updated, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity that matches the given id is returned.
        /// </summary>
        public async Task<IDataResult<User>> GetById(int userId)
        {
            var result = await _userDal.Get(u => u.Id == userId);

            if (result is null)
            {
                return new ErrorDataResult<User>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            return new SuccessDataResult<User>(result, HttpStatusCode.OK);
        }

        /// <summary>
        /// The entity is deleted with the given id.
        /// </summary>
        public async Task<IResult> Delete(User user)
        {
            var _user = await _userDal.Get(x => x.Id == user.Id);

            if (_user is null)
            {
                return new ErrorResult(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            _ = _userDal.Delete(_user);

            return new SuccessResult(Messages.Entity.Deleted, HttpStatusCode.OK);
        }

        /// <summary>
        /// Retrieves user by username
        /// </summary>
        public async Task<IDataResult<User>> GetByUsername(string username)
        {
            var result = await _userDal.Get(u => u.Username == username);

            if (result is null)
            {
                return new ErrorDataResult<User>(Messages.Entity.NotFound, HttpStatusCode.NoContent);
            }

            return new SuccessDataResult<User>(result, HttpStatusCode.OK);
        }
    }
}