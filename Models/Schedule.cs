namespace Flight.Models
{
    public class Schedule 
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public DateTime Departure_time { get; set; }
        public DateTime Arrival_time { get; set; }
        public int OriginId { get; set; }
        public int DestinationId { get; set; }
    }
}
