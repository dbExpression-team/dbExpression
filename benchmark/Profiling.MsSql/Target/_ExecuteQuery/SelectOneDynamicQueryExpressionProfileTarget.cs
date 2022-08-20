using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class SelectOneDynamicQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectOne(dbo.Person.Id, dbo.Person.FirstName, dbo.Person.LastName).From(dbo.Person).Execute(Connection.Value);
        }
    }
}