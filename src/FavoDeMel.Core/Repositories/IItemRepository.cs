using System.Threading.Tasks;
using FavoDeMel.Core.Entities;

namespace FavoDeMel.Core.Repositories
{
    public interface IItemRepository
    {
        Task Incluir(Item item);
    }
}