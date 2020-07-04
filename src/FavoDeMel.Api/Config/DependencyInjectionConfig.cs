using FavoDeMel.Application.Commands.Comanda;
using FavoDeMel.Application.Commands.Item;
using FavoDeMel.Application.Commands.Pedido;
using FavoDeMel.Application.Queries.Comanda;
using FavoDeMel.Application.Queries.Pedido;
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
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();

            //CommandHandlers
            //Comanda
            services.AddScoped<AbrirComandaCommandHandler, AbrirComandaCommandHandler>();
            services.AddScoped<FecharComandaCommandHandler, FecharComandaCommandHandler>();
            
            //Pedido
            services.AddScoped<AdicionarPedidoCommandHandler, AdicionarPedidoCommandHandler>();
            services.AddScoped<CancelarPedidoCommandHandler, CancelarPedidoCommandHandler>();
            services.AddScoped<IniciarPreparoPedidoCommandHandler, IniciarPreparoPedidoCommandHandler>();
            services.AddScoped<FinalizarPedidoCommandHandler, FinalizarPedidoCommandHandler>();

            //Item
            services.AddScoped<InserirItemCommandHandler, InserirItemCommandHandler>();

            //QueryHandlers
            services.AddScoped<ObterComandasAbertasHandler, ObterComandasAbertasHandler>();
            services.AddScoped<ObterPedidosCozinhaHandler, ObterPedidosCozinhaHandler>();
            services.AddScoped<ObterComandaHandler, ObterComandaHandler>();
            services.AddScoped<ObterPedidoHandler, ObterPedidoHandler>();
            
            services.AddScoped<IUow, Uow>();
            
            return services;
        }
    }
}