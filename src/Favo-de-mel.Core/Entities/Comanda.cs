using System;
using System.Collections.Generic;
using Favo_de_mel.Core.Enums;

namespace Favo_de_mel.Core.Entities
{
    public class Comanda
    {
        public long Id { get; set; }
        public byte Mesa { get; set; }
        public ComandaStatus Status { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }
        public ICollection<Pedido> Pedidos { get; set; } = new HashSet<Pedido>();
    }
}