namespace LotteryManger.Domain.Entities.Authentication
{
    /// <summary>
    /// Refresh Token Model
    /// </summary>
    public class RefreshTokenModel
    {
        /// <summary>
        /// Id
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Refresh Token
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;

        /// <summary>
        /// User <see cref="UserModel"/>
        /// </summary>
        public virtual UserModel? User { get; set; }
    }
}