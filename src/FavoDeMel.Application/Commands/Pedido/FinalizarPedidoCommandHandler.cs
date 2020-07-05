using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;
using Flunt.Notifications;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class FinalizarPedidoCommandHandler : ICommandHandler<FinalizarPedidoCommand, FinalizarPedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public FinalizarPedidoCommandHandler(
            IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<FinalizarPedidoResponse> Handler(FinalizarPedidoCommand command)
        {
            var pedido = await _pedidoRepository.ConsultarPorId(command.PedidoId);

            if (pedido == null)
            {
                return new FinalizarPedidoResponse{Erro = new Notification(nameof(command.PedidoId), "Não existe esse pedido")};
            }
            
            pedido.Finalizar();
            
            if (pedido.Notifications.Any())
            {
                return new FinalizarPedidoResponse{Erro = pedido.Notifications};
            }
            
            return new FinalizarPedidoResponse{PedidoId = pedido.Id};
        }
    }
}