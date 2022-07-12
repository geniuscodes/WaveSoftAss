using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WaveSoftAss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventDetailController : ControllerBase
    {
        public MyHollyWoodBetContext _database;

        public EventDetailController(MyHollyWoodBetContext database)
        {
            _database = database;
        }

        //GetAllEventDetails
        [HttpGet(Name ="GetAllEventDetails")]
        public ActionResult<IEnumerable<EventDetail>> GetEvds()
        {
            var allEvds = _database.EventDetails.ToList();
            return Ok(allEvds);
        }

    }
}
