using Graff.Api.Controllers.Dtos;
using Graff.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Graff.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private AuctionService _auctionService;

        public IActionResult AddBid([FromBody] NewBidDto dto)
        {
            try
            {
                var response = _auctionService.AddNewBid(dto.PersonId, dto.ProductId, dto.Value);
                return Created(response.Id, response);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

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
    }
}
