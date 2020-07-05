using System;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Comanda;
using FavoDeMel.Application.Commands.Pedido;
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
        private readonly AdicionarPedidoCommandHandler _adicionarPedidoCommandHandler;
        private readonly IUow _uow;

        public ComandaController(
            AbrirComandaCommandHandler abrirComandaCommandHandler,
            FecharComandaCommandHandler fecharComandaCommandHandler,
            AdicionarPedidoCommandHandler adicionarPedidoCommandHandler,
            IUow uow)
        {
            _abrirComandaCommandHandler = abrirComandaCommandHandler;
            _fecharComandaCommandHandler = fecharComandaCommandHandler;
            _adicionarPedidoCommandHandler = adicionarPedidoCommandHandler;
            _uow = uow;
        }
        
        [HttpPost("abrir/{mesa}")]
        public async Task<AbrirComandaResponse> AbrirComanda([FromRoute] byte mesa)
        {
            var command = new AbrirComandaCommand
            {
                Mesa = mesa
            };
            
            var response = await _abrirComandaCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
        
        [HttpPost("{comandaId}/fechar")]
        public async Task<FecharComandaResponse> FecharComanda([FromRoute] Guid comandaId)
        {
            var command = new FecharComandaCommand
            {
                Id = comandaId
            };
            
            var response = await _fecharComandaCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
        
        [HttpPost("{comandaId}/adicionar-pedido")]
        public async Task<AdicionarPedidoResponse> AdicionarPedido([FromRoute] Guid comandaId, [FromBody] AdicionarPedidoCommand command)
        {
            command.ComandaId = comandaId;
            
            var response = await _adicionarPedidoCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
    }
}