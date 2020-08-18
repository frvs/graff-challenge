using Graff.Api.Entities;
using Graff.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Graff.Api.Controllers
{
    [Route("api/v1/auction")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private AuctionService _auctionService;
        public AuctionController([FromServices] AuctionService auctionService)
        {
            _auctionService = auctionService;
        }

        [HttpPost("bid")]
        public IActionResult AddBid([FromBody] Bid dto)
        {
            try
            {
                var response = _auctionService.AddNewBid(dto);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("person")]
        public IActionResult AddNewPerson([FromBody] Person dto)
        {
            try
            {
                var response = _auctionService.AddNewPerson(dto);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("product")]
        public IActionResult AddNewProduct([FromBody] Product dto)
        {
            try
            {
                var response = _auctionService.AddNewProduct(dto);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }


        [HttpGet("bids")]
        public IActionResult GetBidsByPerson([FromQuery] string personId)
        {
            try
            {
                var response = _auctionService.GetBidsByPersonId(personId);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("products")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var response = _auctionService.GetAllProducts();
                return Ok(response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
