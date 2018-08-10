using HTL.DbEx.Sql.Executor;

namespace HTL.DbEx.Sql.Expression
{
    public interface IDbExpressionEntity<T>
    {
        DBSelectExpressionSet GetInclusiveSelectExpression();

        DBInsertExpressionSet GetInclusiveInsertExpression(T entity);

        void FillObject(T entity, ResultSet.Row values);
    }
}
