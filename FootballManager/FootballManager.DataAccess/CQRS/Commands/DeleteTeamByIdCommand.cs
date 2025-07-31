using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class DeleteTeamByIdCommand : CommandBase<Team, Team>
    {
        public override async Task<Team> Execute(FootballManagerContext context)
        {
            context.Teams.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
