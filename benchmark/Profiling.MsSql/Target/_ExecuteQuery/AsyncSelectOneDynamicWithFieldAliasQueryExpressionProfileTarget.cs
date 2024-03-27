using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{

    public class AsyncSelectOneDynamicWithFieldAliasQueryExpressionProfileTarget : AsyncExecuteQueryProfileTarget
    {
        public override async Task ExecuteAsync(IServiceProvider provider)
        {
            await db.SelectOne(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).ExecuteAsync(Connection.Value);
        }
    }
}