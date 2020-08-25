using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql
{
    public static class SqlExpressionBuilderExtensions
    {
        #region InsertTerminationExpressionBuilder
        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
            => builder.ExecutePipeline(null, null);

        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
           where T : class, IDbEntity
             => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region UpdateTerminationExpressionBuilder
        public static int Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
            => builder.ExecutePipeline(null, null);

        public static void Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static void Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        public static void Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region DeleteTerminationExpressionBuilder
        public static int Execute<T>(this IDeleteTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
            => builder.ExecutePipeline(null, null);

        public static int Execute<T>(this IDeleteTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static int Execute<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        public static int Execute<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder<T>
        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder)
            => builder.ExecutePipeline(null, null);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : IComparable
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : IComparable
            => builder.ExecutePipeline(connection, null);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder)
            where T : IComparable
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : IComparable
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : IComparable
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : IComparable
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : IComparable
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : IComparable
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : IComparable
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder<T>
        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => builder.ExecutePipeline(null, null);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder)
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder<ExpandoObject>
        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.ExecutePipeline(null, null);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static dynamic Execute(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);



        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(null, null, map);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout, map);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, null, map);

        public static T Execute<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(null, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, null, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder<ExpandoObject>
        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => builder.ExecutePipeline(null, null);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static IList<dynamic> Execute(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder)
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);


        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow,T> map)
            => builder.ExecutePipeline(null, null, map);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout, map);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, null, map);

        public static IList<T> Execute<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(null, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, null, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region TypeTerminationExpressionBuilder
        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder) 
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(null, null);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, null);

        public static T Execute<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region TypeListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(null, null);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(null, command => command.CommandTimeout = commandTimeout);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, null);

        public static IList<T> Execute<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(null, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region insert
        private static void ExecutePipeline<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
           where T : class, IDbEntity
           => builder.CreateInsertExecutionPipeline<T>().ExecuteInsert(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand);

        private static async Task ExecutePipelineAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.CreateInsertExecutionPipeline<T>().ExecuteInsertAsync(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IInsertQueryExpressionExecutionPipeline<T> CreateInsertExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<InsertQueryExpression>());
        }
        #endregion

        #region update
        private static int ExecutePipeline<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity
            => builder.CreateUpdateExecutionPipeline<T>().ExecuteUpdate(builder.GetQueryExpression<UpdateQueryExpression>(), connection, configureCommand);

        private static async Task<int> ExecutePipelineAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.CreateUpdateExecutionPipeline<T>().ExecuteUpdateAsync(builder.GetQueryExpression<UpdateQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IUpdateQueryExpressionExecutionPipeline<T> CreateUpdateExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<UpdateQueryExpression>());
        }
        #endregion

        #region delete
        private static int ExecutePipeline<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity
            => builder.CreateDeleteExecutionPipeline<T>().ExecuteDelete(builder.GetQueryExpression<DeleteQueryExpression>(), connection, configureCommand);

        private static async Task<int> ExecutePipelineAsync<T>(this IDeleteTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.CreateDeleteExecutionPipeline<T>().ExecuteDeleteAsync(builder.GetQueryExpression<DeleteQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IDeleteQueryExpressionExecutionPipeline<T> CreateDeleteExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
            where T : class, IDbEntity
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory.CreateExecutionPipeline<T>(config, builder.GetQueryExpression<DeleteQueryExpression>());
        }
        #endregion

        #region select
        private static T ExecutePipeline<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValue<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this IValueTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this IValueListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static dynamic ExecutePipeline(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamic(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<dynamic> ExecutePipelineAsync(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<dynamic> ExecutePipeline(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<dynamic>> ExecutePipelineAsync(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static T ExecutePipeline<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObject(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<T> ExecutePipelineAsync<T>(this IValueTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this IValueListTerminationExpressionBuilder<ExpandoObject> builder, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, ct).ConfigureAwait(false);

        private static T ExecutePipeline<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this ITypeTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this ITypeListTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false); 
        
        private static ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory?.CreateExecutionPipeline(config, builder.GetQueryExpression<SelectQueryExpression>()) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{builder.GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion

        private static RuntimeSqlDatabaseConfiguration GetDatabaseConfiguration(this ITerminationExpressionBuilder builder)
        {
            var concrete = builder as QueryExpressionBuilder ?? throw new DbExpressionConfigurationException($"The parameter '{nameof(builder)}' has type '{builder}', the type must be assignable to type '{typeof(QueryExpressionBuilder)}'.");
            return concrete.Configuration ?? throw new DbExpressionConfigurationException($"Database configuration is required, please review and ensure the correct configuration for DbExpression.");
        }

        private static T GetQueryExpression<T>(this ITerminationExpressionBuilder builder)
            where T : QueryExpression
        {
            var provider = builder as IQueryExpressionProvider ?? throw new DbExpressionConfigurationException($"The parameter '{nameof(builder)}' must be assignable to type '{typeof(IQueryExpressionProvider)}'.");
            return provider.Expression as T ?? throw new DbExpressionConfigurationException($"Query expression is type '{provider.Expression}', the type was expected to be the requested type of '{typeof(T)}'.");
        }
    }
}
