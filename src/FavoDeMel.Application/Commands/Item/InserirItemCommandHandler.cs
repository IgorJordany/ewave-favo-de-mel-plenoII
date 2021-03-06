using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Commands.Item
{
    public class InserirItemCommandHandler : ICommandHandler<InserirItemCommand, InserirItemResponse>
    {
        private readonly IItemRepository _itemRepository;

        public InserirItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<InserirItemResponse> Handler(InserirItemCommand command)
        {
            var item = new Core.Entities.Item(
                command.Nome,
                command.Descricao,
                command.Valor,
                command.Cozinha);

            await _itemRepository.Incluir(item);

            return new InserirItemResponse{ItemId = item.Id};
        }
    }
}