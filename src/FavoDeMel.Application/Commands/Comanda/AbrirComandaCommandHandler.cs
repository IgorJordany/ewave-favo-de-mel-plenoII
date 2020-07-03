using System;
using System.Threading.Tasks;
using Favo_de_mel.Core.Enums;
using Favo_de_mel.Core.Repositories;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class AbrirComandaCommandHandler : ICommandHandler<AbrirComandaCommand>
    {
        private readonly IComandaRepository _comandaRepository;

        public AbrirComandaCommandHandler(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }
        public async Task<ICommandResponse> Handler(AbrirComandaCommand command)
        {
            var comanda = new Core.Entities.Comanda(command.Mesa, ComandaStatus.Aberta, DateTime.Now, null);
            
            await _comandaRepository.Incluir(comanda);

            return new AbrirComandaResponse(true, "Comanda aberta com sucesso", null);
        }
    }
}