using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.BaseResponse;
using FavoDeMel.Application.Queries.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandasHandler : IQueryHandler<ObterComandasRequest, ObterComandasResponse>
    {
        private readonly IComandaRepository _comandaRepository;

        public ObterComandasHandler(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<ObterComandasResponse> Handle(ObterComandasRequest request)
        {
            var comandas = await _comandaRepository.ListarComandas();

            return new ObterComandasResponse
            {
                Comandas = comandas.Select(c => new ComandaResponse
                {
                    Id = c.Id,
                    DataAbertura = c.DataAbertura,
                    DataFechamento = c.DataFechamento,
                    Mesa = c.Mesa,
                    Pedidos = c.Pedidos.Select(p => new PedidoResponse
                    {
                        Id = p.Id,
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