using Microsoft.EntityFrameworkCore;

namespace WaveSoftAss.Models.Data
{
    public class AppDbContext : DbContext
    {
        //
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }


        //Tables
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventDetail> EventDetails { get; set; }
        public DbSet<EventDetailStatus> EventDetailStatuses { get; set; }
    }

}