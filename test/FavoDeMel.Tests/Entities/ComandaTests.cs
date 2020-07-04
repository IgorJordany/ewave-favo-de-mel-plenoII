using System;
using System.Linq;
using FavoDeMel.Core.Entities;
using FavoDeMel.Core.Enums;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Favo_de_mel.WebApi.Tests.Entities
{
    public class ComandaTests
    {
        private Comanda ComandaAbertaGenerator(byte mesa)
        {
            return new Comanda(mesa);
        }

        [Fact]
        public void Deve_abrir_comanda_com_sucesso()
        {
            const byte mesa = 1;
            const ComandaStatus status = ComandaStatus.Aberta;
            var comanda = new Comanda(mesa);

            using (new AssertionScope())
            {
                comanda.Notifications.Any().Should().BeFalse();
                
                comanda.Mesa.Should().Be(mesa);
                comanda.Status.Should().Be(ComandaStatus.Aberta);
            }
        }
        
        [Fact]
        public void Deve_fechar_comanda_com_sucesso()
        {
            const byte mesa = 1;
            var dataFechamento = DateTime.Now;
            
            var comanda = ComandaAbertaGenerator(mesa);
            
            comanda.Fechar(dataFechamento);
            
            using (new AssertionScope())
            {
                comanda.Notifications.Any().Should().BeFalse();
                
                comanda.Mesa.Should().Be(mesa);
                comanda.Status.Should().Be(ComandaStatus.Fechada);
                comanda.DataFechamento.Should().Be(dataFechamento);
            }
        }
        
        [Fact]
        public void Deve_fechar_comanda_apenas_se_estiver_aberta()
        {
            const byte mesa = 1;
            var dataFechamento = DateTime.Now;
            
            var comanda = ComandaAbertaGenerator(mesa);
            
            comanda.Fechar(dataFechamento);
            comanda.Fechar(dataFechamento);
            
            using (new AssertionScope())
            {
                comanda.Notifications.Any().Should().BeTrue();
                comanda.Notifications.First().Property.Should().Be("Status");
                comanda.Notifications.First().Message.Should().Be("Comanda já está fechada");
            }
        }
    }
}