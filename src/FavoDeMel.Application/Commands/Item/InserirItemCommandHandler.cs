using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;

namespace FavoDeMel.Application.Commands.Item
{
    public class InserirItemCommandHandler : ICommandHandler<InserirItemCommand>
    {
        private readonly IItemRepository _itemRepository;

        public InserirItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ICommandResponse> Handler(InserirItemCommand command)
        {
            var item = new Core.Entities.Item(
                command.Nome,
                command.Descricao,
                command.Valor,
                command.Cozinha);

            await _itemRepository.Incluir(item);

            return new InserirItemResponse(true, "Item inserido com sucesso", item);
        }
    }
}