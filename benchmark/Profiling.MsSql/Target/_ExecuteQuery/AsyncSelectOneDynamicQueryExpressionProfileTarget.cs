using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class AsyncSelectOneDynamicQueryExpressionProfileTarget : AsyncExecuteQueryProfileTarget
    {
        public override async Task ExecuteAsync(IServiceProvider provider)
        {
            await db.SelectOne(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).ExecuteAsync(Connection.Value);
        }
    }
}