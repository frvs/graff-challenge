using Graff.Api.Services;
using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        private readonly AuctionService auctionService;

        public Tests(AuctionService auctionService)
        {
            this.auctionService = auctionService;
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Create_Person()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_Create_Product()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_Create_Valid_Bid()
        {
            Assert.Pass();
        }

        [Test]
        public void Test_Create_Invalid_Bid()
        {
            Assert.Pass();
        }
    }
}