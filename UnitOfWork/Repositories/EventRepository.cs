using System.Collections;
using WaveSoftAss.UnitOfWork.Interfaces;

namespace WaveSoftAss.UnitOfWork.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly MyHollyWoodBetContext _database;

        public EventRepository(MyHollyWoodBetContext database)
        {
            _database = database;
        }

        public Event AddEvent(Event newEvent)
        {
            //
            var ev = new Event
            {
                EventName = newEvent.EventName,
                EventNumber = newEvent.EventNumber,
                EventDateTime = newEvent.EventDateTime,
                EventEndDateTime = newEvent.EventEndDateTime,
                FkTournamentId = newEvent.FkTournamentId
            };

            _database.Events.Update(ev);
            _database.Events.Add(ev);
            _database.SaveChanges();

            var createdEvent = from e in _database.Events.ToList()
                               where e.EventName == newEvent.EventName
                               select e;
            if (createdEvent != null)
                return createdEvent.FirstOrDefault(c => c.EventName == newEvent.EventName);
            return null;
        }

        public void DeleteEvent(long Id)
        {
            //
            var DeletedEvent = _database.Events.FirstOrDefault(x => x.EventId == Id);
            if (DeletedEvent != null)
                _database.Events.Remove(DeletedEvent);
            _database.SaveChanges();
        }

        public IEnumerable GetAllEvents()
        {
            //Entities
            var Events = _database.Events.ToList();
            var Tournaments = _database.Tournaments.ToList();

            //
            var result = from events in Events
                         join tournaments in Tournaments
                         on events.FkTournamentId equals tournaments.TournamentId
                         select new
                         {
                             //Specify what to Return
                             EventId = events.EventId,
                             EventName = events.EventName,
                             TournamentName = tournaments.TournamentName,
                             EventNumber = events.EventNumber,
                             EventStartDate = events.EventDateTime,
                             EventEndDate = events.EventEndDateTime,
                             AutoClose = events.AutoClose
                         };

            return result.ToList();
        }

        public Event UpdateEvent(long Id, Event eVent)
        {
            //
            var eventToUpdate = _database.Events.FirstOrDefault(x => x.EventId == Id);
            if (eventToUpdate == null)
                return null;
            eventToUpdate.EventName = eVent.EventName;
            eventToUpdate.EventNumber = eVent.EventNumber;
            eventToUpdate.EventDateTime = eVent.EventDateTime;
            eventToUpdate.EventEndDateTime = eVent.EventEndDateTime;
            eventToUpdate.FkTournamentId = eVent.FkTournamentId;
            _database.Events.Update(eventToUpdate);
            _database.SaveChanges();
            return eventToUpdate;
        }
    }
}