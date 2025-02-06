namespace LotteryManger.Domain.Entities.Authentication
{
    /// <summary>
    /// Role Model
    /// </summary>
    public class RoleModel
    {
        /// <summary>
        /// Role ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Role Name
        /// </summary>
        public string RoleName { get; set; } = string.Empty;
    }
}