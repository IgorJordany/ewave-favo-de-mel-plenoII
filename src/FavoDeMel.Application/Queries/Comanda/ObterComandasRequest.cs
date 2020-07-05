using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandasRequest : IRequest<ObterComandasResponse>
    {
        [Required]
        public Guid ComandaId { get; set; }
    }
}