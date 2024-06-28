namespace Flight.Models
{
    public enum FlightType
    {
        Direct,
        Connecting
    }
    public class Flights
    {
        public int Id { get; set; }
        public FlightType Type { get; set; }
        public int AirlineID { get; set; }
        public string FlightNumber { get; set; }
        public List<Schedule> Schedules { get; set; }
    }
}
