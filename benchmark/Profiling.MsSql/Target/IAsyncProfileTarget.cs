using Profiling.MsSql.DataService;
using HatTrick.DbEx.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public interface IAsyncProfileTarget : IAsyncDisposable
    {
        void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure);
        Task ExecuteAsync(IServiceProvider provider);
    }
}