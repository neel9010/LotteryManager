using LotteryManager.Business.Services.Authentication;
using LotteryManger.Domain.Entities.Authentication;
using LotteryManger.Domain.Models.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LotteryManager.WebApi.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration configuration, IAuthService authService) : ControllerBase
    {
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        private readonly IAuthService _authService = authService ?? throw new ArgumentNullException(nameof(authService));

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseModel>> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _authService.GetUserByLogin(loginModel.Username, loginModel.Password);

            if (user is null)
            {
                return NotFound();
            }

            var token = _authService.GenerateToken(user, isRefreshToken: false);
            var refreshToken = _authService.GenerateToken(user, isRefreshToken: true);

            await _authService.AddRefreshTokenModel(new RefreshTokenModel
            {
                RefreshToken = refreshToken,
                UserID = user.ID
            });

            return Ok(new LoginResponseModel
            {
                Token = token,
                RefreshToken = refreshToken,
                TokenExpired = DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds(),
            });
        }

        [HttpGet("loginByRefeshToken")]
        public async Task<ActionResult<LoginResponseModel>> LoginByRefeshToken(string refreshToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var refreshTokenModel = await _authService.GetRefreshTokenModel(refreshToken);
            if (refreshTokenModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var newToken = _authService.GenerateToken(refreshTokenModel.User, isRefreshToken: false);
            var newRefreshToken = _authService.GenerateToken(refreshTokenModel.User, isRefreshToken: true);

            await _authService.AddRefreshTokenModel(new RefreshTokenModel
            {
                RefreshToken = newRefreshToken,
                UserID = refreshTokenModel.UserID
            });

            return new LoginResponseModel
            {
                Token = newToken,
                TokenExpired = DateTimeOffset.UtcNow.AddMinutes(30).ToUnixTimeSeconds(),
                RefreshToken = newRefreshToken,
            };
        }
    }
}