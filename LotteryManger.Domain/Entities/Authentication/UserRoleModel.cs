namespace LotteryManger.Domain.Entities.Authentication
{
    /// <summary>
    /// User Role Model
    /// </summary>
    public class UserRoleModel
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
        /// Role Id
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public virtual RoleModel? Role { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public virtual UserModel? User { get; set; }
    }
}