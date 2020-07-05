using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class AbrirComandaResponse : ICommandResponse
    {
        public object Erro { get; set; }
        public Guid ComandaId { get; set; }
    }
}