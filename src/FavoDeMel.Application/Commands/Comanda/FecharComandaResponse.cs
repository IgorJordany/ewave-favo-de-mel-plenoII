using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class FecharComandaResponse : ICommandResponse
    {
        public object Erro { get; set; }
        public Guid ComandaId { get; set; }
    }
}