
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Interfaces;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _service;

        public DogsController(IDogService service)
        {
            _service = service;
        }

        // GET: api/Dogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dog>>> GetDogs()
        {
            var dogs = await _service.GetDogsAsync();
            return Ok(dogs);
        }

        // GET: api/Dogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dog>> GetDog(int id)
        {
            var dog = await _service.GetDogAsync(id);

            if (dog == null)
            {
                return NotFound();
            }

            return Ok(dog);
        }

        // POST: api/Dogs
        [HttpPost]
        public async Task<ActionResult<Dog>> PostDog(Dog dog)
        {
            await _service.AddDogAsync(dog);
            return CreatedAtAction(nameof(GetDog), new { id = dog.Id }, dog);
        }

        // PUT: api/Dogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDog(int id, Dog dog)
        {
            if (id != dog.Id)
            {
                return BadRequest();
            }

            var result = await _service.UpdateDogAsync(dog);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Dogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDog(int id)
        {
            var result = await _service.DeleteDogAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
