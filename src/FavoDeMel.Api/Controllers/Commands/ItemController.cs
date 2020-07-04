using System.Threading.Tasks;
using FavoDeMel.Application.Commands.Base;
using FavoDeMel.Application.Commands.Item;
using FavoDeMel.Infrastructure.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace FavoDeMel.Api.Controllers.Commands
{
    [ApiController]
    [Route("commands/item")]
    public class ItemController : ControllerBase
    {
        private readonly InserirItemCommandHandler _inserirItemCommandHandler;
        private readonly IUow _uow;

        public ItemController(
            InserirItemCommandHandler inserirItemCommandHandler,
            IUow uow)
        {
            _inserirItemCommandHandler = inserirItemCommandHandler;
            _uow = uow;
        }
        
        [HttpPost("inserir")]
        public async Task<ICommandResponse> InserirItem([FromBody] InserirItemCommand command)
        {
            var response = await _inserirItemCommandHandler.Handler(command);
            
            _uow.Commit();

            return response;
        }
    }
}