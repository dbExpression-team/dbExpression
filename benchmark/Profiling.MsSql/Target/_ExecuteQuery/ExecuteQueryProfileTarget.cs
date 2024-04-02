using Profiling.MsSql.DataService;
using DbExpression.Sql.Connection;
using System.Data;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public abstract class ExecuteQueryProfileTarget : IProfileTarget
    {
        private Lazy<ISqlConnection>? _connection;
        protected Lazy<ISqlConnection> Connection => _connection ??= new(db.GetConnection());
        private bool disposedValue;

        public virtual void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure)
        {

        }

        public abstract void Execute(IServiceProvider provider);

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_connection is not null)
                    {
                        if (_connection.Value.State == ConnectionState.Open)
                            _connection.Value.Close();
                        _connection = null;
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}