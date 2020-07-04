using System;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Entities;
using FavoDeMel.Core.Enums;
using FavoDeMel.Core.Repositories;
using FavoDeMel.Infrastructure.Data;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class AdicionarPedidoCommandHandler : ICommandHandler<AdicionarPedidoCommand>
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly DatabaseContext _databaseContext;

        public AdicionarPedidoCommandHandler(
            IComandaRepository comandaRepository,
            DatabaseContext databaseContext)
        {
            _comandaRepository = comandaRepository;
            _databaseContext = databaseContext;
        }
        public async Task<ICommandResponse> Handler(AdicionarPedidoCommand command)
        {
            //TODO criar repositorio para pedido
            var pedido = new Pedido(
                PedidoStatus.AguardandoPreparo,
                DateTime.Now,
                null,
                null,
                command.Id,
                command.ItemId,
                command.Quantidade);
            
            await _databaseContext.Pedidos.AddAsync(pedido);

            return new AdicionarPedidoResponse(true, "Pedido adicionado com sucesso", pedido);
        }
    }
}