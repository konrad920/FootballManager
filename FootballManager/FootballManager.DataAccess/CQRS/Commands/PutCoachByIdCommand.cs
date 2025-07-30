using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class PutCoachByIdCommand : CommandBase<Coach, Coach>
    {
        public string? NewFirstName { get; set; }

        public long NewSalary {  get; set; }

        public override async Task<Coach> Execute(FootballManagerContext context)
        {
            this.Parameter.FirstName = this.NewFirstName;
            this.Parameter.Salary = this.NewSalary;
            context.Coaches.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
