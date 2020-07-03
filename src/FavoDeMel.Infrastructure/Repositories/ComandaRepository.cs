using System;
using System.Threading.Tasks;
using Favo_de_mel.Core.Repositories;
using FavoDeMel.Core.Entities;
using FavoDeMel.Infrastructure.Data;

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