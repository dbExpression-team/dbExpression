using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementExecutionGroupingConfigurationBuilders : ISqlStatementExecutionGroupingConfigurationBuilders
    {
        #region internals
        private ISqlStatementsConfigurationBuilderGrouping caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private ISqlStatementFactoryConfigurationBuilder _executors;
        private IExecutionPipelineFactoryConfigurationBuilder _pipelines;
        private ISqlConnectionFactoryConfigurationBuilder _connections;
        #endregion

        #region interface
        public ISqlStatementFactoryConfigurationBuilder Executor => _executors ?? (_executors = new SqlStatementFactoryConfigurationBuilder(this, configuration));
        public IExecutionPipelineFactoryConfigurationBuilder Pipeline => _pipelines ?? (_pipelines = new ExecutionPipelineFactoryConfigurationBuilder(this, configuration));
        public ISqlConnectionFactoryConfigurationBuilder Connection => _connections ?? (_connections = new SqlConnectionFactoryConfigurationBuilder(this, configuration));
        public ISqlStatementAssemblyGroupingConfigurationBuilders Assembly => caller.Assembly;
        #endregion

        #region constructors
        public SqlStatementExecutionGroupingConfigurationBuilders(ISqlStatementsConfigurationBuilderGrouping caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion
    }
}
