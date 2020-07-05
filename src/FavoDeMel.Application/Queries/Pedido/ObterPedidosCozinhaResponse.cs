using System.Collections.Generic;
using FavoDeMel.Application.BaseResponse;

namespace FavoDeMel.Application.Queries.Pedido
{
    public class ObterPedidosCozinhaResponse
    {
        public List<PedidoResponse> Pedidos { get; set; }
    }
}