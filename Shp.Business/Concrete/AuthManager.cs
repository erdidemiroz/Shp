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

        public IDataResult<User> Register(UserRegisterDto userRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userRegisterDto.Email,
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSAlt = passwordSalt,
                Status = false
            };
            _userService.AddUser(user);
            return new SuccessDataResult<User>(user, UserMessages.UserRegistered);
        }

        #endregion

        #region Login

        public IDataResult<User> Login(UserLoginDto userLoginDto)
        {
            var user = _userService.GetUserByEmail(userLoginDto.Email);
            if (user == null) 
                return new ErrorDataResult<User>(UserMessages.UserNotFound);
            if (!HashingHelper.VerifyPasswordHash(userLoginDto.Password, user.PasswordHash, user.PasswordSAlt))
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
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, UserMessages.AccessTokenCreated);
        }

        #endregion
    }
}
