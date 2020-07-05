using System.Collections.Generic;
using FavoDeMel.Application.BaseResponse;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandasResponse
    {
        public List<ComandaResponse> Comandas { get; set; }
    }
}