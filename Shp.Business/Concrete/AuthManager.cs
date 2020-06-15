using System;
using Shp.Business.Abstract;
using Shp.Business.Constants.User;
using Shp.Core.Entities.Concrete;
using Shp.Core.Utilities.Results;
using Shp.Core.Utilities.Security.Hashing;
using Shp.Core.Utilities.Security.Jwt;
using Shp.Entities.Dtos;

namespace Shp.Business.Concrete
{
    public sealed class AuthManager : IAuthService
    {
        #region ctor

        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        #endregion

        #region Register

        public IDataResult<User> Register(UserRegisterDto userRegisterDto, string password)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Login

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var user = _userService.GetUserByEmail(userLoginDto.Email);
            if (user == null) 
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash))
                return new ErrorDataResult<User>(UserMessages.PasswordError);
            return new SuccessDataResult<User>(user, UserMessages.SuccesfulLogin);
        }

        #endregion

        #region UserExists

        public IResult UserExists(string email)
        {
            if (_userService.GetUserByEmail(email) != null)
                return new ErrorResult(UserMessages.UserAlreadyExist);
            return new SuccessResult();
        }

        #endregion

        #region CreateAccessToken
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
