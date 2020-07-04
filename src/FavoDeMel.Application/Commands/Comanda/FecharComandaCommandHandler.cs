using System;
using System.Linq;
using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Core.Repositories;
using Flunt.Notifications;

namespace FavoDeMel.Application.Commands.Comanda
{
    public class FecharComandaCommandHandler : ICommandHandler<FecharComandaCommand, FecharComandaResponse>
    {
        private readonly IComandaRepository _comandaRepository;

        public FecharComandaCommandHandler(IComandaRepository comandaRepository)
        {
            _comandaRepository = comandaRepository;
        }
        public async Task<FecharComandaResponse> Handler(FecharComandaCommand command)
        {
            var comanda = await _comandaRepository.ConsultarPorId(command.Id);

            if (comanda == null)
            {
                return new FecharComandaResponse(false, "Erro", new Notification(nameof(command.Id), "Essa comanda não existe"));
            }

            comanda.Fechar(DateTime.Now);

            if (comanda.Notifications.Any())
            {
                return new FecharComandaResponse(false, "Erro", comanda.Notifications);
            }
            
            return new FecharComandaResponse(true, "Comanda fechada com sucesso", comanda);
        }
    }
}