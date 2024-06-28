using BenchmarkDotNet.Attributes;
using Flight.Models;
using FlightApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlinesController : ControllerBase
    {
        private readonly FlightContext context;
        public AirlinesController(FlightContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Airline>>> GetAll()
        {
            var list = await context.Airlines.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airline>> GetById(int id)
        {
            var find = await context.Airlines.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            return find;
        }

        [HttpPost]
        public async Task<ActionResult<Airline>> Create([FromBody] Airline airline)
        {
            await context.Airlines.AddAsync(airline);
            await context.SaveChangesAsync();
            return Ok(airline);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Airline>> Update(int id, [FromBody] Airline airline)
        {
            var find = await context.Airlines.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            find.Name = airline.Name;
            context.Update(find);
            await context.SaveChangesAsync();
            return Ok(find);
        }


        [HttpGet("Records")]
        public async Task<ActionResult<IEnumerable<Object>>> GetRecords()
        {
            var query = from ai in context.Airlines
                        join ar in context.Aircrafts
                        on ai.Id equals ar.AirlineID
                        orderby ai.Name
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Airline>> Delete(int id)
        {
            var find = await context.Airlines.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            context.Airlines.Remove(find);
            await context.SaveChangesAsync();
            return Ok();
        }

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Airline>> SoftDelete(int id)
        //{
        //    var find = await context.Airlines.FindAsync(id);
        //    if (find == null)
        //    {
        //        return NotFound();
        //    }
        //    find.IsDeleted = true;
        //    await context.SaveChangesAsync();
        //    return Ok();
        //}

    }
}
