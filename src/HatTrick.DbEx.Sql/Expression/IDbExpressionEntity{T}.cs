using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionEntity<T>
    {
        SelectExpressionSet BuildInclusiveSelectExpression();

        InsertExpressionSet BuildInclusiveInsertExpression(T entity);

        AssignmentExpressionSet BuildAssignmentExpression(T from, T to);

        void HydrateEntity(T entity, ISqlFieldReader reader, IValueMapper valueMapper);

    }
}
