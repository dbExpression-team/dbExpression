using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface ISelectQueryExpressionExecutionPipeline
    {
        T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new();
        Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new();

        IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand)
            where T : class, IDbEntity, new();
        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new();

        T ExecuteSelectValue<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand);
        Task<T> ExecuteSelectValueAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct);

        IList<T> ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand);
        Task<IList<T>> ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct);

        dynamic ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand);
        Task<dynamic> ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct);

        IList<dynamic> ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand);
        Task<IList<dynamic>> ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, CancellationToken ct);

        T ExecuteSelectObject<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map);
        Task<T> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct);


        IList<T> ExecuteSelectObjectList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map);
        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<DbCommand> configureCommand, Func<ISqlRow, T> map, CancellationToken ct);
    }
}
