using System;
using System.Threading.Tasks;
using FavoDeMel.Core.Entities;

namespace Favo_de_mel.Core.Repositories
{
    public interface IComandaRepository
    {
        Task Salvar(Comanda comanda);
        Task<bool> Deletar(Guid id);
        Task<bool> Existe(Guid id);
        Task<Comanda> ConsultarPorId(Guid id);
    }
}


