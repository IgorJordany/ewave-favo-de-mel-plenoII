using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class AdicionarPedidoCommand : ICommand<AdicionarPedidoResponse>
    {
        public Guid ComandaId { get; set; }
        public Guid ItemId { get; set; }
        [Range(1, 255)]
        public byte Quantidade { get; set; }
    }
}