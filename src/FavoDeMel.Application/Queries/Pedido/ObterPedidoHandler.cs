using System.Threading.Tasks;
using FavoDeMel.Application.BaseResponse;
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

            return new ObterPedidoResponse
            {
                Pedido = new PedidoResponse
                {
                    ComandaId = pedido.ComandaId,
                    Cozinha = pedido.Cozinha,
                    DataCancelamento = pedido.DataCancelamento,
                    DataCriacao = pedido.DataCriacao,
                    DataInicioPreparo = pedido.DataInicioPreparo,
                    DataPronto = pedido.DataPronto,
                    ItemId = pedido.ItemId,
                    Quantidade = pedido.Quantidade,
                    Status = pedido.Status,
                    Valor = pedido.Valor
                }
            };
        }
    }
}