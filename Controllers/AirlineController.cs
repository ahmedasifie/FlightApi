using Microsoft.AspNetCore.Mvc;

namespace FlightApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineController : Controller
    {
        //private readonly List<Airline> Airlines = new List<Airline>
        //{
        //    new Airline { Id = 1, Name = "Emirates"},
        //    new Airline { Id = 2, Name = "Delta Airlines"},
        //    new Airline { Id = 3, Name = "United Airlines"},
        //    new Airline { Id = 4, Name = "Lufthansa"},
        //    new Airline { Id = 5, Name = "Qatar Airways"},
        //    new Airline { Id = 6, Name = "American Airlines"},
        //};
        //private readonly ILogger<AirlineController> _logger;

        //public AirlineController(ILogger<AirlineController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public List<Airline> GetAll()
        //{
        //    return Airlines;
        //}

        //[HttpPost]
        //public List<Airline> Create([FromBody] Airline airline)
        //{
        //    Airlines.Add(airline);
        //    return Airlines;
        //}

        //[HttpGet("{id}")]
        //public Airline GetById(int Id)
        //{
        //    return Airlines.ElementAt(Id);
        //}

        //[HttpDelete("{id}")]
        //public List<Airline> Delete(int Id)
        //{
        //    var find = Airlines.ElementAt(Id);
        //    Airlines.Remove(find);
        //    return Airlines;
        //}

        //[HttpPut("{id}")]
        //public List<Airline> Update(Guid Id, [FromBody] Airline airline)
        //{
        //    var find = Airlines.ElementAt(Id);
        //    find.Name = airline.Name;
        //    return Airlines;
        //}

        //kc
        //[HttpDelete]
        //public async void Delete (int id)
        //{
        //    var find = Airlines
        //}

        
    }
}
