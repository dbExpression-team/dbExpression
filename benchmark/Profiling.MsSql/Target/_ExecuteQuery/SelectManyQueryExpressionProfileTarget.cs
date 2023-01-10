using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;

namespace Profiling.MsSql.Target
{
    public class SelectManyQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectMany<Person>().From(dbo.Person).Execute(Connection.Value).ToList();
        }
    }
}