namespace Flight.Models
{
    public class Aircraft
    {
        public int Id { get; set; }
        public byte Capacity { get; set; }
        public string Model { get; set; }
        public string Name { get; set; }
        public int AirlineID { get; set; }
        //public Airline Airline { get; set; }
    }

   
}
