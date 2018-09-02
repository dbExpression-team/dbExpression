using HatTrick.DbEx.Sql.Executor;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionEntity<T>
    {
        SelectExpressionSet GetInclusiveSelectExpression();

        InsertExpressionSet GetInclusiveInsertExpression(T entity);

        void FillObject(T entity, SqlStatementExecutionResultSet.Row values);
    }
}
