using LotteryManager.UserManagement.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LotteryManager.UserManagement.Implementations
{
    public class AuthenticateRequest : IAuthenticateRequest
    {
        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}