using Microsoft.AspNetCore.Mvc;
using Shp.Business.Abstract;
using Shp.Entities.Dtos;

namespace Shp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region ctor

        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        #endregion

        #region Register

        [HttpPost("register")]
        public ActionResult Register(UserRegisterDto userLoginDto)
        {
            var userExist = _authService.UserExists(userLoginDto.Email);
            if (!userExist.Success)
                return BadRequest(userExist.Message);

            var registerResult = _authService.Register(userLoginDto);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        #endregion

        #region Login

        [HttpPost("login")]
        public ActionResult Login(UserLoginDto userLoginDto)
        {
            var userToLogin = _authService.Login(userLoginDto);
            if (!userToLogin.Success)
                return BadRequest(userToLogin.Message);

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        #endregion
    }
}