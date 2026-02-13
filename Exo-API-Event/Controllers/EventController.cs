using Exo_API_Event.Fake;
using Exo_API_Event.Fake.Entities;
using Exo_API_Event.Mappers;
using Exo_API_Event.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo_API_Event.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IContext _context;

        public EventController(IContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType<EventDetails>(200)]
        [ProducesResponseType<string>(500)]
        public IActionResult Get()
        {
            try
            {
                Event data = _context.Event;
                return Ok(data.ToDetails());
            }
            catch (Exception)
            {
                return StatusCode(500,"Le serveur ne répond pas.");
            }
        }

        [HttpPut]
        [ProducesResponseType<EventDetails>(201)]
        [ProducesResponseType<string>(500)]
        public IActionResult Put(EventEdit data)
        {
            try
            {
                _context.Event.Date = new DateTime(data.Date,new TimeOnly());
                _context.Event.StartTime = new DateTime(new DateOnly(),data.StartTime);
                _context.Event.EndTime = new DateTime(new DateOnly(),data.EndTime);
                _context.Event.Title = data.Title;
                _context.Event.Description = data.Description;
                _context.Event.Dresscode = data.Dresscode;
                return CreatedAtAction(nameof(Get), null, _context.Event);
            }
            catch (Exception)
            {
                return StatusCode(500, "Le serveur ne répond pas.");
            }
        }
    }
}
