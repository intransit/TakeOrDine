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

        public virtual DbSet<Guest> Guest { get; set; }
        public virtual DbSet<host> Hosts { get; set; }
        public virtual DbSet<ManageListing> ManageListing { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guest>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Guest>()
                .Property(e => e.Name)
                .IsUnicode(false);

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
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.Zipcode)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.UnitNumber)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<host>()
                .HasMany(e => e.ManageListing)
                .WithRequired(e => e.host)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ManageListing>()
                .Property(e => e.DineType)
                .IsUnicode(false);

            modelBuilder.Entity<ManageListing>()
                .Property(e => e.StartTimeOfAvailability)
                .HasPrecision(0);

            modelBuilder.Entity<ManageListing>()
                .Property(e => e.EndTimeOfAvailability)
                .HasPrecision(0);

            modelBuilder.Entity<ManageListing>()
                .Property(e => e.CusineType)
                .IsUnicode(false);

            modelBuilder.Entity<ManageListing>()
                .Property(e => e.Menu)
                .IsUnicode(false);
        }
    }
}
