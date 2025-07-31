using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class DeleteCoachByIdCommand : CommandBase<Coach, Coach>
    {
        public override async Task<Coach> Execute(FootballManagerContext context)
        {
            context.Coaches.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
