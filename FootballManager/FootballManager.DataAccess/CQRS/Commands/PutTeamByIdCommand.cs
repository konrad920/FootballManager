using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class PutTeamByIdCommand : CommandBase<Team, Team>
    {
        public string? NewName { get; set; }
        public override async Task<Team> Execute(FootballManagerContext context)
        {
            this.Parameter.Name = this.NewName;
            context.Teams.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
