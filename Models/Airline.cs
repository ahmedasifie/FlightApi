namespace Flight.Models
{
    public class Airline 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Flights> Flight { get; set; } = new List<Flights>();
        public List<Aircraft> Aircraft { get; set; } = new List<Aircraft>();
    }
}
