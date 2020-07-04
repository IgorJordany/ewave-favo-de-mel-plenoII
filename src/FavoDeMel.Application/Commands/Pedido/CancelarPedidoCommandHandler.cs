using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;
using Flunt.Notifications;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class CancelarPedidoCommandHandler : ICommandHandler<CancelarPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CancelarPedidoCommandHandler(
            IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<ICommandResponse> Handler(CancelarPedidoCommand command)
        {
            var pedido = await _pedidoRepository.ConsultarPorId(command.PedidoId);

            if (pedido == null)
            {
                return new CancelarPedidoResponse(false, "Erro", new Notification(nameof(command.PedidoId), "Não existe esse pedido"));
            }
            
            pedido.Cancelar();
            
            if (pedido.Notifications.Any())
            {
                return new CancelarPedidoResponse(false, "Erro", pedido.Notifications);
            }
            
            return new CancelarPedidoResponse(true, "Pedido Cancelado com sucesso", pedido);
        }
    }
}