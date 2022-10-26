using AirTek.Database.Dtos;
using AirTek.Database.Interfaces;
using AirTek.Database.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AirTek.Database.Extensions
{
    public static class ServiceCollectionExtensions {
        public static void AddDatabaseServices(this ServiceCollection serviceCollection) {
            serviceCollection.AddScoped<IRepositoryJsonService, RepositoryJsonService>();
            serviceCollection.AddScoped<IRepositoryTextService, RepositoryTextService>();
        }
    }
}
