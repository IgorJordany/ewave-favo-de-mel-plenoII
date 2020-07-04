using System;
using System.Threading.Tasks;
using FavoDeMel.Core.Entities;
using FavoDeMel.Core.Repositories;
using FavoDeMel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FavoDeMel.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ItemRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public async Task Incluir(Item item)
        {
            await _databaseContext.Itens.AddAsync(item);
        }

        public Task<bool> ExisteItemPorId(Guid id)
        {
            return _databaseContext.Itens.AnyAsync(c => c.Id == id);
        }

        public Task<Item> ConsultarPorId(Guid id)
        {
            return _databaseContext.Itens.SingleOrDefaultAsync(c => c.Id == id);
        }
    }
}