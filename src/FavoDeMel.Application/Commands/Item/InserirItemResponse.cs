using System;
using FavoDeMel.Application.Commands.Base;

namespace FavoDeMel.Application.Commands.Item
{
    public class InserirItemResponse : ICommandResponse
    {
        public object Erro { get; set; }
        public Guid ItemId { get; set; }
    }
}