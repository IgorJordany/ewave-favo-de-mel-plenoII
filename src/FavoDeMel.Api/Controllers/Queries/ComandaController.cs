using System;
using System.Threading.Tasks;
using FavoDeMel.Application.Queries.Comanda;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/comandas")]
    public class ComandaController : ControllerBase
    {
        private readonly ObterComandasAbertasHandler _obterComandasAbertasHandler;
        private readonly ObterComandaHandler _obterComandaHandler;

        public ComandaController(
            ObterComandasAbertasHandler obterComandasAbertasHandler,
            ObterComandaHandler obterComandaHandler)
        {
            _obterComandasAbertasHandler = obterComandasAbertasHandler;
            _obterComandaHandler = obterComandaHandler;
        }
        
        [HttpGet("abertas")]
        public async Task<ObterComandasAbertasResponse> ObterComandasAbertas()
        {
            var response = await _obterComandasAbertasHandler.Handle(new ObterComandasAbertasRequest());
            return response;
        }
        
        [HttpGet("{comandaId}")]
        public async Task<ObterComandaResponse> ObterComanda([FromRoute] Guid comandaId)
        {
            var response = await _obterComandaHandler.Handle(new ObterComandaRequest{ComandaId = comandaId});
            
            return response;
        }
    }
}