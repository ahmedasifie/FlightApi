namespace Flight.Models
{
    public class Airport 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
