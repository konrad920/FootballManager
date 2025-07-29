using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetPlayerByIdQuery : QueryBase<Player>
    {
        public int PlayerId { get; set; }
        public override Task<Player> Execute(FootballManagerContext context)
        {
            return context.Players
                .Include(p => p.Team)
                .SingleOrDefaultAsync(x => x.Id == this.PlayerId);
        }
    }
}
