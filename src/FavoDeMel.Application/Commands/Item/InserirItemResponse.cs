using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Item
{
    public class InserirItemResponse : ICommandResponse
    {
        public InserirItemResponse(bool sucesso, string mensagem, object data)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Data = data;
        }

        public bool Sucesso { get; }
        public string Mensagem { get; }
        public object Data { get; }
    }
}