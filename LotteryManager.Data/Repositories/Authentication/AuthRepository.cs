using LotteryManager.Data.Infrastructure.Data;
using LotteryManger.Domain.Entities.Authentication;
using Microsoft.Extensions.Logging;

namespace LotteryManager.Data.Repositories.Authentication
{
    /// <inheritdoc/>
    public class AuthRepository(ILogger<AuthRepository> logger, IDbConnectionProvider dbConnectionProvider) : IAuthRepository
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IDbConnectionProvider _dbConnectionProvider = dbConnectionProvider ?? throw new ArgumentNullException(nameof(dbConnectionProvider));

        public Task<UserModel> GetUserByLogin(string username, string password)
        {
            return null;
        }

        public async Task RemoveRefreshTokenByUserID(int userID)
        {
            return;
        }

        public async Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel)
        {
            return;
        }

        public Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken)
        {
            return null;
        }
    }
}