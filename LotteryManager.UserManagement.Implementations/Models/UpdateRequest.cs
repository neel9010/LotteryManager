using LotteryManager.UserManagement.Interfaces;

namespace LotteryManager.UserManagement.Implementations
{
    public class UpdateRequest : IUpdateRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}