using Dapper;
using LotteryManager.Data.Infrastructure.Configuration;
using LotteryManager.Data.Infrastructure.Data;
using LotteryManager.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace LotteryManager.Data.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Default map Dapper's string to AnsiString for varchar.
            SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
            DbString.IsAnsiDefault = true;

            // Database configuration
            serviceCollection.Configure<DatabaseConnectionConfiguration>(connectionConfiguration =>
            {
                // Lottery Manager SQL configuration
                connectionConfiguration.LotteryManger = new DatabaseConnection
                {
                    DatabaseName = configuration["ConnectionString:Database"],
                    SqlServer = configuration["ConnectionString:DbServer"],
                    UserId = configuration["ConnectionString:UserId"],
                    Password = configuration["ConnectionString:Password"]
                };
            });

            // Data providers
            serviceCollection.AddScoped<IDbConnectionProvider, SqlDbConnectionProvider>();
            serviceCollection.AddScoped<IGameRepository, GameRepository>();
        }
    }
}