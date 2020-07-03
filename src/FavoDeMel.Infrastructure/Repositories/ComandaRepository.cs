using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Favo_de_mel.Core.Enums;
using Favo_de_mel.Core.Repositories;
using FavoDeMel.Core.Entities;
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
        public async Task IncluirAync(Comanda comanda)
        {
            await _databaseContext.Comandas.AddAsync(comanda);
        }

        public Task<List<Comanda>> ListarComandasAsync()
        {
            var comandas = _databaseContext.Comandas.Where(c => c.Status == ComandaStatus.Aberta);
            return Task.FromResult(comandas.ToList());
        }

        public Task<bool> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Existe(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Comanda> ConsultarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}