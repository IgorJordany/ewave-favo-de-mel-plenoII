using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.BaseResponse;
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

            return new ObterPedidosCozinhaResponse
            {
                Pedidos = pedidos.Select(p => new PedidoResponse
                {
                    ComandaId = p.ComandaId,
                    Cozinha = p.Cozinha,
                    DataCancelamento = p.DataCancelamento,
                    DataCriacao = p.DataCriacao,
                    DataInicioPreparo = p.DataInicioPreparo,
                    DataPronto = p.DataPronto,
                    ItemId = p.ItemId,
                    Quantidade = p.Quantidade,
                    Status = p.Status,
                    Valor = p.Valor
                }).ToList()
            };
        }
    }
}