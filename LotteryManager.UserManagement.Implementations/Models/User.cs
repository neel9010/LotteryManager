using LotteryManager.UserManagement.Interfaces;
using System.Text.Json.Serialization;

namespace LotteryManager.UserManagement.Implementations
{
    public class User : IUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;
    }
}