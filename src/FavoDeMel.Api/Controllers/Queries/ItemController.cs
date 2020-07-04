using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/itens")]
    public class ItemController : ControllerBase
    {
        public ItemController()
        {
            
        }
        
        // [HttpGet("")]
        // public async Task<ObterComandasAbertasResponse> ObterLista()
        // {
        //     var response = await _obterComandasHandler.Handle(new ObterComandasAbertasRequest());
        //     return response;
        // }
    }
}