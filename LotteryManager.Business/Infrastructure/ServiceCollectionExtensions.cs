using LotteryManager.Business.Services;
using LotteryManager.Business.Services.Authentication;
using LotteryManager.Data.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LotteryManager.Business.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // add data access layer
            serviceCollection.AddDbInfrastructure(configuration);

            // add providers

            // add business layer services
            serviceCollection.AddScoped<IGameService, GameService>();
            serviceCollection.AddScoped<IAuthService, AuthService>();
        }
    }
}