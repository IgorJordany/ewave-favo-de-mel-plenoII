using System.ComponentModel.DataAnnotations;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Item
{
    public class InserirItemCommand : ICommand<InserirItemResponse>
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [StringLength(255)]
        public string Descricao { get; set; }
        [Required]
        public bool Cozinha { get; set; }
        [Required]
        public decimal Valor { get; set; }
    }
}