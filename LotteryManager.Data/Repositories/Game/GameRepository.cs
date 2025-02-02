using Dapper;
using LotteryManager.Data.Infrastructure.Data;
using LotteryManger.Domain.Entities;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;
using System.Data;

namespace LotteryManager.Data.Repositories
{
    /// <inheritdoc/>
    public class GameRepository(ILogger<GameRepository> logger, IDbConnectionProvider dbConnectionProvider) : IGameRepository
    {
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IDbConnectionProvider _dbConnectionProvider = dbConnectionProvider ?? throw new ArgumentNullException(nameof(dbConnectionProvider));

        public async Task<IEnumerable<Game>?> GetAllGamesByStateAsync(string state)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(state);

            IEnumerable<Game> games;

            const string gamesSQL = @"SELECT gameID,gameName,validationStatus, ticketPrice,totalTicketsInPack
                                      FROM Game WHERE state = @state";

            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@state", state, DbType.AnsiString, size: 2);

            using (var connection = _dbConnectionProvider.GetLotteryManagerConnection())
            {
                games = await connection.QueryAsync<Game>(gamesSQL, dynamicParameters, commandType: CommandType.Text);
            }

            return games;
        }
    }
}