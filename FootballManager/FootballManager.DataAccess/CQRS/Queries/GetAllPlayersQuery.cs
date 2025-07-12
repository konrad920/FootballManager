using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetAllPlayersQuery : QueryBase<List<Player>>
    {
        public override Task<List<Player>> Execute(FootballManagerContext context)
        {
            return context.Players.ToListAsync();
        }
    }
}
