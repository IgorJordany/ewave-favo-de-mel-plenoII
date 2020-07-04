using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;
using Flunt.Notifications;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class IniciarPreparoPedidoCommandHandler : ICommandHandler<IniciarPreparoPedidoCommand>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public IniciarPreparoPedidoCommandHandler(
            IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }
        public async Task<ICommandResponse> Handler(IniciarPreparoPedidoCommand command)
        {
            var pedido = await _pedidoRepository.ConsultarPorId(command.PedidoId);

            if (pedido == null)
            {
                return new IniciarPreparoPedidoResponse(false, "Erro", new Notification(nameof(command.PedidoId), "Não existe esse pedido"));
            }
            
            pedido.IniciarPreparo();
            
            if (pedido.Notifications.Any())
            {
                return new IniciarPreparoPedidoResponse(false, "Erro", pedido.Notifications);
            }
            
            return new IniciarPreparoPedidoResponse(true, "Preparo pedido iniciado com sucesso", pedido);
        }
    }
}