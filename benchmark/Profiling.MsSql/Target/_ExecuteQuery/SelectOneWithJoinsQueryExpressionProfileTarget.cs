using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class SelectOneWithJoinsQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectOne<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).Execute(Connection.Value);
        }
    }
}