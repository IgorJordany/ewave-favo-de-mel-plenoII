using System.Threading.Tasks;
using FavoDeMel.Core.Entities;
using FavoDeMel.Core.Repositories;
using FavoDeMel.Infrastructure.Data;

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
    }
}