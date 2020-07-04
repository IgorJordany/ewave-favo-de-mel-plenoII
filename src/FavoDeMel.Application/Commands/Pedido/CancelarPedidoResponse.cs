using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Pedido
{
    public class CancelarPedidoResponse : ICommandResponse
    {
        public CancelarPedidoResponse(bool sucesso, string mensagem, object data)
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