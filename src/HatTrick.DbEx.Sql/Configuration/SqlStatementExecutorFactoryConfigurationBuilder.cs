using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementExecutorFactoryConfigurationBuilder
    {
        private ISqlStatementExecutorFactory _factory;

        public SqlStatementExecutorFactoryConfigurationBuilder(ISqlStatementExecutorFactory factory)
        {
            _factory = factory;
        }

        public void RegisterExecutor<T>(SqlStatementExecutionType executionContext)
            where T : class, ISqlStatementExecutor, new()
        {
            _factory.RegisterExecutor<T>(executionContext);
        }

        public void RegisterExecutor(SqlStatementExecutionType executionContext, ISqlStatementExecutor executor)
        {
            _factory.RegisterExecutor(executionContext, executor);
        }
    }
}
