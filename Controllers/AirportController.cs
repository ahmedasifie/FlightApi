using Flight.Models;
using FlightApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly FlightContext context;
        public AirportController(FlightContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Airport>>> GetAll()
        {
            var list = await context.Airports.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetById(int id)
        {
            var find = await context.Airports.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            return find;
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> Create(Airport airport)
        {
            await context.Airports.AddAsync(airport);
            await context.SaveChangesAsync();
            return Ok(airport);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Airport>> Update(int id, Airport airport)
        {
            var find = await context.Airports.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            find.Name = airport.Name;
            find.City = airport.City;
            find.Country = airport.Country;
            context.Update(find);
            await context.SaveChangesAsync();
            return Ok(find);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Airport>> Delete(int id)
        {
            var find = await context.Airports.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            context.Airports.Remove(find);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
