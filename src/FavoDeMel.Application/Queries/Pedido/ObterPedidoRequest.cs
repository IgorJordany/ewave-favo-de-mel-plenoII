using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Pedido
{
    public class ObterPedidoRequest : IRequest<ObterPedidoResponse>
    {
        [Required]
        public Guid PedidoId { get; set; }
    }
}