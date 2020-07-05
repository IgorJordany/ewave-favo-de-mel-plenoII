using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FavoDeMel.Core.Entities;

namespace FavoDeMel.Core.Repositories
{
    public interface IComandaRepository
    {
        Task Incluir(Comanda comanda);
        Task<List<Comanda>> ListarComandasAbertas();
        Task<List<Comanda>> ListarComandas();
        Task<Comanda> ConsultarPorId(Guid id);
        Task<bool> ExisteComandaAbertaParaMesa(byte mesa);
        Task<bool> ExisteComandaAbertaPorId(Guid id);
    }
}


