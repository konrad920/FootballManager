using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess
{
    public class FootballManagerContext : DbContext
    {
        public FootballManagerContext(DbContextOptions<FootballManagerContext> opt) : base(opt) { 
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Team → Players (1:N)
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            // Team → Coach (1:1)
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Coach)
                .WithOne(c => c.Team)
                .HasForeignKey<Team>(t => t.CoachId)
                .OnDelete(DeleteBehavior.Restrict);

            // Convert int to string
            modelBuilder.Entity<Player>()
                .Property(p => p.Position)
                .HasConversion<string>();
        }
    }
}
