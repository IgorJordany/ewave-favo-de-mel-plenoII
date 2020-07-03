using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class FecharComandaCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}