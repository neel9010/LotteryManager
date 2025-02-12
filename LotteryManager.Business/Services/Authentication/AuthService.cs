using LotteryManager.Data.Repositories.Authentication;
using LotteryManger.Domain.Entities.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LotteryManager.Business.Services.Authentication
{
    /// <inheritdoc/>
    public class AuthService(ILogger<AuthService> logger, IAuthRepository authRepository, IConfiguration configuration) : IAuthService
    {
        private readonly IAuthRepository _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        private readonly IConfiguration _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        private readonly ILogger<AuthService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public async Task<UserModel> GetUserByLogin(string username, string password)
        {
            return await _authRepository.GetUserByLogin(username, password);
        }

        public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
        {
            await _authRepository.RemoveRefreshTokenByUserID(refreshTokenModel.UserID);
            await _authRepository.AddRefreshTokenModel(refreshTokenModel);
        }

        public async Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
        {
            return await _authRepository.GetRefreshTokenModel(refreshToken);
        }

        public string? GenerateToken(UserModel user, bool isRefreshToken = false)
        {
            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.Username),
            };

            claims.AddRange(user.UserRoles.Select(n => new Claim(ClaimTypes.Role, n.Role.RoleName)));

            string? secret = _configuration[$"Jwt:{(isRefreshToken ? "RefreshTokenSecret" : "Secret")}"];

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret ?? ""));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "lotteryManager",
                audience: "lotteryManager",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(isRefreshToken ? 24 * 60 : 30),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}