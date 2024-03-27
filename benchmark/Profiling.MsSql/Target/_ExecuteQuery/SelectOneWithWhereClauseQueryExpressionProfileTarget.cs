using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;
using DbExpression.Sql.Configuration;


namespace Profiling.MsSql.Target
{
    public class SelectOneWithWhereClauseQueryExpressionProfileTarget : ExecuteQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            db.SelectOne<Person>().From(dbo.Person).Where(dbo.Person.Id == 1).Execute(Connection.Value);
        }
    }
}