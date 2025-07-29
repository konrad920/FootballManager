using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetTeamByIdQuery : QueryBase<Team>
    {
        public int TeamId { get; set; }
        public override Task<Team> Execute(FootballManagerContext context)
        {
            return context.Teams
                .Include(t => t.Players)
                .SingleOrDefaultAsync(t => t.Id == this.TeamId);
        }
    }
}
