namespace LotteryManger.Domain.Models.Authentication
{
    /// <summary>
    /// Login Response Model
    /// </summary>
    public class LoginResponseModel
    {
        /// <summary>
        /// JWT
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Token Expire time
        /// </summary>
        public long TokenExpired { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;
    }
}