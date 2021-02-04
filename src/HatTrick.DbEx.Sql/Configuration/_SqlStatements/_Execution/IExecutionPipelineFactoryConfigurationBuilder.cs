using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public interface IExecutionPipelineFactoryConfigurationBuilder
    {
        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use(IExecutionPipelineFactory factory);

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>()
            where TExecutionPipelineFactory : class, IExecutionPipelineFactory, new();

        /// <summary>
        /// Use a custom factory for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        /// <param name="configureFactory">A delegate for configuring the <typeparamref name="TExecutionPipelineFactory"/>.</param>
        ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>(Action<TExecutionPipelineFactory> configureFactory)
            where TExecutionPipelineFactory : class, IExecutionPipelineFactory, new();

        /// <summary>
        /// Use the default factory (highly recommended) for creating an execution pipeline used to build and execute a sql statement from a query expression.
        /// </summary>
        ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory();
    }
}
