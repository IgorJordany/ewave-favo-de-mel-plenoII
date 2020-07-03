namespace FavoDeMel.Application.Commands.Base
{
    public interface ICommandResponse
    {
        bool Sucesso { get; }
        string Mensagem { get; }
        object Data { get; }
    }
}