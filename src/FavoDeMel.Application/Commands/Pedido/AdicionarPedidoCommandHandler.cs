using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;
using Flunt.Notifications;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class AdicionarPedidoCommandHandler : ICommandHandler<AdicionarPedidoCommand>
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemRepository _itemRepository;

        public AdicionarPedidoCommandHandler(
            IComandaRepository comandaRepository,
            IPedidoRepository pedidoRepository,
            IItemRepository itemRepository)
        {
            _comandaRepository = comandaRepository;
            _pedidoRepository = pedidoRepository;
            _itemRepository = itemRepository;
        }
        public async Task<ICommandResponse> Handler(AdicionarPedidoCommand command)
        {
            if (!await _comandaRepository.ExisteComandaAbertaPorId(command.ComandaId))
            {
                return new AdicionarPedidoResponse(false, "Erro", new Notification(nameof(command.ComandaId), "Essa comanda não está aberta para inserir pedido"));
            }

            var item = await _itemRepository.ConsultarPorId(command.ItemId);
            
            if (item == null)
            {
                return new AdicionarPedidoResponse(false, "Erro", new Notification(nameof(command.ItemId), "Não existe esse item"));
            }
            
            var pedido = new Core.Entities.Pedido(
                command.ComandaId,
                command.ItemId,
                command.Quantidade,
                item.Cozinha,
                item.Valor);

            if (pedido.Notifications.Any())
            {
                return new AdicionarPedidoResponse(false, "Erro", pedido.Notifications);
            }
            
            await _pedidoRepository.Incluir(pedido);

            return new AdicionarPedidoResponse(true, "Pedido adicionado com sucesso", pedido);
        }
    }
}