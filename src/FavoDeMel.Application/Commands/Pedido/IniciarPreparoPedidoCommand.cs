using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class IniciarPreparoPedidoCommand : ICommand<IniciarPreparoPedidoResponse>
    {
        public Guid PedidoId { get; set; }
    }
}