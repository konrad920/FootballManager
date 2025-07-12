using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetAllTeamsQuery : QueryBase<List<Team>>
    {
        public override Task<List<Team>> Execute(FootballManagerContext context)
        {
            return context.Teams.ToListAsync();
        }
    }
}
