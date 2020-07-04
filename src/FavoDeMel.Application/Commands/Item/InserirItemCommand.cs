using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Item
{
    public class InserirItemCommand : ICommand
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool Cozinha { get; set; }
        public decimal Valor { get; set; }
    }
}