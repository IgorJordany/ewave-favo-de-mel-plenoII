using System;
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
        private readonly FecharComandaCommandHandler _fecharComandaCommandHandler;
        private readonly IUow _uow;

        public ComandaController(
            AbrirComandaCommandHandler abrirComandaCommandHandler,
            FecharComandaCommandHandler fecharComandaCommandHandler,
            IUow uow)
        {
            _abrirComandaCommandHandler = abrirComandaCommandHandler;
            _fecharComandaCommandHandler = fecharComandaCommandHandler;
            _uow = uow;
        }
        
        [HttpPost("abrir/{mesa}")]
        public async Task<ICommandResponse> AbrirComanda([FromRoute] byte mesa)
        {
            var command = new AbrirComandaCommand
            {
                Mesa = mesa
            };
            
            var response = await _abrirComandaCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
        
        [HttpPost("fechar/{id}")]
        public async Task<ICommandResponse> FecharComanda([FromRoute] Guid id)
        {
            var command = new FecharComandaCommand
            {
                Id = id
            };
            
            var response = await _fecharComandaCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
    }
}