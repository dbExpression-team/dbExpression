using Profiling.MsSql.DataService;
using DbExpression.Sql.Configuration;
using System.Buffers;
using DbExpression.Sql.Assembler;

namespace Profiling.MsSql.Target
{
    public abstract class AssembleQueryProfileTarget : IProfileTarget
    {
        public virtual void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure)
        {

        }

        public abstract void Execute(IServiceProvider provider);

        protected virtual void Dispose(bool disposing)
        {

        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}