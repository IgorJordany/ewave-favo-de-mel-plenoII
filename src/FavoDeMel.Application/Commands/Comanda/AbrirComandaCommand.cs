using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class AbrirComandaCommand : ICommand
    {
        public byte Mesa { get; set; }
    }
}