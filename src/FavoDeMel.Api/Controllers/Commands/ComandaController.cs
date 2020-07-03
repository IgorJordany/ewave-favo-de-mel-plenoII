using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Application.Commands.Comanda;
using FavoDeMel.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/comanda")]
    public class ComandaController : ControllerBase
    {
        private readonly AbrirComandaCommandHandler _abrirComandaCommandHandler;
        private readonly IUow _uow;

        public ComandaController(
            AbrirComandaCommandHandler abrirComandaCommandHandler,
            IUow uow)
        {
            _abrirComandaCommandHandler = abrirComandaCommandHandler;
            _uow = uow;
        }
        
        [HttpPost("abrir")]
        public async Task<ICommandResponse> AbrirComanda([FromBody] AbrirComandaCommand command)
        {
            var response = await _abrirComandaCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
    }
}