using Microsoft.EntityFrameworkCore;
using TuneTracks.Models;
namespace TuneTracks.Data
{
    public class TuneTracksContext : DbContext
    {
        public TuneTracksContext(DbContextOptions<TuneTracksContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Song-Artist relationship to avoid cascading delete
            modelBuilder.Entity<Song>()
                .HasOne(s => s.Artist)
                .WithMany(a => a.Songs)
                .HasForeignKey(s => s.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);// Prevent cascading delete
        }


        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}