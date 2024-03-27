using Profiling.MsSql.DataService;
using DbExpression.Sql.Connection;
using System.Data;
using System.Data.Common;
using DbExpression.Sql.Configuration;

namespace Profiling.MsSql.Target
{
    public abstract class AsyncExecuteQueryProfileTarget : IAsyncProfileTarget
    {
        private Lazy<ISqlConnection>? _connection;
        protected Lazy<ISqlConnection> Connection => _connection ??= new(db.GetConnection());
        
        public virtual void Configure(ISqlDatabaseRuntimeConfigurationBuilder<ProfilingDatabase> configure)
        {

        }

        public abstract Task ExecuteAsync(IServiceProvider provider);

        public ValueTask DisposeAsync()
        {            
            return new ValueTask(new(() => { Dispose(); GC.SuppressFinalize(this); }));
        }

        protected virtual Task Dispose()
        {
            if (_connection is not null)
            {
                if (_connection.Value.State == ConnectionState.Open)
                {
                    if (_connection.Value.DbConnection is DbConnection dbConnection)
                        return dbConnection.CloseAsync();
                    else
                        _connection.Value.Close();
                }
                _connection = null;
            }
            return Task.CompletedTask;
        }
    }
}