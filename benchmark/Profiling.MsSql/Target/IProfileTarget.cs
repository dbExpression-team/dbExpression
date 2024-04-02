using Profiling.MsSql.DataService;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public interface IProfileTarget : IDisposable
    {
        void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure);
        void Execute(IServiceProvider provider);
    }
}