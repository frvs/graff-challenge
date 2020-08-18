using System;

namespace Graff.Api.Entities.ValueObjects
{
    public abstract class Entity : IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; }

        public bool Equals(Entity other)
        {
            return Id == other?.Id;
        }
    }
}
