using LotteryManager.Business.Services;
using LotteryManager.Data.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
