using Flight.Models;
using FlightApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly FlightContext context;

        public ScheduleController(FlightContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetAll()
        {
            var list = await context.Schedules.ToListAsync();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetById(int id)
        {
            var find = await context.Schedules.FindAsync(id);
            if (find == null)
            {
                NotFound();
            }
            return Ok(find);
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> Create(Schedule schedule)
        {
            var create = await context.AddAsync(schedule);
            await context.SaveChangesAsync();
            return Ok(create);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Schedule>> Delete(int id)
        {
            var find = await context.Schedules.FindAsync(id);
            if (find == null)
            {
                NotFound();
            }
            context.Schedules.Remove(find);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> Update(int id, Schedule schedules)
        {
            var find = await context.Schedules.FindAsync(id);
            if (find == null)
            {
                return NotFound();
            }
            find.Departure_time = schedules.Departure_time;
            find.Arrival_time = schedules.Arrival_time;
            find.OriginId = schedules.OriginId;
            find.DestinationId = schedules.DestinationId;
            context.Update(find);
            await context.SaveChangesAsync();
            return Ok(find);
        }
    }
}
