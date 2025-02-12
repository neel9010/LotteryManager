using Dapper;
using LotteryManager.Data.Infrastructure.Configuration;
using LotteryManager.Data.Infrastructure.Data;
using LotteryManager.Data.Repositories;
using LotteryManager.Data.Repositories.Authentication;
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
                    DatabaseName = configuration["ConnectionString:Database"] ?? string.Empty,
                    SqlServer = configuration["ConnectionString:DbServer"] ?? string.Empty,
                    UserId = configuration["ConnectionString:UserId"] ?? string.Empty,
                    Password = configuration["ConnectionString:Password"] ?? string.Empty
                };
            });

            // Data providers
            serviceCollection.AddScoped<IDbConnectionProvider, SqlDbConnectionProvider>();
            serviceCollection.AddScoped<IGameRepository, GameRepository>();
            serviceCollection.AddScoped<IAuthRepository, AuthRepository>();
        }
    }
}