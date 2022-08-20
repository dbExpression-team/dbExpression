using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class AsyncSelectOneQueryExpressionProfileTarget : AsyncExecuteQueryProfileTarget
    {
        public override async Task ExecuteAsync(IServiceProvider provider)
        {
            await db.SelectOne<Person>().From(dbo.Person).ExecuteAsync(Connection.Value);
        }
    }
}