using HatTrick.DbEx.Sql.Executor;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IEntityExpression<T> : IEntityExpression
    {
        SelectExpressionSet BuildInclusiveSelectExpression();
        InsertExpressionSet<T> BuildInclusiveInsertExpression(T entity);
        AssignmentExpressionSet BuildAssignmentExpression(T from, T to);
        void HydrateEntity(T entity, ISqlFieldReader reader);
    }
}
