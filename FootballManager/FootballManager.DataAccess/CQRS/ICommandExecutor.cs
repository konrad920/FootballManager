using FootballManager.DataAccess.CQRS.Commands;

namespace FootballManager.DataAccess.CQRS
{
    public interface ICommandExecutor
    {
        public Task<TResult> Execute<TParameter, TResult> (CommandBase<TParameter, TResult> command);
    }
}
