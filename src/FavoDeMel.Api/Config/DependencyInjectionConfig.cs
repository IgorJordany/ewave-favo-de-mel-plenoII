using Favo_de_mel.Core.Repositories;
using FavoDeMel.Application.Commands.Comanda;
using FavoDeMel.Infrastructure.Abstractions;
using FavoDeMel.Infrastructure.Data;
using FavoDeMel.Infrastructure.Repositories;
using FavoDeMel.Infrastructure.Transaction;
using Microsoft.Extensions.DependencyInjection;

namespace FavoDeMel.Api.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DatabaseContext, DatabaseContext>();

            services.AddScoped<IComandaRepository, ComandaRepository>();
            services.AddScoped<AbrirComandaCommandHandler, AbrirComandaCommandHandler>();

            services.AddScoped<IUow, Uow>();
            
            return services;
        }
    }
}