using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class AddNewPlayerCommand : CommandBase<Player, Player>
    {
        public override async Task<Player> Execute(FootballManagerContext context)
        {
            await context.Players.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
