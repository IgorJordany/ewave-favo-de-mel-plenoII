using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class AdicionarPedidoResponse : ICommandResponse
    {
        public object Erro { get; set; }
        public Guid PedidoId { get; set; }
    }
}