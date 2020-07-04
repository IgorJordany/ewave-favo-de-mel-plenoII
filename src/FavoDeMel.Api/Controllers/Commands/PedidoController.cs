using System;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Application.Commands.Pedido;
using FavoDeMel.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/pedido")]
    public class PedidoController : ControllerBase
    {
        private readonly CancelarPedidoCommandHandler _cancelarPedidoCommandHandler;
        private readonly IniciarPreparoPedidoCommandHandler _iniciarPreparoPedidoCommandHandler;
        private readonly FinalizarPedidoCommandHandler _finalizarPedidoCommandHandler;
        private readonly IUow _uow;

        public PedidoController(
            CancelarPedidoCommandHandler cancelarPedidoCommandHandler,
            IniciarPreparoPedidoCommandHandler iniciarPreparoPedidoCommandHandler,
            FinalizarPedidoCommandHandler finalizarPedidoCommandHandler,
            IUow uow)
        {
            _cancelarPedidoCommandHandler = cancelarPedidoCommandHandler;
            _iniciarPreparoPedidoCommandHandler = iniciarPreparoPedidoCommandHandler;
            _finalizarPedidoCommandHandler = finalizarPedidoCommandHandler;
            _uow = uow;
        }

        [HttpPost("{pedidoId}/cancelar")]
        public async Task<ICommandResponse> CancelarPedido([FromRoute] Guid pedidoId)
        {
            var command = new CancelarPedidoCommand
            {
                PedidoId = pedidoId
            };
            
            var response = await _cancelarPedidoCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }

        [HttpPost("{pedidoId}/iniciar-preparo")]
        public async Task<ICommandResponse> IniciarPreparoPedido([FromRoute] Guid pedidoId)
        {
            var command = new IniciarPreparoPedidoCommand
            {
                PedidoId = pedidoId
            };
            
            var response = await _iniciarPreparoPedidoCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
        
        [HttpPost("{pedidoId}/finalizar")]
        public async Task<ICommandResponse> FinalizarPreparoPedido([FromRoute] Guid pedidoId)
        {
            var command = new FinalizarPedidoCommand
            {
                PedidoId = pedidoId
            };
            
            var response = await _finalizarPedidoCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
    }
}