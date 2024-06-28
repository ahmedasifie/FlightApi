using Flight.Models;
using FlightApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightContext context;
        public FlightController(FlightContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Flights>>> GetAll()
        {
            var list = await context.Flights.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Flights>> GetById(int id)
        {
            var find = await context.Flights.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            return find;
        }

        [HttpPost]
        public async Task<ActionResult<Flights>> Create([FromBody] Flights flights)
        {
            await context.Flights.AddAsync(flights);
            await context.SaveChangesAsync();
            return Ok(flights);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Flights>> Update(int id, [FromBody] Flights flights)
        {
            var find = await context.Flights.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            find.FlightNumber = flights.FlightNumber;
            find.Type = flights.Type;
            find.AirlineID = flights.AirlineID;
            context.Update(find);
            await context.SaveChangesAsync();
            return Ok(find);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Flights>> Delete(int id)
        {
            var find = await context.Flights.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            context.Flights.Remove(find);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
