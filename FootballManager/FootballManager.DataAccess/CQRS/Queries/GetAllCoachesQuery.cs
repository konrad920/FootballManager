using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetAllCoachesQuery : QueryBase<List<Coach>>
    {
        public override Task<List<Coach>> Execute(FootballManagerContext context)
        {
            return context.Coaches
                .Include(c => c.Team)
                .ToListAsync();
        }
    }
}
