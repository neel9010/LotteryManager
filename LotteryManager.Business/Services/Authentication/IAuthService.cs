using LotteryManger.Domain.Entities.Authentication;

namespace LotteryManager.Business.Services.Authentication
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        Task<UserModel> GetUserByLogin(string username, string password);

        /// <summary>
        /// Add Refreshtoken
        /// </summary>
        /// <param name="refreshTokenModel">Refresh Token Model <see cref="RefreshTokenModel"/></param>
        Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel);

        /// <summary>
        /// Get Refresh Token
        /// </summary>
        /// <param name="refreshToken">Refresh Token</param>
        /// <returns>Refresh Token Model <see cref="RefreshTokenModel"/></returns>
        Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken);

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="user">User <see cref="UserModel"/></param>
        /// <param name="isRefreshToken">Is generating refresh token</param>
        /// <returns></returns>
        string? GenerateToken(UserModel user, bool isRefreshToken = false);
    }
}