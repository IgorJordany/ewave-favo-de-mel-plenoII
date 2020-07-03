using System;
using System.Collections.Generic;
using Favo_de_mel.Core.Enums;
using FavoDeMel.Shared.Entities;

namespace FavoDeMel.Core.Entities
{
    public class Comanda : Entity
    {
        public byte Mesa { get; }
        public ComandaStatus Status { get; }
        public DateTime DataAbertura { get; }
        public DateTime? DataFechamento { get; }
        public ICollection<Pedido> Pedidos { get; } = new HashSet<Pedido>();

        public Comanda(byte mesa, ComandaStatus status, DateTime dataAbertura, DateTime? dataFechamento)
        {
            Mesa = mesa;
            Status = status;
            DataAbertura = dataAbertura;
            DataFechamento = dataFechamento;
        }
    }
}