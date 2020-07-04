using System;
using FavoDeMel.Core.Enums;
using FavoDeMel.Shared.Entities;

namespace FavoDeMel.Core.Entities
{
    public class Pedido : Entity
    {
        public Guid ComandaId { get; }
        public PedidoStatus Status { get; private set; }
        public DateTime DataCriacao { get; }
        public DateTime? DataCancelamento { get; private set; }
        public DateTime? DataPronto { get; private set; }
        public DateTime? DataInicioPreparo { get; private set; }
        public Guid ItemId { get; }
        public byte Quantidade { get; }
        public bool Cozinha { get; }
        public decimal Valor { get; }

        public Pedido(Guid comandaId, Guid itemId, byte quantidade, bool cozinha, decimal valor)
        {
            Status = PedidoStatus.AguardandoPreparo;
            DataCriacao = DateTime.Now;
            ComandaId = comandaId;
            ItemId = itemId;
            Quantidade = quantidade;
            Cozinha = cozinha;
            Valor = valor;
        }
        
        public void Cancelar()
        {
            if (Status == PedidoStatus.Pronto)
            {
                AddNotification(nameof(Status), "Pedido não pode ser cancelado");
                return;
            }
            Status = PedidoStatus.Cancelado;
            DataCancelamento = DateTime.Now;
        }
        
        public void Finalizar()
        {
            if (!(Cozinha && Status == PedidoStatus.EmPreparo
                || !Cozinha && Status == PedidoStatus.AguardandoPreparo))
            {
                AddNotification(nameof(Status), "Pedido não pode ser finalizado");
                return;
            }
            
            Status = PedidoStatus.Pronto;
            DataPronto = DateTime.Now;
            
            // if (Cozinha && Status == PedidoStatus.EmPreparo)
            // {
            //     //finalizar
            // }
            // if (!Cozinha && Status == PedidoStatus.AguardandoPreparo)
            // {
            //     //finalizar
            // }
        }
        
        public void IniciarPreparo()
        {
            if (!Cozinha || Status != PedidoStatus.AguardandoPreparo)
            {
                AddNotification(nameof(Status), "Preparo do pedido não pode ser inicado");
                return;
            }
            Status = PedidoStatus.EmPreparo;
            DataInicioPreparo = DateTime.Now;
        }
    }
}