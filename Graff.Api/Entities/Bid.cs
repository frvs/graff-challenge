using Graff.Api.Entities.ValueObjects;

namespace Graff.Api.Entities
{
    public class Bid : Entity
    {
        public Bid()
        {

        }

        public Bid(string personId, string productId, decimal value)
        {
            OwnerId = personId;
            Value = value;
            ProductId = productId;
        }
        public string ProductId { get; set; }
        public decimal Value { get; set; }
        public string OwnerId { get; set; }
    }
}
