using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
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

            return DbExpression.Configuration.Databases[dbName];
        }

        private static SyncExecutionPipeline CreateSyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateSyncExecutionPipeline();

        private static AsyncExecutionPipeline CreateAsyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline();

        #region InsertTerminationExpressionBuilder
        public static void Execute(this IInsertTerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder);

        public static void Execute(this IInsertTerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, commandTimeout);

        public static void Execute(this IInsertTerminationExpressionBuilder builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection);

        public static void Execute(this IInsertTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, commandTimeout);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region UpdateTerminationExpressionBuilder
        public static void Execute(this IUpdateTerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder);

        public static void Execute(this IUpdateTerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, commandTimeout);

        public static void Execute(this IUpdateTerminationExpressionBuilder builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection);

        public static void Execute(this IUpdateTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, commandTimeout);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region DeleteTerminationExpressionBuilder
        public static void Execute(this IDeleteTerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder);

        public static void Execute(this IDeleteTerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, commandTimeout);

        public static void Execute(this IDeleteTerminationExpressionBuilder builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection);

        public static void Execute(this IDeleteTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, commandTimeout);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder
        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : IComparable
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, commandTimeout);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : IComparable
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, connection);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, connection, commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, connection).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, commandTimeout);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, connection);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, connection, commandTimeout);

        public static void Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, Action<T> onValueMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, onValueMaterialized);

        public static void Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onValueMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, commandTimeout, onValueMaterialized);

        public static void Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onValueMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, connection, onValueMaterialized);

        public static void Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onValueMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, connection, commandTimeout, onValueMaterialized);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, Action<T> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, commandTimeout, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, commandTimeout, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct, Action<T> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onValueMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, commandTimeout, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onValueMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onValueMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, commandTimeout, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, Func<T, Task> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, commandTimeout, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, commandTimeout, onValueMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct, Func<T, Task> onValueMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onValueMaterialized, CancellationToken ct)
           => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, commandTimeout, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, onValueMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onValueMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, commandTimeout, onValueMaterialized, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder-dynamic
        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, commandTimeout);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, connection);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, connection, commandTimeout);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder-dynamic
        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, commandTimeout);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, commandTimeout);

        public static void Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, onDynamicMaterialized);

        public static void Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, commandTimeout, onDynamicMaterialized);

        public static void Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, onDynamicMaterialized);

        public static void Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, commandTimeout, onDynamicMaterialized);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, commandTimeout, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, commandTimeout, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, commandTimeout, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Action<ExpandoObject> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, commandTimeout, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, commandTimeout, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, commandTimeout, onDynamicMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, commandTimeout, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, onDynamicMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, int commandTimeout, Func<ExpandoObject, Task> onDynamicMaterialized, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, commandTimeout, onDynamicMaterialized, ct).ConfigureAwait(false);
        #endregion

        #region TypeTerminationExpressionBuilder
        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder) 
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, commandTimeout);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, connection);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, connection, commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region TypeListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, commandTimeout);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, connection);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, connection, commandTimeout);

        public static void Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, onEntityMaterialized);

        public static void Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, commandTimeout, onEntityMaterialized);

        public static void Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, connection, onEntityMaterialized);

        public static void Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, connection, commandTimeout, onEntityMaterialized);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, commandTimeout).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, commandTimeout, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, commandTimeout, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, commandTimeout, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Action<T> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, commandTimeout, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, commandTimeout, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onEntityMaterialized)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, commandTimeout, onEntityMaterialized).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, commandTimeout, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, onEntityMaterialized, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, int commandTimeout, Func<T, Task> onEntityMaterialized, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, commandTimeout, onEntityMaterialized, ct).ConfigureAwait(false);
        #endregion
    }
}
