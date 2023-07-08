namespace LotteryManager.UserManagement.Interfaces
{
    public interface IAuthenticateRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }
}