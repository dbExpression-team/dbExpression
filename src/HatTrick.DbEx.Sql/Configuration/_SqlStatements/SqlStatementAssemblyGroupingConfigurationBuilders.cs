using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementAssemblyGroupingConfigurationBuilders : ISqlStatementAssemblyGroupingConfigurationBuilders
    {
        #region internals
        private ISqlStatementsConfigurationBuilderGrouping caller;
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IExpressionElementAppenderFactoryConfigurationBuilder _elementAppender;
        private IAppenderFactoryConfigurationBuilder _appender;
        private ISqlParameterBuilderFactoryConfigurationBuilder _parameter;
        private ISqlStatementBuilderFactoryConfigurationBuilder _statement;
        #endregion

        #region interface
        public IExpressionElementAppenderFactoryConfigurationBuilder ElementAppender => _elementAppender ?? (_elementAppender = new ExpressionElementAppenderFactoryConfigurationBuilder(this, configuration));
        public IAppenderFactoryConfigurationBuilder StatementAppender => _appender ?? (_appender = new AppenderFactoryConfigurationBuilder(this, configuration));
        public ISqlParameterBuilderFactoryConfigurationBuilder ParameterBuilder => _parameter ?? (_parameter = new SqlParameterBuilderFactoryConfigurationBuilder(this, configuration));
        public ISqlStatementBuilderFactoryConfigurationBuilder StatementBuilder => _statement ?? (_statement = new SqlStatementBuilderFactoryConfigurationBuilder(this, configuration));
        public ISqlStatementExecutionGroupingConfigurationBuilders Execution => caller.Execution;
        #endregion

        #region constructors
        public SqlStatementAssemblyGroupingConfigurationBuilders(ISqlStatementsConfigurationBuilderGrouping caller, RuntimeSqlDatabaseConfiguration configuration)
        {
            this.caller = caller ?? throw new ArgumentNullException($"{nameof(caller)} is required.");
            this.configuration = configuration ?? throw new ArgumentNullException($"{nameof(configuration)} is required.");
        }
        #endregion

        #region methods
        public ISqlStatementAssemblyGroupingConfigurationBuilders ConfigureOutputSettings(Action<SqlStatementAssemblerConfiguration> config)
        {
            config?.Invoke(configuration.AssemblerConfiguration);
            return this;
        }
        #endregion
    }
}
