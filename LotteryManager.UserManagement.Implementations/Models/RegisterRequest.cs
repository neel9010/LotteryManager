using LotteryManager.UserManagement.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LotteryManager.UserManagement.Implementations
{
    public class RegisterRequest : IRegisterRequest
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}