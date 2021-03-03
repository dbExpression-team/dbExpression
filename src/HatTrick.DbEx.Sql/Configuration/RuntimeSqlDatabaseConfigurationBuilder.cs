using System;

namespace HatTrick.DbEx.Sql.Configuration
{
    public class RuntimeSqlDatabaseConfigurationBuilder :
        IRuntimeSqlDatabaseConfigurationBuilder,
        IRuntimeSqlDatabaseConfigurationProvider
    {
        #region internals
        private readonly RuntimeSqlDatabaseConfiguration configuration;
        private IConnectionStringFactoryConfigurationBuilder _connectionString;
        private ISqlStatementsConfigurationBuilderGrouping _assembler;
        private ISqlDatabaseMetadataProviderConfigurationBuilder _metadata;
        private IQueryExpressionFactoryConfigurationBuilder _queryExpressions;
        private IValueConverterFactoryConfigurationBuilder _valueConverter;
        private IExecutionPipelineEventConfigurationBuilder _event;

        private IEntitiesConfigurationBuilderGrouping _entities;
        #endregion

        #region interface
        RuntimeSqlDatabaseConfiguration IRuntimeSqlDatabaseConfigurationProvider.Configuration => configuration;

        public IConnectionStringFactoryConfigurationBuilder ConnectionString => _connectionString ?? (_connectionString = new ConnectionStringFactoryConfigurationBuilder(configuration));
        public ISqlDatabaseMetadataProviderConfigurationBuilder SchemaMetadata => _metadata ?? (_metadata = new SqlDatabaseMetadataProviderConfigurationBuilder(configuration));
        public IQueryExpressionFactoryConfigurationBuilder QueryExpressions => _queryExpressions ?? (_queryExpressions = new QueryExpressionFactoryConfigurationBuilder(configuration));
        public IEntitiesConfigurationBuilderGrouping Entities => _entities ?? (_entities = new EntitiesConfigurationBuilderGrouping(configuration));
        public IValueConverterFactoryConfigurationBuilder Conversions => _valueConverter ?? (_valueConverter = new ValueConverterFactoryConfigurationBuilder(configuration));
        public ISqlStatementsConfigurationBuilderGrouping SqlStatements => _assembler ?? (_assembler = new SqlStatementsConfigurationBuilderGrouping(configuration));     
        public IExecutionPipelineEventConfigurationBuilder Events => _event ?? (_event = new ExecutionPipelineEventConfigurationBuilder(configuration));
        #endregion

        #region constructors
        public RuntimeSqlDatabaseConfigurationBuilder(RuntimeSqlDatabaseConfiguration configuration)
        {
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        protected RuntimeSqlDatabaseConfigurationBuilder()
        {

        }
        #endregion
    }
}
