using System.Threading.Tasks;
using FavoDeMel.Application.Queries.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Queries.Pedido
{
    public class ObterPedidoHandler : IQueryHandler<ObterPedidoRequest, ObterPedidoResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ObterPedidoHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ObterPedidoResponse> Handle(ObterPedidoRequest request)
        {
            var pedido = await _pedidoRepository.ConsultarPorId(request.PedidoId);

            return new ObterPedidoResponse(true, "Pedido", pedido);
        }
    }
}