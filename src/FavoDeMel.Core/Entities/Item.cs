using System.Collections.Generic;
using FavoDeMel.Shared.Entities;

namespace FavoDeMel.Core.Entities
{
    public class Item : Entity
    {
        public string Nome { get; }
        public string Descricao { get; }
        public bool Cozinha { get; }
        public decimal Valor { get; }
        public ICollection<Pedido> Pedidos { get; } = new HashSet<Pedido>();

        public Item(string nome, string descricao, decimal valor, bool cozinha )
        {
            Cozinha = cozinha;
            Valor = valor;
            Nome = nome;
            Descricao = descricao;
        }
    }
}