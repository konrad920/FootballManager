using FootballManager.DataAccess.CQRS.Queries;

namespace FootballManager.DataAccess
{
    public interface IQueryExecutor
    {
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query);
    }
}
