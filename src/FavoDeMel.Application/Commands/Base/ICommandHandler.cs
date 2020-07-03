using System.Threading.Tasks;

namespace FavoDeMel.Application.Commands.Base
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task<ICommandResponse> Handler(T command);
    }
}