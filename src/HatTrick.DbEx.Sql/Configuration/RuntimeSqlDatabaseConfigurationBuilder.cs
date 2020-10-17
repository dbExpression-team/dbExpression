using HatTrick.DbEx.Sql.Configuration.Syntax;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseConfigurationBuilder : 
        IRuntimeSqlDatabaseConfigurationBuilder, 
        IRuntimeSqlDatabaseConfigurationProvider
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IRuntimeSqlDatabaseAssemblyConfigurationBuilder _assembler;
        private IRuntimeSqlDatabaseMetadataConfigurationBuilder _metadata;
        private IRuntimeSqlDatabaseQueryExpressionConfigurationBuilder _queryExpressions;
        private IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder _executor;
        private IRuntimeSqlDatabaseMappingConfigurationBuilder _mapper;
        private IRuntimeSqlDatabaseEntityFactoryConfigurationBuilder _entity;
        #endregion

        #region interface
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabaseConfigurationProvider.Configuration => configuration;

        public IRuntimeSqlDatabaseAssemblyConfigurationBuilder WhenAssemblingSqlStatements => _assembler ?? (_assembler = new RuntimeSqlDatabaseAssemblyConfigurationBuilder(configuration));
        public IRuntimeSqlDatabaseMetadataConfigurationBuilder ForSqlSchemaMetadata => _metadata ?? (_metadata = new RuntimeSqlDatabaseMetadataConfigurationBuilder(configuration));
        public IRuntimeSqlDatabaseQueryExpressionConfigurationBuilder WhenCreatingQueryExpressions => _queryExpressions ?? (_queryExpressions = new RuntimeSqlDatabaseQueryExpressionConfigurationBuilder(configuration));
        public IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder WhenExecutingSqlStatements => _executor ?? (_executor = new RuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder(configuration));
        public IRuntimeSqlDatabaseMappingConfigurationBuilder WhenMappingData => _mapper ?? (_mapper = new RuntimeSqlDatabaseMappingConfigurationBuilder(configuration));
        public IRuntimeSqlDatabaseEntityFactoryConfigurationBuilder ForCreatingEntities => _entity ?? (_entity = new RuntimeSqlDatabaseEntityFactoryConfigurationBuilder(configuration));
        #endregion

        #region constructors
        public RuntimeSqlDatabaseConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration;
        }
        #endregion
    }
}
