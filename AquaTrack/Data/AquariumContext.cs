using Microsoft.EntityFrameworkCore;
using AquaTrack.Models;

namespace AquaTrack.Data
{
    public class AquariumContext : DbContext
    {
        public AquariumContext(DbContextOptions<AquariumContext> options) : base(options)
        {
        }

        public DbSet<Fish> Fish { get; set; }
        public DbSet<Tank> Tanks { get; set; }
        public DbSet<Feeding> Feedings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tank>()
                .HasMany(t => t.Fish)
                .WithOne(f => f.Tank)
                .HasForeignKey(f => f.TankId);

            modelBuilder.Entity<Fish>()
                .HasMany(f => f.Feedings)
                .WithOne(fd => fd.Fish)
                .HasForeignKey(fd => fd.FishId);
        }
    }
}
