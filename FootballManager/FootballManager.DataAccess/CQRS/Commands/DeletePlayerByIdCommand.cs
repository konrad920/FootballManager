using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class DeletePlayerByIdCommand : CommandBase<Player, Player>
    {
        public override async Task<Player> Execute(FootballManagerContext context)
        {
            context.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
