using FootballManager.DataAccess.CQRS.Commands;

namespace FootballManager.DataAccess.CQRS
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly FootballManagerContext context;

        public CommandExecutor(FootballManagerContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TParameter, TResult>(CommandBase<TParameter, TResult> command)
        {
            return command.Execute(this.context);
        }
    }
}
