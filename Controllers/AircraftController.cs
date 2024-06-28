using Flight.Models;
using FlightApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly FlightContext context;
        public AircraftController(FlightContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Aircraft>>> GetAll()
        {
            var list = await context.Aircrafts.ToListAsync();
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<List<Aircraft>>> Create([FromBody] Aircraft aircrafts)
        {
            var create = await context.Aircrafts.AddAsync(aircrafts);
            await context.SaveChangesAsync();
            return Ok(create);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aircraft>> GetById(int id)
        {
            var find = await context.Aircrafts.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            return find;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Aircraft>> Delete(int id)
        {
            var find = await context.Aircrafts.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            context.Aircrafts.Remove(find);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("Join")]
        public async Task<ActionResult<IEnumerable<Object>>> GetRecords()
        {
            var query = from ar in context.Aircrafts
                        join ai in context.Airlines
                        on ar.AirlineID equals ai.Id
                        select new
                        {
                            AirlineName = ai.Name,
                            AircraftName = ar.Name,
                            Model = ar.Model,
                            Capacity = ar.Capacity
                        };
            var recrds = await query.ToListAsync();
            return Ok(recrds);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Airline>> Update(int id, [FromBody] Aircraft aircraft)
        {
            var find = await context.Aircrafts.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            find.Name = aircraft.Name;
            find.Capacity = aircraft.Capacity;
            find.Model = aircraft.Model;
            context.Update(find);
            await context.SaveChangesAsync();
            return Ok(find);
        }
        //[HttpPatch("{id}")]
        //public async Task<ActionResult<Aircrafts>> 
    }
}
