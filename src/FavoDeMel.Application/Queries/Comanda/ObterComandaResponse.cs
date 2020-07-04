using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Comanda
{
    public class ObterComandaResponse : IResponse
    {
        public ObterComandaResponse(bool sucesso, string mensagem, object data)
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