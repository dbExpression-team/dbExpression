using HatTrick.DbEx.Sql.Connection;
using HatTrick.DbEx.Sql.Expression;
using System;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface IInsertQueryExpressionExecutionPipeline<T>
        where T : class, IDbEntity
    {
        void ExecuteInsert(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand);
        Task ExecuteInsertAsync(InsertQueryExpression expression, ISqlConnection connection, Action<IDbCommand> configureCommand, CancellationToken ct);
    }
}
