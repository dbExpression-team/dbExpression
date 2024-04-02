using DbExpression.Sql.Assembler;
using DbExpression.Sql.Expression;
using Microsoft.Extensions.DependencyInjection;
using Profiling.MsSql.dboDataService;

namespace Profiling.MsSql.Target
{
    public class AppendFieldExpressionProfileTarget : AssembleQueryProfileTarget
    {
        public override void Execute(IServiceProvider provider)
        {
            var builder = provider.GetRequiredService<ISqlStatementBuilder>();
            var appenderFactory = provider.GetRequiredService<IExpressionElementAppenderFactory>();
            var context = provider.GetRequiredService<AssemblyContext>();
            var appender = appenderFactory.CreateElementAppender<FieldExpression>();
            appender.AppendElement(dbo.Person.FirstName, builder, context);
        }
    }
}
