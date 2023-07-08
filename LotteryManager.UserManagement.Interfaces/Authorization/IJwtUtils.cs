namespace LotteryManager.UserManagement.Interfaces
{
    public interface IJwtUtils
    {
        public string GenerateToken(IUser user);

        public int? ValidateToken(string token);
    }
}