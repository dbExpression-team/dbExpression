using HatTrick.DbEx.Sql.Executor;
using HatTrick.DbEx.Sql.Mapper;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IExpressionEntity<T> : IExpressionEntity
    {

        InsertExpressionSet<T> BuildInclusiveInsertExpression(T entity);

        AssignmentExpressionSet BuildAssignmentExpression(T from, T to);

        void HydrateEntity(T entity, ISqlFieldReader reader, IValueMapper valueMapper);
    }
}
