using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface ISelectQueryExpressionExecutionPipeline
    {
        #region entity
        T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new();

        T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new();

        void ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            where T : class, IDbEntity, new();

        T ExecuteSelectEntity<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new();

        Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<T> ExecuteSelectEntityAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new();
        #endregion

        #region entity list
        IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand)
            where T : class, IDbEntity, new();

        IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new();

        void ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read)
            where T : class, IDbEntity, new();

        IList<T> ExecuteSelectEntityList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map)
            where T : class, IDbEntity, new();

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct)
            where T : class, IDbEntity, new();

        Task<IList<T>> ExecuteSelectEntityListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T, Task> map, CancellationToken ct)
            where T : class, IDbEntity, new();
        #endregion

        #region value
        T ExecuteSelectValue<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand);

        Task<T> ExecuteSelectValueAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct);
        #endregion

        #region value list
        IList<T> ExecuteSelectValueList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand);
        void ExecuteSelectValueList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<object> read);

        Task<IList<T>> ExecuteSelectValueListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct);
        Task ExecuteSelectValueListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<object> read, CancellationToken ct);
        Task ExecuteSelectValueListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<object, Task> read, CancellationToken ct);
        #endregion

        #region dynamic
        dynamic ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand);
        void ExecuteSelectDynamic(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read);

        Task<dynamic> ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct);
        Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken ct);
        Task ExecuteSelectDynamicAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct);
        #endregion

        #region dynamic list
        IList<dynamic> ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand);
        void ExecuteSelectDynamicList(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read);

        Task<IList<dynamic>> ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct);
        Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Action<ISqlFieldReader> read, CancellationToken ct);
        Task ExecuteSelectDynamicListAsync(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task> read, CancellationToken ct);
        #endregion

        #region object
        T ExecuteSelectObject<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map);

        Task<T> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct);
        Task<T> ExecuteSelectObjectAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task<T>> map, CancellationToken ct);
        #endregion

        #region object list
        IList<T> ExecuteSelectObjectList<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map);

        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, T> map, CancellationToken ct);
        Task<IList<T>> ExecuteSelectObjectListAsync<T>(SelectQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, Func<ISqlFieldReader, Task<T>> map, CancellationToken ct);
        #endregion
    }
}
