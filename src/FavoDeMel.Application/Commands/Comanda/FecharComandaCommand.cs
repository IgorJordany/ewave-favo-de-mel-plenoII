using System;
using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class FecharComandaCommand : ICommand<FecharComandaResponse>
    {
        [Required]
        public Guid Id { get; set; }
    }
}