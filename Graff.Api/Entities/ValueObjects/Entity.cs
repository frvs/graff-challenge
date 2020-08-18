using System;
using System.ComponentModel.DataAnnotations;

namespace Graff.Api.Entities.ValueObjects
{
    public class Entity : IEquatable<Entity>
    {
        
        public Entity()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other?.Id;
        }
    }
}
