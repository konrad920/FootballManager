using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetAllTeamsQuery : QueryBase<List<Team>>
    {
        public string ?PartOfName { get; set; }
        public override Task<List<Team>> Execute(FootballManagerContext context)
        {
            if(this.PartOfName == null)
            {
                return context.Teams
                    .Include(t => t.Players)
                    .ToListAsync();
            }
            else
            {
                return context.Teams
                    .Include(t => t.Players)
                    .Where(t => t.Name.Contains(this.PartOfName))
                    .ToListAsync();
            }
        }
    }
}
