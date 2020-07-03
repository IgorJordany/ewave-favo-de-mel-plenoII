using System;
using Flunt.Notifications;

namespace Favo_de_mel.Shared.Entities
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
		
        public Guid Id { get; }
    }
}