using System;
using System.Linq;
using System.Threading.Tasks;
using Favo_de_mel.Core.Enums;
using Favo_de_mel.Core.Repositories;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;

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

            if (comanda.Notifications.Any())
            {
                return new AbrirComandaResponse(false, "Erro", comanda.Notifications);
            }
            
            await _comandaRepository.IncluirAync(comanda);

            return new AbrirComandaResponse(true, "Comanda aberta com sucesso", null);
        }
    }
}