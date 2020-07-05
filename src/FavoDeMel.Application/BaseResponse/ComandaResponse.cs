using System;
using System.Collections.Generic;
using FavoDeMel.Core.Enums;

namespace FavoDeMel.Application.BaseResponse
{
    public class ComandaResponse
    {
        public byte Mesa { get; set; }
        public ComandaStatus Status { get; set; }
        public DateTime DataAbertura { get; set; } 
        public DateTime? DataFechamento { get;  set; }
        public ICollection<PedidoResponse> Pedidos { get; set; }
        public decimal TotalPagar { get; set; }
    }
}