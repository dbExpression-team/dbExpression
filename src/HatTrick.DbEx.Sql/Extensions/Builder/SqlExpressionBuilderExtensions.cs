using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Extensions.Builder
{
    public static class SqlExpressionBuilderExtensions
    {
        private static DatabaseConfiguration GetDatabaseConfiguration(this ITerminationExpressionBuilder builder)
        {
            var dbName = ((builder as IDbExpressionSetProvider).Expression.BaseEntity as IDbExpressionMetadataProvider<ISqlEntityMetadata>).Metadata.Schema.Database.Name;
            return DbExpression.Configuration.Databases[dbName];
        }

        private static SyncExecutionPipeline CreateSyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateSyncExecutionPipeline();

        private static AsyncExecutionPipeline CreateAsyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline();

        #region TerminationExpressionBuilder
        public static void Execute(this ITerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static void Execute(this ITerminationExpressionBuilder builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this ITerminationExpressionBuilder builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion


        #region ValueTerminationExpressionBuilder
        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder) 
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder
        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().Execute<ExpandoObject>(builder);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute<ExpandoObject>(builder, connection);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder
        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, SqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion

        #region TypeTerminationExpressionBuilder
        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder) 
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion

        #region TypeListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().Execute(builder, connection);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, SqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteAsync(builder, connection, ct).ConfigureAwait(false);
        #endregion
    }
}
