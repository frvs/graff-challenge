using Graff.Api.Entities.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Graff.Api.Entities
{
    public class Person : Entity
    { 
        public Person()
        {
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}
