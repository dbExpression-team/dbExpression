using HatTrick.DbEx.Sql.Assembler;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Profiling.MsSql.DataService;
using Profiling.MsSql.dboDataService;

namespace Profiling.MsSql.Target
{
    public class AppendFieldExpressionProfileTarget : AssembleQueryProfileTarget
    {
        public override void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure)
        {

        }

        public override void Execute(IServiceProvider provider)
        {
            var builder = provider.GetRequiredService<ISqlStatementBuilder<ProfilingDatabase>>();
            var appenderFactory = provider.GetRequiredService<IExpressionElementAppenderFactory<ProfilingDatabase>>();
            var context = provider.GetRequiredService<AssemblyContext>();
            var appender = appenderFactory.CreateElementAppender<FieldExpression>();
            appender.AppendElement(dbo.Person.FirstName, builder, context);
        }
    }
}
