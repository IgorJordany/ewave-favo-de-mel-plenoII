using System;
using System.Collections.Generic;
using FavoDeMel.Application.Queries.Base;
using FavoDeMel.Core.Enums;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandasAbertasResponse : IResponse
    {
        public IEnumerable<ComandaDto> Comandas { get; set; }

        public class ComandaDto
        {
            public Guid Id { get; set; }
            public ComandaStatus Status { get; set; }
            public DateTime DataAbertura { get; set; }
            public byte Mesa { get; set; }
        }
    }
}