using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WaveSoftAss
{
    public partial class MyHollyWoodBetContext : DbContext
    {
        public MyHollyWoodBetContext()
        {
        }

        public MyHollyWoodBetContext(DbContextOptions<MyHollyWoodBetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventDetail> EventDetails { get; set; } = null!;
        public virtual DbSet<EventDetailStatus> EventDetailStatuses { get; set; } = null!;
        public virtual DbSet<Tournament> Tournaments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=MyHollyWoodBet");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.EventId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventID");

                entity.Property(e => e.EventDateTime).HasColumnType("datetime");

                entity.Property(e => e.EventEndDateTime).HasColumnType("datetime");

                entity.Property(e => e.EventName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FkTournamentId).HasColumnName("FK_TournamentID");

               
            });

            modelBuilder.Entity<EventDetail>(entity =>
            {
                entity.ToTable("EventDetail");

                entity.Property(e => e.EventDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventDetailID");

                entity.Property(e => e.FkEventDetailsStatusId).HasColumnName("FK_EventDetailsStatusID");

                entity.Property(e => e.FkEventId).HasColumnName("FK_EventID");

                entity.HasOne(d => d.FkEventDetailsStatus)
                    .WithMany(p => p.EventDetails)
                    .HasForeignKey(d => d.FkEventDetailsStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventDetailsStatusID");

                //entity.HasOne(d => d.FkEvent)
                //    .WithMany(p => p.EventDetails)
                //    .HasForeignKey(d => d.FkEventId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_EventID");
            });

            modelBuilder.Entity<EventDetailStatus>(entity =>
            {
                entity.ToTable("EventDetailStatus");

                entity.Property(e => e.EventDetailStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("EventDetailStatusID");

                entity.Property(e => e.EventDetailStatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tournament>(entity =>
            {
                entity.ToTable("Tournament");

                entity.Property(e => e.TournamentId).HasColumnName("TournamentID");

                entity.Property(e => e.TournamentName).HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
