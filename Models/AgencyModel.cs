using System.Data.Entity;

namespace TravelAgencyCRM.Models
{
    public partial class AgencyModel : DbContext
    {
        public AgencyModel()
            : base("name=AgencyModelHome")
        {
        }

        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Staff> Staff { get; set; }
        public virtual DbSet<Tours> Tours { get; set; }
        public virtual DbSet<TourStates> TourStates { get; set; }
        public virtual DbSet<TourType> TourType { get; set; }
        public virtual DbSet<Track> Track { get; set; }
        public virtual DbSet<Transports> Transports { get; set; }
        public virtual DbSet<TransportType> TransportType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clients>()
                .HasMany(e => e.Track)
                .WithOptional(e => e.Clients)
                .HasForeignKey(e => e.ClientID);

            modelBuilder.Entity<Tours>()
                .HasMany(e => e.Track)
                .WithOptional(e => e.Tours)
                .HasForeignKey(e => e.TourID);

            modelBuilder.Entity<TourStates>()
                .HasMany(e => e.Tours)
                .WithOptional(e => e.TourStates)
                .HasForeignKey(e => e.State);

            modelBuilder.Entity<TourType>()
                .HasMany(e => e.Tours)
                .WithOptional(e => e.TourType)
                .HasForeignKey(e => e.Type);

            modelBuilder.Entity<Transports>()
                .HasMany(e => e.Track)
                .WithOptional(e => e.Transports)
                .HasForeignKey(e => e.TransportID);

            modelBuilder.Entity<TransportType>()
                .HasMany(e => e.Transports)
                .WithOptional(e => e.TransportType)
                .HasForeignKey(e => e.Type);
        }
    }
}
