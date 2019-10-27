using ConsumoRestaurante.Domain.Interfaces;
using ConsumoRestaurante.Domain.Interfaces.Repositories;
using ConsumoRestaurante.Infra.Data.Repositories;
using ConsumoRestaurante.Infra.Data.UoW;
using Microsoft.Extensions.DependencyInjection;

namespace ConsumoRestaurante.Infra.CrossCutting.IoC
{
    public static class DependencyInjector
    {
        public static void AddDependencyInjector(this IServiceCollection services)
        {
            services.AddScoped<IRestauranteRepository, RestauranteRepository>();
            services.AddScoped<IConsumoRepository, ConsumoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
