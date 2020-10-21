using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Data;

namespace HatTrick.DbEx.Sql.Configuration.Syntax
{
    public interface IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder
    {
        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors(ISqlStatementExecutorFactory factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors<T>()
            where T : class, ISqlStatementExecutorFactory, new();

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors(Func<QueryExpression, ISqlStatementExecutor> factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlStatementExecutors(Func<ISqlStatementExecutorFactory> factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlConnections(ISqlConnectionFactory factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlConnections<T>()
            where T : ISqlConnectionFactory, new();

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewSqlConnections(Func<IDbConnection> factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToAccessAConnectionFactoryToCreateNewSqlConnections(Func<ISqlConnectionFactory> factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewExecutionPipelines(IExecutionPipelineFactory factory);

        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder UseThisToCreateNewExecutionPipelines<T>()
            where T : class, IExecutionPipelineFactory, new();

        IPipelineEventActionBuilder<BeforeAssemblyPipelineExecutionContext> BeforeAssemblingSqlStatement(Action<BeforeAssemblyPipelineExecutionContext> action);

        IPipelineEventActionBuilder<AfterAssemblyPipelineExecutionContext> AfterAssemblingSqlStatement(Action<AfterAssemblyPipelineExecutionContext> action);

        IPipelineEventActionBuilder<BeforeInsertPipelineExecutionContext> BeforeInsertingEntity(Action<BeforeInsertPipelineExecutionContext> action);

        IPipelineEventActionBuilder<AfterInsertPipelineExecutionContext> AfterInsertingEntity(Action<AfterInsertPipelineExecutionContext> action);

        IPipelineEventActionBuilder<BeforeUpdatePipelineExecutionContext> BeforeUpdatingEntity(Action<BeforeUpdatePipelineExecutionContext> action);

        IPipelineEventActionBuilder<AfterUpdatePipelineExecutionContext> AfterUpdatingEntity(Action<AfterUpdatePipelineExecutionContext> action);

        IPipelineEventActionBuilder<BeforeDeletePipelineExecutionContext> BeforeDeletingEntity(Action<BeforeDeletePipelineExecutionContext> action);

        IPipelineEventActionBuilder<AfterDeletePipelineExecutionContext> AfterDeletingEntity(Action<AfterDeletePipelineExecutionContext> action);

        IPipelineEventActionBuilder<BeforeSelectPipelineExecutionContext> BeforeSelectingEntity(Action<BeforeSelectPipelineExecutionContext> action);

        IPipelineEventActionBuilder<AfterSelectPipelineExecutionContext> AfterSelectingEntity(Action<AfterSelectPipelineExecutionContext> action);

        IPipelineEventActionBuilder<BeforeExecutionPipelineExecutionContext> BeforeExecutingCommand(Action<BeforeExecutionPipelineExecutionContext> action);

        IPipelineEventActionBuilder<AfterExecutionPipelineExecutionContext> AfterExecutingCommand(Action<AfterExecutionPipelineExecutionContext> action);
    }


    public interface IRuntimeSqlDatabaseConfigurationBuilder
    {
        IRuntimeSqlDatabaseAssemblyConfigurationBuilder WhenAssemblingSqlStatements { get; }
        IRuntimeSqlDatabaseMetadataConfigurationBuilder ForSqlSchemaMetadata { get; }
        IRuntimeSqlDatabaseQueryExpressionConfigurationBuilder WhenCreatingQueryExpressions { get;  }
        IRuntimeSqlDatabaseSqlStatementExecutionConfigurationBuilder WhenExecutingSqlStatements { get; }
        IRuntimeSqlDatabaseMappingConfigurationBuilder WhenMappingData { get; }
        IRuntimeSqlDatabaseEntityFactoryConfigurationBuilder ForCreatingEntities { get; }   
    }
}
