using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public class SelectOneWithFieldAliasQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectOne(dbo.Person.Id).From(dbo.Person).Execute(Connection.Value);
        }
    }
}