using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class AddNewCoachCommand : CommandBase<Coach, Coach>
    {
        public override async Task<Coach> Execute(FootballManagerContext context)
        {
            await context.Coaches.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
