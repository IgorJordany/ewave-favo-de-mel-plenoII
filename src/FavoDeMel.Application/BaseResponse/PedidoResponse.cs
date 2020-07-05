using System;
using FavoDeMel.Core.Enums;

namespace FavoDeMel.Application.BaseResponse
{
    public class PedidoResponse
    {
        public Guid ComandaId { get; set; }
        public PedidoStatus Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime? DataPronto { get; set; }
        public DateTime? DataInicioPreparo { get; set; }
        public Guid ItemId { get; set; }
        public byte Quantidade { get; set; }
        public bool Cozinha { get; set; }
        public decimal Valor { get; set; }
    }
}