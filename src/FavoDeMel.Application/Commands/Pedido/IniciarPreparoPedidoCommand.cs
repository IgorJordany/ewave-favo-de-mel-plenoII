using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class IniciarPreparoPedidoCommand : ICommand
    {
        public Guid PedidoId { get; set; }
    }
}