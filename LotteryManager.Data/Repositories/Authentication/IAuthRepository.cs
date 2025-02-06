using LotteryManger.Domain.Entities.Authentication;

namespace LotteryManager.Data.Repositories.Authentication
{
    /// <summary>
    /// Authentication Repository
    /// </summary>
    public interface IAuthRepository
    {
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        Task<UserModel> GetUserByLogin(string username, string password);

        /// <summary>
        /// Remove Refreash Token for user
        /// </summary>
        /// <param name="userID">UserId</param>
        /// <returns></returns>
        Task RemoveRefreshTokenByUserID(int userID);

        /// <summary>
        /// Add Refresh Token
        /// </summary>
        /// <param name="refreshTokenModel">Refresh Token Information <see cref="RefreshTokenModel"/></param>
        /// <returns></returns>
        Task AddRefreshTokenModel(RefreshTokenModel refreshTokenModel);

        /// <summary>
        /// Get Refresh Token
        /// </summary>
        /// <param name="refreshToken">Refresh Token</param>
        /// <returns><see cref="RefreshTokenModel"/></returns>
        Task<RefreshTokenModel> GetRefreshTokenModel(string refreshToken);
    }
}