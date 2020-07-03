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
    public class ComandaRepository : IComandaRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ComandaRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task Incluir(Comanda comanda)
        {
            await _databaseContext.Comandas.AddAsync(comanda);
        }

        public Task<List<Comanda>> ListarComandasAbertas()
        {
            var comandas = _databaseContext.Comandas.Where(c => c.Status == ComandaStatus.Aberta);
            return Task.FromResult(comandas.ToList());
        }

        public Task<Comanda> ConsultarPorId(Guid id)
        {
            return _databaseContext.Comandas.SingleOrDefaultAsync(c => c.Id == id);
        }
        
        public Task<bool> ExisteComandaAbertaParaMesa(byte mesa)
        {
            return _databaseContext.Comandas.AnyAsync(c => c.Mesa == mesa && c.Status == ComandaStatus.Aberta);
        }
    }
}