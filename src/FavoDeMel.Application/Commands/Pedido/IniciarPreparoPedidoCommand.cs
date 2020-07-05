using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class IniciarPreparoPedidoCommand : ICommand<IniciarPreparoPedidoResponse>
    {
        [Required]
        public Guid PedidoId { get; set; }
    }
}