using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Core.Entities;

namespace FavoDeMel.Core.Repositories
{
    public interface IPedidoRepository
    {
        Task Incluir(Pedido pedido);
        Task<Pedido> ConsultarPorId(Guid id);
        Task<List<Pedido>> ListarPedidosCozinha();
    }
}