using LotteryManager.DataAccess.Interfaces;
using LotteryManager.Domain.Game;
using LotteryManager.Services.Interfaces;

namespace LotteryManager.Services.Implementations
{
    public class GameService : IGameService
    {
        private readonly IDBAccess _dBAccess;

        public GameService(IDBAccess dBAccess)
        {
            _dBAccess = dBAccess;
        }

        public async Task<IEnumerable<Game>> GetAllGames(string state)
        {
            var data = await _dBAccess.LoadData<Game, dynamic>(@"SELECT * FROM [LotteryManager].[dbo].[Game] WHERE STATE = @state", new { state });
            return data;
        }
    }
}