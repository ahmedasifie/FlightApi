using Flight.Models;
using FlightApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FlightContext context;

        public UsersController(FlightContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Passengers>>> GetAll()
        {
            var list = await context.Passengers.ToListAsync();
            return Ok(list);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Passengers>> GetById(int id)
        {
            var find = await context.Passengers.FindAsync(id);
            if (find == null)
            {
                NotFound();
            }
            return Ok(find);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Passengers passengers)
        {
            var create = context.AddAsync(passengers);            
            context.SaveChangesAsync();
            return Ok(create.Result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Passengers>> Delete(int id)
        {
            var find = await context.Passengers.FindAsync(id);
            if (find == null)
            {
                NotFound();
            }
            context.Passengers.Update(find);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Passengers>> Update(int id,[FromBody] Passengers passengers)
        {
            var find = await context.Passengers.FindAsync(id);
            if (find == null)
            {
                NotFound();
            }
            find.FirstName = passengers.FirstName;
            find.LastName = passengers.LastName;
            find.Phone = passengers.Phone;
            context.Passengers.Update(find);
            await context.SaveChangesAsync();
            return Ok(passengers);
        }
    }
}
