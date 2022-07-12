using System.Collections;

namespace WaveSoftAss.UnitOfWork.Interfaces
{
    public interface IEventRepository
    {
        //Create Event
        public Event AddEvent(Event newEvent);
        //GetAllEvents 
        IEnumerable  GetAllEvents();
        //Update Event
        Event UpdateEvent(long Id, Event eVent);
        //Delete Event
        void DeleteEvent(long Id);
        
        
        
    }
}
