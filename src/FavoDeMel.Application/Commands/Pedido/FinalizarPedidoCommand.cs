using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class FinalizarPedidoCommand : ICommand<FinalizarPedidoResponse>
    {
        public Guid PedidoId { get; set; }
    }
}