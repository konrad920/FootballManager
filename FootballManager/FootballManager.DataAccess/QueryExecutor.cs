using FootballManager.DataAccess.CQRS.Queries;

namespace FootballManager.DataAccess
{
    public class QueryExecutor : IQueryExecutor
    {
        private readonly FootballManagerContext context;

        public QueryExecutor(FootballManagerContext context)
        {
            this.context = context;
        }
        public Task<TResult> Execute<TResult>(QueryBase<TResult> query)
        {
            return query.Execute(this.context);
        }
    }
}
