using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class SelectOneDynamicWithFieldAliasQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectOne(dbo.Person.Id.As("person_Id"), dbo.Person.FirstName.As("person_FirstName"), dbo.Person.LastName.As("person_LastName")).From(dbo.Person).Execute(Connection.Value);
        }
    }
}