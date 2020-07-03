using System;
using System.Collections.Generic;
using Favo_de_mel.Core.Enums;
using FavoDeMel.Shared.Entities;
using Flunt.Notifications;

namespace FavoDeMel.Core.Entities
{
    public class Comanda : Entity
    {
        public byte Mesa { get; }
        public ComandaStatus Status { get; private set; }
        public DateTime DataAbertura { get; } 
        public DateTime? DataFechamento { get; private set; }
        public ICollection<Pedido> Pedidos { get; } = new HashSet<Pedido>();

        public Comanda(byte mesa, ComandaStatus status, DateTime dataAbertura, DateTime? dataFechamento)
        {
            Mesa = mesa;
            Status = status;
            DataAbertura = dataAbertura;
            DataFechamento = dataFechamento;
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
        }
    }
}