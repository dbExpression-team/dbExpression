using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class AsyncSelectOneWithFieldAliasQueryExpressionProfileTarget : AsyncExecuteQueryProfileTarget
    {
        public override async Task ExecuteAsync(IServiceProvider provider)
        {
            await db.SelectOne(dbo.Person.Id).From(dbo.Person).ExecuteAsync(Connection.Value);
        }
    }
}