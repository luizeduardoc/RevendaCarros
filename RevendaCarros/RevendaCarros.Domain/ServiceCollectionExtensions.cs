using Microsoft.Extensions.DependencyInjection;
using RevendaCarros.Domain.Services;
using RevendaCarros.Domain.Services.Interfaces;

namespace RevendaCarros.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<IImpostoService, ImpostoService>();
            services.AddTransient<IVeiculoService, VeiculoService>();

            return services;
        }
    }
}