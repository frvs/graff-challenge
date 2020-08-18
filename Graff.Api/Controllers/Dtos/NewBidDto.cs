namespace Graff.Api.Controllers.Dtos
{
    public class NewBidDto
    {
        public string PersonId { get; set; }
        public string ProductId { get; set; }
        public decimal Value { get; set; }
    }
}
