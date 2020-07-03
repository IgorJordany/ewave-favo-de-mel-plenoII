using FavoDeMel.Application.Commands.Comanda;
using FavoDeMel.Application.Queries.Comanda;
using FavoDeMel.Core.Repositories;
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
            
            //Repositorios
            services.AddScoped<IComandaRepository, ComandaRepository>();
            
            //CommandHandlers
            services.AddScoped<AbrirComandaCommandHandler, AbrirComandaCommandHandler>();
            services.AddScoped<FecharComandaCommandHandler, FecharComandaCommandHandler>();

            //QueryHandlers
            services.AddScoped<ObterComandasAbertasHandler, ObterComandasAbertasHandler>();

            services.AddScoped<IUow, Uow>();
            
            return services;
        }
    }
}