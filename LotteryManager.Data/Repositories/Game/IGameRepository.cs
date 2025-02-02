using LotteryManger.Domain.Entities;

namespace LotteryManager.Data.Repositories
{
    /// <summary>
    /// Manage Lottery Instant game data
    /// </summary>
    public interface IGameRepository
    {
        /// <summary>
        /// Get All Games By State
        /// </summary>
        /// <param name="state">State of the Game being sold </param>
        /// <returns>All games for the state</returns>
        Task<IEnumerable<Game>?> GetAllGamesByStateAsync(string state);
    }
}