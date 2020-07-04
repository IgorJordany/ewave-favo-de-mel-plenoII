using System.Threading.Tasks;
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
            var comandas = await _comandaRepository.ConsultarPorId(request.ComandaId);

            return new ObterComandaResponse(true, "Comandas", comandas);
        }
    }
}