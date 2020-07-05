using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.BaseResponse;
using FavoDeMel.Application.Queries.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandasAbertasHandler : IQueryHandler<ObterComandasAbertasRequest, ObterComandasAbertasResponse>
    {
        private readonly IComandaRepository _comandaRepository;

        public ObterComandasAbertasHandler(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<ObterComandasAbertasResponse> Handle(ObterComandasAbertasRequest request)
        {
            var comandas = await _comandaRepository.ListarComandasAbertas();

            return new ObterComandasAbertasResponse
            {
                Comandas = comandas.Select(c => new ComandaResponse
                {
                    DataAbertura = c.DataAbertura,
                    DataFechamento = c.DataFechamento,
                    Mesa = c.Mesa,
                    Pedidos = c.Pedidos.Select(p => new PedidoResponse
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
                    }).ToList(),
                    Status = c.Status,
                    TotalPagar = c.TotalPagar
                }).ToList()
            };
        }
    }
}