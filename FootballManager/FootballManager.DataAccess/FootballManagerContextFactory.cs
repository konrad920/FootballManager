using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FootballManager.DataAccess
{
    public class FootballManagerContextFactory : IDesignTimeDbContextFactory<FootballManagerContext>
    {
        public FootballManagerContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FootballManagerContext>();
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-QIGQKKJP\\SQLEXPRESS;Initial Catalog=FootballManager;Integrated Security=True;Trust Server Certificate=True");
            return new FootballManagerContext(optionsBuilder.Options);
        }
    }
}
