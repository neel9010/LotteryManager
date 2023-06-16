using LotteryManager.Domain.Game;

namespace LotteryManager.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllGames(string state);
    }
}