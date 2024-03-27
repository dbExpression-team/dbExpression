using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class AsyncSelectOneWithWhereClauseQueryExpressionProfileTarget : AsyncExecuteQueryProfileTarget
    {
        public override async Task ExecuteAsync(IServiceProvider provider)
        {
            await db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).ExecuteAsync(Connection.Value);
        }
    }
}