using Graff.Api.Entities.ValueObjects;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Graff.Api.Entities
{
    public class Product : Entity
    {
        public Product()
        {
            Bids = new List<Bid>();
        }

        public Product(string name, decimal initial)
        {
            Name = name;
            InitialValue = initial;
            Bids = new List<Bid>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal InitialValue { get; set; }

        [NotMapped]
        public List<Bid> Bids { get; set; }

        public decimal CurrentValue => GetHighestValue();

        private decimal GetHighestValue()
        {
            if(Bids.Count == 0)
            {
                return InitialValue;
            }

            var values = Bids.Select(x => x.Value);
            
            return values.Max();
        }
    }
}
