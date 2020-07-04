using System;
using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Enums;
using FavoDeMel.Core.Repositories;
using Flunt.Notifications;

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
            if (await _comandaRepository.ExisteComandaAbertaParaMesa(command.Mesa))
            {
                return new AbrirComandaResponse(false, "Erro", new Notification(nameof(command.Mesa), "Já existe comanda aberta para essa mesa"));
            }
            
            var comanda = new Core.Entities.Comanda(command.Mesa);

            if (comanda.Notifications.Any())
            {
                return new AbrirComandaResponse(false, "Erro", comanda.Notifications);
            }
            
            await _comandaRepository.Incluir(comanda);

            return new AbrirComandaResponse(true, "Comanda aberta com sucesso", comanda);
        }
    }
}