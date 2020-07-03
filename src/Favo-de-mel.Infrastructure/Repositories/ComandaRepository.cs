using System;
using System.Threading.Tasks;
using Favo_de_mel.Core.Entities;
using Favo_de_mel.Core.Repositories;

namespace Favo_de_mel.Infrastructure.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        public Task Salvar(Comanda comanda)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Existe(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Comanda> ConsultarPorId(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}