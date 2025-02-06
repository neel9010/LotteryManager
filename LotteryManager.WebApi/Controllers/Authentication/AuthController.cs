using LotteryManager.Business.Services.Authentication;
using LotteryManger.Domain.Entities.Authentication;
using LotteryManger.Domain.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
            var user = await _authService.GetUserByLogin(loginModel.Username, loginModel.Password);
            if (user != null)
            {
                var token = GenerateJwtToken(user, isRefreshToken: false);
                var refreshToken = GenerateJwtToken(user, isRefreshToken: true);

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
            return null;
        }

        [HttpGet("loginByRefeshToken")]
        public async Task<ActionResult<LoginResponseModel>> LoginByRefeshToken(string refreshToken)
        {
            var refreshTokenModel = await _authService.GetRefreshTokenModel(refreshToken);
            if (refreshTokenModel == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var newToken = GenerateJwtToken(refreshTokenModel.User, isRefreshToken: false);
            var newRefreshToken = GenerateJwtToken(refreshTokenModel.User, isRefreshToken: true);

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

        private string GenerateJwtToken(UserModel user, bool isRefreshToken)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, user.Username),
            };
            claims.AddRange(user.UserRoles.Select(n => new Claim(ClaimTypes.Role, n.Role.RoleName)));

            string secret = _configuration?.GetValue<string>($"Jwt:{(isRefreshToken ? "RefreshTokenSecret" : "Secret")}");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "doseHieu",
                audience: "doseHieu",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(isRefreshToken ? 24 * 60 : 30),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
