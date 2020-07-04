using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class AdicionarPedidoCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public byte Quantidade { get; set; }
    }
}