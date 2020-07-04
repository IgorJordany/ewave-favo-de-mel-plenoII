using System;
using System.Collections.Generic;
using FavoDeMel.Core.Enums;
using FavoDeMel.Shared.Entities;

namespace FavoDeMel.Core.Entities
{
    public class Comanda : Entity
    {
        public byte Mesa { get; }
        public ComandaStatus Status { get; private set; }
        public DateTime DataAbertura { get; } 
        public DateTime? DataFechamento { get; private set; }
        public ICollection<Pedido> Pedidos { get; } = new HashSet<Pedido>();
        public decimal TotalPagar { get; private set; }

        public Comanda(byte mesa)
        {
            Mesa = mesa;
            Status = ComandaStatus.Aberta;
            DataAbertura = DateTime.Now;
            TotalPagar = 0;
        }

        public void Fechar(DateTime dataFechamento)
        {
            if (Status == ComandaStatus.Fechada)
            {
                AddNotification("Status", "Comanda já está fechada");
                return;
            }

            Status = ComandaStatus.Fechada;
            DataFechamento = dataFechamento;

            foreach (var pedido in Pedidos)
            {
                if (pedido.Status != PedidoStatus.Cancelado)
                    TotalPagar += pedido.Valor * pedido.Quantidade;
            }
        }
    }
}