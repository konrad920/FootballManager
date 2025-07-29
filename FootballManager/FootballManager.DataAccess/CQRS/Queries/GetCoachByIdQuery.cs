using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetCoachByIdQuery : QueryBase<Coach>
    {
        public int CoachId { get; set; }
        public override Task<Coach> Execute(FootballManagerContext context)
        {
            return context.Coaches
                .Include(c => c.Team)
                .SingleOrDefaultAsync(c => c.Id == this.CoachId);
        }
    }
}
