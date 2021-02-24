using HatTrick.DbEx.Sql.Connection;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface ISqlConnectionFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating creating an <see cref="IDbConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use(ISqlConnectionFactory factory);

        /// <summary>
        /// Use a custom factory for creating creating an <see cref="IDbConnection"/> used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlConnectionFactory>()
            where TSqlConnectionFactory : class, ISqlConnectionFactory, new();

        /// <summary>
        /// Use a custom factory for creating creating an <see cref="IDbConnection"/> used to execute sql statements against the target database.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TSqlConnectionFactory"/>.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TSqlConnectionFactory>(Action<TSqlConnectionFactory> configureFactory)
            where TSqlConnectionFactory : class, ISqlConnectionFactory, new();

        /// <summary>
        /// Use a custom factory for creating creating an <see cref="IDbConnection"/>, given a connection string, used to execute sql statements against the target database.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use(Func<string, IDbConnection> factory);
    }
}
