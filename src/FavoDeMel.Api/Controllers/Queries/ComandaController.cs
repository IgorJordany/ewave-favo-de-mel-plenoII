using System.Threading.Tasks;
using FavoDeMel.Application.Queries.Comanda;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/comandas")]
    public class ComandaController : ControllerBase
    {
        private readonly ObterComandasAbertasHandler _obterComandasHandler;

        public ComandaController(ObterComandasAbertasHandler obterComandasHandler)
        {
            _obterComandasHandler = obterComandasHandler;
        }
        
        [HttpGet("")]
        public async Task<ObterComandasAbertasResponse> ObterLista()
        {
            var response = await _obterComandasHandler.Handle(new ObterComandasAbertasRequest());
            return response;
        }
    }
}