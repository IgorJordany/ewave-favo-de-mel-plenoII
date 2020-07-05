using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class AbrirComandaCommand : ICommand<AbrirComandaResponse>
    {
        [Required]
        public byte Mesa { get; set; }
    }
}