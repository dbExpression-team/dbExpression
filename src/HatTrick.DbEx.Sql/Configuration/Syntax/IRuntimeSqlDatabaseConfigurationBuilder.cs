namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseConfigurationBuilder
    {
        IRuntimeSqlDatabaseAssemblyConfigurationBuilder WhenAssemblingSqlStatements { get; }
        IRuntimeSqlDatabaseMetadataConfigurationBuilder ForSqlSchemaMetadata { get; }
        IRuntimeSqlDatabaseQueryExpressionConfigurationBuilder WhenCreatingQueryExpressions { get; }
        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder WhenExecutingSqlStatements { get; }
        IRuntimeSqlDatabaseMappingConfigurationBuilder WhenMappingData { get; }
        IRuntimeSqlDatabaseEntityFactoryConfigurationBuilder ForCreatingEntities { get; }
    }
}
