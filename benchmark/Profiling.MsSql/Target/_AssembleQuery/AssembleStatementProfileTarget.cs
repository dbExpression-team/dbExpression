using DbExpression.MsSql.Configuration;
using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Profiling.MsSql.DataService;
using Profiling.MsSql.dboData;
using Profiling.MsSql.dboDataService;

namespace Profiling.MsSql.Target
{
    public class AssembleStatementProfileTarget : AssembleQueryProfileTarget
    {
        private static readonly QueryExpression selectQueryExpression = (db.SelectMany<Person>().From(dbo.Person).InnerJoin(dbo.PersonAddress).On(dbo.Person.Id == dbo.PersonAddress.PersonId).InnerJoin(dbo.Address).On(dbo.Address.Id == dbo.PersonAddress.AddressId)).Expression;

        public override void Execute(IServiceProvider serviceProvider)
        {
            serviceProvider.GetServiceProviderFor<ProfilingDatabase>().GetRequiredService<ISqlStatementBuilder>().CreateSqlStatement(selectQueryExpression);
        }
    }
}
