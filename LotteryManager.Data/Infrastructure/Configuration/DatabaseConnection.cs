namespace LotteryManager.Data.Infrastructure.Configuration
{
    public class DatabaseConnection
    {
        public required string SqlServer { get; set; }
        public required string DatabaseName { get; set; }
        public required string UserId { get; set; }
        public required string Password { get; set; }
    }
}