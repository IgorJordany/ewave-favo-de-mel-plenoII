using System;
using System.Threading.Tasks;
using FavoDeMel.Application.Queries.Comanda;
using FavoDeMel.Application.Queries.Pedido;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/pedidos")]
    public class PedidoController
    {
        private readonly ObterPedidosCozinhaHandler _obterPedidosCozinhaHandler;
        private readonly ObterPedidoHandler _obterPedidoHandler;

        public PedidoController(
            ObterPedidosCozinhaHandler obterPedidosCozinhaHandler,
            ObterPedidoHandler obterPedidoHandler)
        {
            _obterPedidosCozinhaHandler = obterPedidosCozinhaHandler;
            _obterPedidoHandler = obterPedidoHandler;
        }
        
        [HttpGet("cozinha")]
        public async Task<ObterPedidosCozinhaResponse> ObterPedidosCozinha()
        {
            var response = await _obterPedidosCozinhaHandler.Handle(new ObterPedidosCozinhaRequest());
            return response;
        }
        
        [HttpGet("{pedidoId}")]
        public async Task<ObterPedidoResponse> ObterPedido([FromRoute]Guid pedidoId)
        {
            var response = await _obterPedidoHandler.Handle(new ObterPedidoRequest{PedidoId = pedidoId});
            return response;
        }        
    }
}