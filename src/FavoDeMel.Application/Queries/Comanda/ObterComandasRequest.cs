using System;
using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandasRequest : IRequest<ObterComandasResponse>
    {
        public Guid ComandaId { get; set; }
    }
}