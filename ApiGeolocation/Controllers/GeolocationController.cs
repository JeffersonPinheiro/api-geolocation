using ApiGeolocation.Entities;
using ApiGeolocation.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGeolocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IAddressRepository _repository;

        public GeolocationController(IAddressRepository repository) 
        {
            _repository = repository;   
        }

        [HttpGet(Name = "GetAddresses")]
        [ProducesResponseType(typeof(IEnumerable<Address>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            var address = await _repository.GetAddresses();
            return Ok(address);
        }

        [HttpGet("{id}", Name = "GetAddress")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        public async Task<ActionResult<Address>> GetAddress(string id)
        {
            var address = await _repository.GetAddress(id);
            if (address is null)
            {
                return NotFound();
            }
            return Ok(address); 
        }

        [HttpPost]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Address> SendAddress([FromBody] List<Address> address)
        {
            if(address is null)
            {
                return BadRequest("Invalid Data");
            }
            foreach (var item in address)
            {
                _repository.CreateAddress(item);
                CreatedAtRoute("GetAddress", new { id = item.Id }, item);

                if (address.Count == 2)
                {
                    _repository.DistanceBetween(address);
                }
            }

            return CreatedAtRoute("GetAddresses", new { address }, address);
            //return Ok(address);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAddress([FromBody] Address address)
        {
            if (address is null)
            {
                return BadRequest("Invalid Address");
            }
            return Ok(await _repository.UpdateAddress(address));
        }

    }
}
