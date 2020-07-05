using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.BaseResponse;
using FavoDeMel.Application.Queries.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandaHandler : IQueryHandler<ObterComandaRequest, ObterComandaResponse>
    {
        private readonly IComandaRepository _comandaRepository;

        public ObterComandaHandler(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }

        public async Task<ObterComandaResponse> Handle(ObterComandaRequest request)
        {
            var comanda = await _comandaRepository.ConsultarPorId(request.ComandaId);

            return new ObterComandaResponse
            {
                Comanda = new ComandaResponse
                {
                    DataAbertura = comanda.DataAbertura,
                    DataFechamento = comanda.DataFechamento,
                    Mesa = comanda.Mesa,
                    Pedidos = comanda.Pedidos.Select(p => new PedidoResponse
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
                }
            };
        }
    }
}