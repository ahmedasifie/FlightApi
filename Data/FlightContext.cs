using Flight.Models;
using Microsoft.EntityFrameworkCore;

namespace FlightApi.Data
{
    public class FlightContext : DbContext
    {
        public FlightContext(DbContextOptions<FlightContext> options) : base(options)
        {

        }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Flights> Flights { get; set; }
        public DbSet<Passengers> Passengers { get; set; }
        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}
