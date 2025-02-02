using LotteryManager.Data.Repositories;
using LotteryManger.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace LotteryManager.Business.Services
{
    /// <inheritdoc/>
    public class GameService(ILogger<GameService> logger, IGameRepository gameRepository) : IGameService
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IGameRepository _gameRepository = gameRepository ?? throw new ArgumentException(nameof(gameRepository));

        public async Task<IEnumerable<Game>?> GetAllGamesByStateAsync(string state)
        {
            _logger.LogInformation($"Getting All Games for State:{state}");

            return await _gameRepository.GetAllGamesByStateAsync(state);
        }
    }
}