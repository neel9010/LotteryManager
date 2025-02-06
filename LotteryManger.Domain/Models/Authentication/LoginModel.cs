using System.ComponentModel.DataAnnotations;

namespace LotteryManger.Domain.Models.Authentication
{
    /// <summary>
    /// Login Model
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Username
        /// </summary>
        [Required]
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}