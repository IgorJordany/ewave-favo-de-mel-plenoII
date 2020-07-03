using System;
using System.Linq;
using Favo_de_mel.Core.Enums;
using FavoDeMel.Core.Entities;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace Favo_de_mel.WebApi.Tests.Entities
{
    public class ComandaTests
    {
        private Comanda ComandaAberta(byte mesa)
        {
            const ComandaStatus status = ComandaStatus.Aberta;
            var dataAbertura = DateTime.Now;
            return new Comanda(mesa, status, dataAbertura, null);
        }

        [Fact]
        public void Deve_abrir_comanda_com_sucesso()
        {
            const byte mesa = 1;
            const ComandaStatus status = ComandaStatus.Aberta;
            var dataAbertura = DateTime.Now;
            var comanda = new Comanda(mesa, status, dataAbertura, null);

            using (new AssertionScope())
            {
                comanda.Notifications.Any().Should().BeFalse();
                
                comanda.Mesa.Should().Be(mesa);
                comanda.Status.Should().Be(ComandaStatus.Aberta);
                comanda.DataAbertura.Should().Be(dataAbertura);
            }
        }
        
        [Fact]
        public void Deve_fechar_comanda_com_sucesso()
        {
            const byte mesa = 1;
            var dataFechamento = DateTime.Now;
            
            var comanda = ComandaAberta(mesa);
            
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
            
            var comanda = ComandaAberta(mesa);
            
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