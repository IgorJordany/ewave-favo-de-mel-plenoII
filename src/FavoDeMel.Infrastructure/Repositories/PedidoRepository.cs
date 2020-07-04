using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Core.Entities;
using FavoDeMel.Core.Enums;
using FavoDeMel.Core.Repositories;
using FavoDeMel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FavoDeMel.Infrastructure.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DatabaseContext _databaseContext;

        public PedidoRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task Incluir(Pedido pedido)
        {
            await _databaseContext.Pedidos.AddAsync(pedido);
        }

        public Task<Pedido> ConsultarPorId(Guid id)
        {
            return _databaseContext.Pedidos.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Pedido>> ListarPedidosCozinha()
        {
            var pedidos = _databaseContext.Pedidos
                .Where(p => p.Cozinha && p.Status != PedidoStatus.Pronto)
                .OrderByDescending(p => p.DataCriacao);
            
            return Task.FromResult(pedidos.ToList());
        }
    }
}