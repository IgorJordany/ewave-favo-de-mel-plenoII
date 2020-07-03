using System;
using Favo_de_mel.Core.Enums;
using Favo_de_mel.Shared.Entities;

namespace Favo_de_mel.Core.Entities
{
    public class Pedido : Entity
    {
        public Guid ComandaId { get; }
        public PedidoStatus Status { get; }
        public DateTime DataCriacao { get; }
        public DateTime? DataCancelamento { get; }
        public DateTime? DataPronto { get; }

        public Pedido(PedidoStatus status, DateTime dataCriacao, DateTime? dataCancelamento, DateTime? dataPronto, Guid comandaId)
        {
            Status = status;
            DataCriacao = dataCriacao;
            DataCancelamento = dataCancelamento;
            DataPronto = dataPronto;
            ComandaId = comandaId;
        }
    }
}