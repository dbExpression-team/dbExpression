using HatTrick.DbEx.Sql.Pipeline;
using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class ExecutionPipelineFactoryConfigurationBuilder : IExecutionPipelineFactoryConfigurationBuilder
    {
        #region internals
        private readonly ISqlStatementExecutionGroupingConfigurationBuilders caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        #endregion

        #region constructors
        public ExecutionPipelineFactoryConfigurationBuilder(ISqlStatementExecutionGroupingConfigurationBuilders caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

        #region methods
        public ISqlStatementExecutionGroupingConfigurationBuilders Use(IExecutionPipelineFactory factory)
        {
            configuration.ExecutionPipelineFactory = factory;
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>()
            where TExecutionPipelineFactory : class, IExecutionPipelineFactory, new()
            => Use<TExecutionPipelineFactory>(null);

        public ISqlStatementExecutionGroupingConfigurationBuilders Use<TExecutionPipelineFactory>(Action<TExecutionPipelineFactory> configureFactory)
            where TExecutionPipelineFactory : class, IExecutionPipelineFactory, new()
        {
            if (!(configuration.ExecutionPipelineFactory is TExecutionPipelineFactory))
                configuration.ExecutionPipelineFactory = new TExecutionPipelineFactory();
            configureFactory?.Invoke(configuration.ExecutionPipelineFactory as TExecutionPipelineFactory);
            return caller;
        }

        public ISqlStatementExecutionGroupingConfigurationBuilders UseDefaultFactory()
        {
            if (!(configuration.ExecutionPipelineFactory is ExecutionPipelineFactory))
                configuration.ExecutionPipelineFactory = new ExecutionPipelineFactory();
            configuration.ExecutionPipelineFactory = new ExecutionPipelineFactory();
            return caller;
        }
        #endregion
    }
}
