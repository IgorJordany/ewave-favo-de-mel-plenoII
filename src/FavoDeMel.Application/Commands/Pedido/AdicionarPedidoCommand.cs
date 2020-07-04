using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class AdicionarPedidoCommand : ICommand
    {
        public Guid ComandaId { get; set; }
        public Guid ItemId { get; set; }
        public byte Quantidade { get; set; }
    }
}