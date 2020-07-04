using System;
using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Pedido
{
    public class ObterPedidoRequest : IRequest<ObterPedidoResponse>
    {
        public Guid PedidoId { get; set; }
    }
}