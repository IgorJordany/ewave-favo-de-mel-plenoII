using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class CancelarPedidoCommand : ICommand
    {
        public Guid PedidoId { get; set; }
    }
}