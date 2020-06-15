using Shp.Core.Entities.Concrete;
using Shp.Core.Utilities.Results;
using Shp.Core.Utilities.Security.Jwt;
using Shp.Entities.Dtos;

namespace Shp.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserRegisterDto userRegisterDto, string password);
        IDataResult<User> Login(UserLoginDto userLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
