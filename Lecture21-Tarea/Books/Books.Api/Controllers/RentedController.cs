using Books.Application.Interfaces;
using Books.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentedController : ControllerBase
    {
        private readonly IRepository<Rented> _rentedRepository;

        public RentedController(IRepository<Rented> rentedRepository)
        {
            _rentedRepository = rentedRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rented>>> GetRenteds()
        {
            var renteds = await _rentedRepository.GetAll();
            return Ok(renteds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rented>> GetRented(int id)
        {
            var rented = await _rentedRepository.GetById(id);
            if (rented == null)
            {
                return NotFound();
            }
            return Ok(rented);
        }

        [HttpPost]
        public async Task<ActionResult<Rented>> PostRented(Rented rented)
        {
            await _rentedRepository.Add(rented);
            return CreatedAtAction(nameof(GetRented), new { id = rented.Id }, rented);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRented(int id, Rented rented)
        {
            if (id != rented.Id)
            {
                return BadRequest();
            }

            await _rentedRepository.Update(rented);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRented(int id)
        {
            var appointment = await _rentedRepository.GetById(id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _rentedRepository.Delete(id);
            return NoContent();
        }
    }
}
