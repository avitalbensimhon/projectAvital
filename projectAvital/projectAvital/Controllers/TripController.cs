using Microsoft.AspNetCore.Mvc;
using Project.core.model;
using Project.core.Servies;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projectAvital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {

       private readonly ITripServies _tripServies;
        // GET: api/<TripController>
        public TripController(ITripServies tripServies)
        {
            _tripServies = tripServies;
        }
        [HttpGet]
        public IEnumerable<Trip> Get()
        {
            return _tripServies.GetTrip();
        }

        // GET api/<TripController>/5
        [HttpGet("{id}")]
        public ActionResult Get(string code)
        {
          Trip trip= _tripServies.GetTrip(code);
          if (trip == null)
            {
                return NotFound();
            }
            return Ok(trip);
        }

        // POST api/<TripController>
        [HttpPost]
        public Trip Post([FromBody] Trip newTrip)
        {
           return _tripServies.AddTrip(newTrip);
        }

        // PUT api/<TripController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Trip newTrip)
        {
             _tripServies.UpdateTrip(id, newTrip);
        }

        // DELETE api/<TripController>/5
        [HttpDelete("{id}")]
        public  ActionResult Delete(string id)
        {
            if (_tripServies.DeleteTrip(id))
                return Ok(id);
            return NotFound();
        }
    }
}
