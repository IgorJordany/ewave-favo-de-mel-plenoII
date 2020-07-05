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
        private readonly ObterComandasHandler _obterComandasHandler;

        public ComandaController(
            ObterComandasAbertasHandler obterComandasAbertasHandler,
            ObterComandaHandler obterComandaHandler,
            ObterComandasHandler obterComandasHandler)
        {
            _obterComandasAbertasHandler = obterComandasAbertasHandler;
            _obterComandaHandler = obterComandaHandler;
            _obterComandasHandler = obterComandasHandler;
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
        
        [HttpGet("")]
        public async Task<ObterComandasResponse> ObterComandas()
        {
            var response = await _obterComandasHandler.Handle(new ObterComandasRequest());
            return response;
        }
    }
}