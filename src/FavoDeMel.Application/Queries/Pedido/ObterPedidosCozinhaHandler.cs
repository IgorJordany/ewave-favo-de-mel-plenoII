using System.Threading.Tasks;
using FavoDeMel.Application.Queries.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Queries.Pedido
{
    public class ObterPedidosCozinhaHandler : IQueryHandler<ObterPedidosCozinhaRequest, ObterPedidosCozinhaResponse>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ObterPedidosCozinhaHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ObterPedidosCozinhaResponse> Handle(ObterPedidosCozinhaRequest request)
        {
            var pedidos = await _pedidoRepository.ListarPedidosCozinha();

            return new ObterPedidosCozinhaResponse(true, "Pedidos Cozinha", pedidos);
        }
    }
}