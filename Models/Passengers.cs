using Microsoft.AspNetCore.Identity;
namespace Flight.Models
{
    public class Passengers 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Booking> Booking { get; set; } = new List<Booking>();
    }
}
