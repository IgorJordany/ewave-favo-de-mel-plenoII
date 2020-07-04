using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class FecharComandaCommand : ICommand<FecharComandaResponse>
    {
        public Guid Id { get; set; }
    }
}