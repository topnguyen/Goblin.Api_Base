using Microsoft.Extensions.DependencyInjection;

namespace Goblin.Api_Base.Repository
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddGoblinDbContext(this IServiceCollection services)
        {
            GoblinDbContextSetup.Build(services, null);
            
            return services;
        }
    }
}