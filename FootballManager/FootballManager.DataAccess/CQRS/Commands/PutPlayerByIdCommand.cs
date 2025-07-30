using FootballManager.DataAccess.Entities;

namespace FootballManager.DataAccess.CQRS.Commands
{
    public class PutPlayerByIdCommand : CommandBase<Player, Player>
    {
        public string? NewFirstName { get; set; }

        public string? NewLastName { get; set; }

        public override async Task<Player> Execute(FootballManagerContext context)
        {
            this.Parameter.FirstName = this.NewFirstName;
            this.Parameter.LastName = this.NewLastName;
            context.Players.Update(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
