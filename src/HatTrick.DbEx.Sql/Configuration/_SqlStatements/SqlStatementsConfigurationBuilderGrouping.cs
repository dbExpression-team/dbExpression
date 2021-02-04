using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class SqlStatementsConfigurationBuilderGrouping : ISqlStatementsConfigurationBuilderGrouping
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private ISqlStatementAssemblyGroupingConfigurationBuilders _assembly;
        private ISqlStatementExecutionGroupingConfigurationBuilders _execution;
        #endregion

        #region interface
        public ISqlStatementAssemblyGroupingConfigurationBuilders Assembly => _assembly ?? (_assembly = new SqlStatementAssemblyGroupingConfigurationBuilders(this, configuration));
        public ISqlStatementExecutionGroupingConfigurationBuilders Execution => _execution ?? (_execution = new SqlStatementExecutionGroupingConfigurationBuilders(this, configuration));
        #endregion

        #region constructors
        public SqlStatementsConfigurationBuilderGrouping(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion 

        #region methods
        public ISqlStatementsConfigurationBuilderGrouping ConfigureOutputSettings(Action<SqlStatementAssemblerConfiguration> config)
        {
            config(configuration.AssemblerConfiguration);
            return this;
        }
        #endregion
    }
}
