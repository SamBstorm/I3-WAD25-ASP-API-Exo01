using Exo_API_Event.Fake;
using Exo_API_Event.Fake.Entities;
using Exo_API_Event.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Exo_API_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : ControllerBase
    {
        private readonly IContext _context;

        public GuestController(IContext context)
        {
            _context = context;
        }

        // GET: api/<GuestController>
        [HttpGet]
        [ProducesResponseType<IEnumerable<Guest>>(200)]
        [ProducesResponseType<string>(500)]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Guests);
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur n'a pas pu répondre.");
            }
        }

        // GET api/<GuestController>/5
        [HttpGet("{id}")]
        [ProducesResponseType<Guest>(200)]
        [ProducesResponseType<int>(404)]
        [ProducesResponseType<string>(500)]
        public IActionResult Get(int id)
        {
            try
            {
                Guest? data = _context.Guests.SingleOrDefault(g => g.Id == id);
                if (data is null) return NotFound(id);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur n'a pas pu répondre.");
            }
        }

        // Demo [FromQuery]

        // GET api/<GestController>?firstname=&lastname=
        [HttpGet("search")]
        [ProducesResponseType<IEnumerable<Guest>>(200)]
        [ProducesResponseType<string>(500)]
        public IActionResult Search([FromQuery]string? firstname, [FromQuery] string? lastname)
        {
            try
            {
                IEnumerable<Guest> data = _context.Guests
                    .Where(g => (firstname is null)? true : g.FirstName == firstname)
                    .Where(g => (lastname is null)? true : g.LastName == lastname);
                return Ok(data);
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur n'a pas pu répondre.");
            }
        }

        // POST api/<GuestController>
        [HttpPost]
        [ProducesResponseType<Guest>(201)]
        [ProducesResponseType<string>(500)]
        public IActionResult Post(GuestCreate data)
        {
            try
            {
                int maxId = _context.Guests.Max(g => g.Id);
                Guest entry = new Guest()
                {
                    Id = maxId + 1,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                    IsPresent = false
                };
                List<Guest> guests = _context.Guests.ToList();
                guests.Add(entry);
                _context.Guests = guests;
                return CreatedAtAction(nameof(Get), new { id = entry.Id }, entry);
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur n'a pas répondu.");
            }
        }

        // PUT api/<GuestController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType<int>(404)]
        [ProducesResponseType<string>(500)]
        public IActionResult Put(int id)
        {
            try
            {
                Guest? data = _context.Guests.SingleOrDefault(g => g.Id == id);
                if (data is null) return NotFound(id);
                data.IsPresent = true;
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur n'a pas répondu.");
            }
        }

        // DELETE api/<GuestController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType<int>(404)]
        [ProducesResponseType<string>(500)]
        public IActionResult Delete(int id)
        {
            try
            {
                Guest? data = _context.Guests.SingleOrDefault(g => g.Id == id);
                if (data is null) return NotFound(id);
                List<Guest> guests = _context.Guests.ToList();
                guests.Remove(data);
                _context.Guests = guests;
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur n'a pas répondu.");
            }
        }
    }
}
