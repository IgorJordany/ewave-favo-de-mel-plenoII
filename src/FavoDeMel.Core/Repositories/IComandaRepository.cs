using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Core.Entities;

namespace FavoDeMel.Core.Repositories
{
    public interface IComandaRepository
    {
        Task IncluirAync(Comanda comanda);
        Task<List<Comanda>> ListarComandasAsync();
        Task<bool> Deletar(Guid id);
        Task<bool> Existe(Guid id);
        Task<Comanda> ConsultarPorId(Guid id);
    }
}


