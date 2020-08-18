using HatTrick.DbEx.Sql.Executor;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionEntity<T> : IExpressionEntity
    {
        InsertExpressionSet<T> BuildInclusiveInsertExpression(T entity);
        AssignmentExpressionSet BuildAssignmentExpression(T from, T to);
        void HydrateEntity(T entity, ISqlFieldReader reader);
    }
}
