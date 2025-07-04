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
    }
}
