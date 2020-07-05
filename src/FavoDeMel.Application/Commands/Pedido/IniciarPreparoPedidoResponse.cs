using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class IniciarPreparoPedidoResponse : ICommandResponse
    {
        public Guid PedidoId { get; set; }
        public object Erro { get; set; }
    }
}