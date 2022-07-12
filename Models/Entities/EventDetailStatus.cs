using System;
using System.Collections.Generic;

namespace WaveSoftAss
{
    public partial class EventDetailStatus
    {
        public EventDetailStatus()
        {
            EventDetails = new HashSet<EventDetail>();
        }

        public short EventDetailStatusId { get; set; }
        public string EventDetailStatusName { get; set; } = null!;

        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
