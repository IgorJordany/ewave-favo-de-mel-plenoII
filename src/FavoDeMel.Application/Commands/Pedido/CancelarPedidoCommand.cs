using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class CancelarPedidoCommand : ICommand<CancelarPedidoResponse>
    {
        public Guid PedidoId { get; set; }
    }
}