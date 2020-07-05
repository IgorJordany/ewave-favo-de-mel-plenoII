using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class CancelarPedidoCommand : ICommand<CancelarPedidoResponse>
    {
        [Required]
        public Guid PedidoId { get; set; }
    }
}