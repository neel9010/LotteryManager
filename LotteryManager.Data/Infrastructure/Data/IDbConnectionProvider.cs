namespace LotteryManager.Data.Infrastructure.Data
{
    public interface IDbConnectionProvider
    {
        ISqlConnection GetLotteryManagerConnection(int? connectionTimeout = null);
    }
}