using FootballManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FootballManager.DataAccess.CQRS.Queries
{
    public class GetAllPlayersQuery : QueryBase<List<Player>>
    {
        public string ?Position { get; set; }
        public override Task<List<Player>> Execute(FootballManagerContext context)
        {
            if (string.IsNullOrEmpty(this.Position))
            {
                return context.Players
                .Include(p => p.Team)
                .ToListAsync();
            }
            else
            {
                return context.Players
                    .Include(p => p.Team)
                    .Where(p => p.Position == PlayerPositionMapper.FromShort(this.Position))
                    .ToListAsync();
            }
        }
    }
}
