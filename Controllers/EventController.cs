using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WaveSoftAss.UnitOfWork.Interfaces;

namespace WaveSoftAss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public MyHollyWoodBetContext _database;
        public readonly IEventRepository _eventRepository;

        public EventController(MyHollyWoodBetContext database,
            IEventRepository eventRepository)
        {
            _database = database;
            _eventRepository = eventRepository;
        }

        //GetAllEvents
        [HttpGet(Name ="GetAllEvents")]
        public  IActionResult GetEvents()
        {
            var allEvents = _eventRepository.GetAllEvents();
            return Ok(allEvents);
        }

        //Update Event
        [HttpPut("{Id}")]
        public ActionResult<Event> UpdateEvent(long Id, [FromBody] Event evenT)
        {
            //
            var UpdatedEvent = _eventRepository.UpdateEvent(Id, evenT);
            _database.SaveChanges();
            return Ok(UpdatedEvent);
        }

        //Delete
        [HttpDelete("{Id}")]
        public ActionResult DeleteEvent(long Id)
        {
            //
            _eventRepository.DeleteEvent(Id);
            _database.SaveChanges();
            return Ok("Event Deleted Succesfully");
                
        }

        //CreateEvent
        [HttpPost(Name ="CreateEvent")]
        public ActionResult<Event> AddEvent(Event ev)
        {
            //
            var evenT = _eventRepository.AddEvent(ev);
            _database.SaveChanges();
            return Ok(evenT);
        }
    }
}
