namespace FavoDeMel.Application.Queries.Base
{
    public interface IResponse
    {
        bool Sucesso { get; }
        string Mensagem { get; }
        object Data { get; }
    }
}