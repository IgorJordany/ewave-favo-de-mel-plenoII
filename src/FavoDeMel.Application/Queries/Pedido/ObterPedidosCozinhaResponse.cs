using FavoDeMel.Application.Queries.Base;

namespace FavoDeMel.Application.Queries.Pedido
{
    public class ObterPedidosCozinhaResponse : IResponse
    {
        public ObterPedidosCozinhaResponse(bool sucesso, string mensagem, object data)
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