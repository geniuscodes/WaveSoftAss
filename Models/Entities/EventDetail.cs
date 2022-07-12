using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WaveSoftAss
{
    public partial class EventDetail
    {
        [Key]
        public long EventDetailId { get; set; }
        //ForeignKeys
        public long FkEventId { get; set; }
        public short FkEventDetailsStatusId { get; set; }
        public string EventDetailName { get; set; }
        public decimal EventDetailOdd { get; set; }
        public short? FinishingPosition { get; set; }
        public bool FirstTimer { get; set; }

        //One-to-One
        public virtual Event FkEvent { get; set; } = null!;
        public virtual EventDetailStatus FkEventDetailsStatus { get; set; } = null!;
    }
}
