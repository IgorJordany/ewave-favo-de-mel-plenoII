using System;
using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandaRequest : IRequest<ObterComandaResponse>
    {
        public Guid ComandaId { get; set; }
    }
}