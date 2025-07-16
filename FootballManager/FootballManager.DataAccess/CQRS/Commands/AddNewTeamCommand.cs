using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class AddNewTeamCommand : CommandBase<Team, Team>
    {
        public override async Task<Team> Execute(FootballManagerContext context)
        {
            await context.Teams.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
