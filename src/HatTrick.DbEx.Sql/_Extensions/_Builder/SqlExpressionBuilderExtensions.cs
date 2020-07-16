using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
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
            var @base = builder as SqlExpressionBuilder ?? throw new DbExpressionConfigurationException($"The parameter '{nameof(builder)}' has type '{builder.GetType()}', the type must be assignable to type '{typeof(SqlExpressionBuilder)}'.");
            return @base.Configuration;
        }

        private static SyncExecutionPipeline CreateSyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateSyncExecutionPipeline();

        private static AsyncExecutionPipeline CreateAsyncExecutionPipeline(this ITerminationExpressionBuilder builder)
            => builder.GetDatabaseConfiguration().ExecutionPipelineFactory.CreateAsyncExecutionPipeline();

        #region InsertTerminationExpressionBuilder
        public static void Execute(this IInsertTerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, null, null);

        public static void Execute(this IInsertTerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, null, command => command.CommandTimeout = commandTimeout);

        public static void Execute(this IInsertTerminationExpressionBuilder builder, ISqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, null);

        public static void Execute(this IInsertTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, ISqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, ISqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, null,  ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IInsertTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region UpdateTerminationExpressionBuilder
        public static void Execute(this IUpdateTerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, null, null);

        public static void Execute(this IUpdateTerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, null, command => command.CommandTimeout = commandTimeout);

        public static void Execute(this IUpdateTerminationExpressionBuilder builder, ISqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, null);

        public static void Execute(this IUpdateTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, ISqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, ISqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IUpdateTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region DeleteTerminationExpressionBuilder
        public static void Execute(this IDeleteTerminationExpressionBuilder builder)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, null, null);

        public static void Execute(this IDeleteTerminationExpressionBuilder builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, null, command => command.CommandTimeout = commandTimeout);

        public static void Execute(this IDeleteTerminationExpressionBuilder builder, ISqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, null);

        public static void Execute(this IDeleteTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteVoid(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, ISqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, ISqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync(this IDeleteTerminationExpressionBuilder builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteVoidAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder<T>
        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, null, null);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : IComparable
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, null, command => command.CommandTimeout = commandTimeout);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : IComparable
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, connection, null);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteValue(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : IComparable
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder<T>
        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, null, null);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, null, command => command.CommandTimeout = commandTimeout);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, connection, null);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteValueList(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteValueListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder<ExpandoObject>
        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, null, null);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, null, command => command.CommandTimeout = commandTimeout);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, connection, null);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);



        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, null, null, map);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, null, command => command.CommandTimeout = commandTimeout, map);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, connection, null, map);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamic(builder, connection, command => command.CommandTimeout = commandTimeout, map);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, null, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, null, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, null, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicAsync(builder, connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder<ExpandoObject>
        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, null, null);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, null, command => command.CommandTimeout = commandTimeout);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, null);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);


        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow,T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, null, null, map);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, null, command => command.CommandTimeout = commandTimeout, map);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, null, map);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => builder.CreateSyncExecutionPipeline().ExecuteDynamicList(builder, connection, command => command.CommandTimeout = commandTimeout, map);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, null, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, null, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, null, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateAsyncExecutionPipeline().ExecuteDynamicListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region TypeTerminationExpressionBuilder
        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder) 
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, null, null);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, null, command => command.CommandTimeout = commandTimeout);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, connection, null);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteType(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region TypeListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, null, null);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, null, command => command.CommandTimeout = commandTimeout);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, connection, null);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.CreateSyncExecutionPipeline().ExecuteTypeList(builder, connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, null, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateAsyncExecutionPipeline().ExecuteTypeListAsync(builder, connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion
    }
}
