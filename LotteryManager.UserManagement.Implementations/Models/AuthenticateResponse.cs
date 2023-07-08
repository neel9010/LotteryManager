using LotteryManager.UserManagement.Interfaces;

namespace LotteryManager.UserManagement.Implementations
{
    public class AuthenticateResponse : IAuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}