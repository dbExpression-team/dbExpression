using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface IUpdateQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        int ExecuteUpdate(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand);
        Task<int> ExecuteUpdateAsync(UpdateQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct);
    }
}
