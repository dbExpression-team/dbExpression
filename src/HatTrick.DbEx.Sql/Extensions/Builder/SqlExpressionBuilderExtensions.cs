using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Extensions.Builder
{
    public static class SqlExpressionBuilderExtensions
    {
        private static DatabaseConfiguration GetDatabaseConfiguration(this ITerminationExpressionBuilder builder)
        {
            var entity = (builder as IDbExpressionSetProvider).Expression.BaseEntity as IDbExpressionMetadataProvider<ISqlEntityMetadata>;
            var dbName = entity.Metadata?.Schema?.Database?.Name;
            if (string.IsNullOrWhiteSpace(dbName))
                throw new DbExpressionConfigurationException($"Could not resolve database configuration for entity '{entity}', please review and ensure the correct configuration and startup initialization for DbExpression.");
            if (!DbExpression.Configuration.Databases.ContainsKey(dbName))
                throw new DbExpressionConfigurationException($"Database configuration for entity '{entity}' was not found, please review and ensure the correct configuration and startup initialization for DbExpression.");

            return DbExpression.Configuration.Databases[dbName].DatabaseConfiguration;
        }

        private static SyncExecutionPipeline CreateSyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateSyncExecutionPipeline();

        private static AsyncExecutionPipeline CreateAsyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline();

        #region TerminationExpressionBuilder
        public static void Execute(this ITerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static void Execute(this ITerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static void Execute(this ITerminationExpressionBuilder builder, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static void Execute(this ITerminationExpressionBuilder builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static void Execute(this ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static void Execute(this ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder
        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder) 
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int connectionTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connectionTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder
        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder
        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region TypeTerminationExpressionBuilder
        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder) 
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion

        #region TypeListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, commandTimeout);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, configureCommand);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, commandTimeout);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection, configureCommand);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, configureCommand, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, configureCommand, ct).ConfigureAwait(false);
        #endregion
    }
}
