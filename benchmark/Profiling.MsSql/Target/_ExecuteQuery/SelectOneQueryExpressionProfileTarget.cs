using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class SelectOneQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectOne<Person>().From(dbo.Person).Execute(Connection.Value);
        }
    }
}