using LotteryManager.Data.Repositories.Authentication;
using LotteryManger.Domain.Entities.Authentication;
using Microsoft.Extensions.Logging;

namespace LotteryManager.Business.Services.Authentication
{
    /// <inheritdoc/>
    public class AuthService(ILogger<AuthService> logger, IAuthRepository authRepository) : IAuthService
    {
        private readonly IAuthRepository _authRepository = authRepository ?? throw new ArgumentNullException(nameof(authRepository));
        private readonly ILogger<AuthService> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        public Task<UserModel> GetUserByLogin(string username, string password)
        {
            return authRepository.GetUserByLogin(username, password);
        }

        public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
        {
            await authRepository.RemoveRefreshTokenByUserID(refreshTokenModel.UserID);
            await authRepository.AddRefreshTokenModel(refreshTokenModel);
        }

        public Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
        {
            return authRepository.GetRefreshTokenModel(refreshToken);
        }
    }
}