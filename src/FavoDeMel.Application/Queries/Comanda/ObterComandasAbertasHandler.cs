using System.Threading.Tasks;
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

            return new ObterComandasAbertasResponse(true, "Comandas abertas", comandas);
        }
    }
}