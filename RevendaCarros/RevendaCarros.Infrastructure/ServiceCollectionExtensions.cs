using Microsoft.Extensions.DependencyInjection;
using RevendaCarros.Domain.Repositories;
using RevendaCarros.Infrastructure.Repositories;

namespace RevendaCarros.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IImpostoRepository, ImpostoRepository>();

            return services;
        }
    }
}