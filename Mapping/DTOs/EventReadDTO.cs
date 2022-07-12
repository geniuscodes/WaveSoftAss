namespace WaveSoftAss.Mapping.DTOs
{
    public class EventReadDTO
    {
        public long EventId { get; set; }
        public long TournamentID { get; set; }
        public string EventName { get; set; } = null!;
        public short EventNumber { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime? EventEndDate { get; set; }
        public bool AutoClose { get; set; }
    }
}
