namespace LotteryManger.Domain.Entities.Authentication
{
    /// <summary>
    /// User Model
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// User ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// User roles
        /// </summary>
        public virtual IEnumerable<UserRoleModel> UserRoles { get; set; } = [];
    }
}