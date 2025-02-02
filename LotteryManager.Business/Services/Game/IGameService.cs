using LotteryManger.Domain.Entities;

namespace LotteryManager.Business.Services

{
    /// <summary>
    /// Manage Lottery Instant Game Data
    /// </summary>
    public interface IGameService
    {
        /// <summary>
        /// Get All Games By State
        /// </summary>
        /// <param name="state">State of the Game being sold </param>
        /// <returns>All games for the state</returns>
        Task<IEnumerable<Game>?> GetAllGamesByStateAsync(string state);
    }
}