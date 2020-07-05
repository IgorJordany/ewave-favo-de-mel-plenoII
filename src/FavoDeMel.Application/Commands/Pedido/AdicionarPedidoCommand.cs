using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class AdicionarPedidoCommand : ICommand<AdicionarPedidoResponse>
    {
        [Required]
        public Guid ComandaId { get; set; }
        [Required]
        public Guid ItemId { get; set; }
        [Required]
        [Range(1, 255)]
        public byte Quantidade { get; set; }
    }
}