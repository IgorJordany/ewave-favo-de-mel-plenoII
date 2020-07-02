using System;
using Favo_de_mel.Core.Enums;

namespace Favo_de_mel.Core.Entities
{
    public class Pedido
    {
        public long Id { get; set; }
        public PedidoStatus Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataCancelamento { get; set; }
        public DateTime DataPronto { get; set; }
    }
}