using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace WaveSoftAss
{
    public  class Event
    {
     

        [Key]
        public long EventId { get; set; }
        //Tournament ForeignKey
        public long FkTournamentId { get; set; }
        public string EventName { get; set; } = null!;
        public short EventNumber { get; set; }
        public DateTime EventDateTime { get; set; }
        public DateTime? EventEndDateTime { get; set; }
        public bool AutoClose { get; set; }

        public virtual Tournament FkTournament { get; set; } = null!;
       public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
