using Profiling.MsSql.DataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public interface IProfileTarget : IDisposable
    {
        void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure);
        void Execute(IServiceProvider provider);
    }
}