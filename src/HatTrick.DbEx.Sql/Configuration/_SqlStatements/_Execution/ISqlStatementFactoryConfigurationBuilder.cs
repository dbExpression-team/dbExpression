using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlStatementFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating an <see cref="ISqlStatementExecutor"/> used to execute a sql statement against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use(ISqlStatementExecutorFactory factory);

        /// <summary>
        /// Use a custom factory for creating an <see cref="ISqlStatementExecutor"/> used to execute a sql statement against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlStatementExecutorFactory>()
            where TSqlStatementExecutorFactory : class, ISqlStatementExecutorFactory, new();

        /// <summary>
        /// Use a custom factory for creating an <see cref="ISqlStatementExecutor"/> used to execute a sql statement against the target database.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TSqlStatementExecutorFactory"/>.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlStatementExecutorFactory>(Action<TSqlStatementExecutorFactory> configureFactory)
            where TSqlStatementExecutorFactory : class, ISqlStatementExecutorFactory, new();

        /// <summary>
        /// Use a custom factory for creating an <see cref="ISqlStatementExecutor"/>, given a <see cref="QueryExpression"/>, used to execute a sql statement against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use(Func<QueryExpression, ISqlStatementExecutor> factory);

        /// <summary>
        /// Use the default factory for creating an <see cref="ISqlStatementExecutor"/> used to execute a sql statement against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory();
    }
}
