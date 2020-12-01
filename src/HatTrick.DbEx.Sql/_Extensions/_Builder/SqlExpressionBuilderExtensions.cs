using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Configuration;
using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using HatTrick.DbEx.Sql.Pipeline;
using System;
using System.Collections.Generic;
using System.Data;
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
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                builder.ExecutePipeline(connection, null);
        }

        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        public static void Execute<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
        {
            using (var connetion = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connetion, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
           where T : class, IDbEntity
             => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task ExecuteAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region UpdateTerminationExpressionBuilder
        public static int Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static int Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static int Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        public static int Execute<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, CancellationToken ct)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, int commandTimeout)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region DeleteTerminationExpressionBuilder
        public static int Execute<T>(this DeleteEntitiesTermination<T> builder)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static int Execute<T>(this DeleteEntitiesTermination<T> builder, int commandTimeout)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static int Execute<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, null);

        public static int Execute<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, CancellationToken ct)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, int commandTimeout)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<int> ExecuteAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder<T>
        public static T Execute<T>(this SelectValueTermination<T> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static T Execute<T>(this SelectValueTermination<T> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static T Execute<T>(this SelectValueTermination<T> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static T Execute<T>(this SelectValueTermination<T> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder<T>
        public static IList<T> Execute<T>(this SelectValuesTermination<T> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static IList<T> Execute<T>(this SelectValuesTermination<T> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static IList<T> Execute<T>(this SelectValuesTermination<T> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static IList<T> Execute<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region ValueTerminationExpressionBuilder<ExpandoObject>
        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }


        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static dynamic Execute(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<dynamic> ExecuteAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);



        public static T Execute<T>(this SelectValueTermination<ExpandoObject> builder, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null, map);
        }

        public static T Execute<T>(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);
        }

        public static T Execute<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, null, map);

        public static T Execute<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, Func<ISqlRow, T> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region ValueListTerminationExpressionBuilder<ExpandoObject>
        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection)
            => builder.ExecutePipeline(connection, null);

        public static IList<dynamic> Execute(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection)
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<dynamic>> ExecuteAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);


        public static IList<T> Execute<T>(this SelectValuesTermination<ExpandoObject> builder, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null, map);
        }

        public static IList<T> Execute<T>(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);
        }

        public static IList<T> Execute<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, null, map);

        public static IList<T> Execute<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout, map);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, null, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, Func<ISqlRow, T> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, null, map, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, int commandTimeout, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, map, ct).ConfigureAwait(false);
        #endregion

        #region TypeTerminationExpressionBuilder
        public static T Execute<T>(this SelectEntityTermination<T> builder)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static T Execute<T>(this SelectEntityTermination<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static T Execute<T>(this SelectEntityTermination<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, null);

        public static T Execute<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<T> ExecuteAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region TypeListTerminationExpressionBuilder
        public static IList<T> Execute<T>(this SelectEntitiesTermination<T> builder)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, null);
        }

        public static IList<T> Execute<T>(this SelectEntitiesTermination<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);
        }

        public static IList<T> Execute<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, null);

        public static IList<T> Execute<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => builder.ExecutePipeline(connection, command => command.CommandTimeout = commandTimeout);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, int commandTimeout)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, int commandTimeout)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, CancellationToken.None).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);
        }
        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
        {
            using (var connection = new SqlConnector(builder.GetDatabaseConfiguration().ConnectionFactory))
                return await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        }

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, null, ct).ConfigureAwait(false);

        public static async Task<IList<T>> ExecuteAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, int commandTimeout, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.ExecutePipelineAsync(connection, command => command.CommandTimeout = commandTimeout, ct).ConfigureAwait(false);
        #endregion

        #region insert
        private static void ExecutePipeline<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
           where T : class, IDbEntity
           => builder.CreateInsertExecutionPipeline<T>().ExecuteInsert(builder.GetQueryExpression<InsertQueryExpression>(), connection, configureCommand);

        private static async Task ExecutePipelineAsync<T>(this IInsertTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
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
        private static int ExecutePipeline<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity
            => builder.CreateUpdateExecutionPipeline<T>().ExecuteUpdate(builder.GetQueryExpression<UpdateQueryExpression>(), connection, configureCommand);

        private static async Task<int> ExecutePipelineAsync<T>(this IUpdateTerminationExpressionBuilder<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
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
        private static int ExecutePipeline<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity
            => builder.CreateDeleteExecutionPipeline<T>().ExecuteDelete(builder.GetQueryExpression<DeleteQueryExpression>(), connection, configureCommand);

        private static async Task<int> ExecutePipelineAsync<T>(this DeleteEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
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
        private static T ExecutePipeline<T>(this SelectValueTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValue<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectValueTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectValuesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectValueListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static dynamic ExecutePipeline(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamic(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<dynamic> ExecutePipelineAsync(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<dynamic> ExecutePipeline(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            => builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<dynamic>> ExecutePipelineAsync(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<dynamic>().ExecuteSelectDynamicListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static T ExecutePipeline<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObject(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectValueTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map)
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectList(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectValuesTermination<ExpandoObject> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct)
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectObjectListAsync(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, map, ct).ConfigureAwait(false);

        private static T ExecutePipeline<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntity<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<T> ExecutePipelineAsync<T>(this SelectEntityTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false);

        private static IList<T> ExecutePipeline<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new()
            => builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityList<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand);

        private static async Task<IList<T>> ExecutePipelineAsync<T>(this SelectEntitiesTermination<T> builder, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new()
            => await builder.CreateSelectExecutionPipeline<T>().ExecuteSelectEntityListAsync<T>(builder.GetQueryExpression<SelectQueryExpression>(), connection, configureCommand, ct).ConfigureAwait(false); 
        
        private static ISelectQueryExpressionExecutionPipeline CreateSelectExecutionPipeline<T>(this ITerminationExpressionBuilder builder)
        {
            var config = builder.GetDatabaseConfiguration();
            return config.ExecutionPipelineFactory?.CreateExecutionPipeline(config, builder.GetQueryExpression<SelectQueryExpression>()) ?? throw new DbExpressionConfigurationException($"Could not resolve/create an execution pipeline for type '{builder.GetType()}',  please review and ensure the correct configuration for DbExpression.");
        }
        #endregion

        #region get database configuration
        private static RuntimeSqlDatabaseConfiguration GetDatabaseConfiguration(this ITerminationExpressionBuilder builder)
        {
            return builder.Configuration ?? throw new DbExpressionConfigurationException($"Database configuration is required, please review and ensure the correct configuration for DbExpression.");
        }
        #endregion

        #region get query expression
        private static T GetQueryExpression<T>(this ITerminationExpressionBuilder builder)
            where T : QueryExpression
        {
            return builder.Expression as T ?? throw new DbExpressionConfigurationException($"Query expression is type '{builder.Expression.GetType()}', the type was expected to be the requested type of '{typeof(T)}'.");
        }
        #endregion
    }
}
