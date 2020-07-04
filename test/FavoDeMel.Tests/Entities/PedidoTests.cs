using System;
using System.Linq;
using FavoDeMel.Core.Entities;
using FavoDeMel.Core.Enums;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Favo_de_mel.WebApi.Tests.Entities
{
    public class PedidoTests
    {
        private Pedido PedidoCozinhaAdicionadoGenerator(bool cozinha)
        {
            const byte quantidade = 1;
            const decimal valor = (decimal) 14.55;
            var comandaId = new Guid();
            var itemId = new Guid();

            return new Pedido(
                comandaId,
                itemId,
                quantidade,
                cozinha,
                valor);
        }
        
        [Fact]
        public void Deve_adicionar_pedido_com_sucesso()
        { 
            const byte quantidade = 1;
            const decimal valor = (decimal) 14.55;
            const bool cozinha = true;
            var comandaId = new Guid();
            var itemId = new Guid();

            var pedido = new Pedido(
                comandaId,
                itemId,
                quantidade,
                cozinha,
                valor);
            
            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeFalse();

                pedido.Quantidade.Should().Be(quantidade);
                pedido.Status.Should().Be(PedidoStatus.AguardandoPreparo);
                pedido.ComandaId.Should().Be(comandaId);
                pedido.ItemId.Should().Be(itemId);
            }
        }

        [Fact]
        public void Deve_inicar_preparo_pedido_com_sucesso_se_for_item_cozinha()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(true);
            
            pedido.IniciarPreparo();

            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeFalse();
                
                pedido.Status.Should().Be(PedidoStatus.EmPreparo);
            }
        }
        
        [Fact]
        public void Nao_deve_inicar_preparo_pedido_se_pedido_nao_estiver_aguardando_preparo()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(true);
            
            pedido.IniciarPreparo();
            pedido.IniciarPreparo();

            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeTrue();
                pedido.Notifications.First().Property.Should().Be("Status");
                pedido.Notifications.First().Message.Should().Be("Preparo do pedido não pode ser inicado");
            }
        }
        
        [Fact]
        public void Nao_deve_inicar_preparo_pedido_se_pedido_nao_for_da_cozinha()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(false);
            
            pedido.IniciarPreparo();

            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeTrue();
                pedido.Notifications.First().Property.Should().Be("Status");
                pedido.Notifications.First().Message.Should().Be("Preparo do pedido não pode ser inicado");
            }
        }
        
        [Fact]
        public void Nao_deve_cancelar_pedido_pronto()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(false);
            
            pedido.Finalizar();

            pedido.Cancelar();

            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeTrue();
                pedido.Notifications.First().Property.Should().Be("Status");
                pedido.Notifications.First().Message.Should().Be("Pedido não pode ser cancelado");
            }
        }
        
        [Fact]
        public void Deve_finalizar_pedido_cozinha()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(true);
            
            pedido.IniciarPreparo();
            
            pedido.Finalizar();
            
            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeFalse();

                pedido.Status.Should().Be(PedidoStatus.Pronto);
            }
        }
        
        [Fact]
        public void Nao_deve_finalizar_pedido_cozinha_sem_preparar()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(true);
            
            pedido.Finalizar();
            
            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeTrue();
                
                pedido.Notifications.First().Property.Should().Be("Status");
                pedido.Notifications.First().Message.Should().Be("Pedido não pode ser finalizado");
            }
        }
        
        [Fact]
        public void Deve_finalizar_pedido_que_nao_eh_cozinha()
        {
            var pedido = PedidoCozinhaAdicionadoGenerator(false);
            
            pedido.Finalizar();
            
            using (new AssertionScope())
            {
                pedido.Notifications.Any().Should().BeFalse();

                pedido.Status.Should().Be(PedidoStatus.Pronto);
            }
        }
    }
}