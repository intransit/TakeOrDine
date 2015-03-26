namespace TakeOrDine.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TakeOrDineDbContext : DbContext
    {
        public TakeOrDineDbContext()
            : base("name=TakeOrDineDbContext")
        {
        }

        public virtual DbSet<Attendee> Attendees { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<host> hosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendee>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Attendee>()
                .Property(e => e.DineType)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.DineType)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.MenuInCsv)
                .IsUnicode(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Attendees)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Guests)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .HasMany(e => e.Attendees)
                .WithRequired(e => e.Guest)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<host>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.specialityInCsv)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.Bio)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.host)
                .WillCascadeOnDelete(false);
        }
    }
}
