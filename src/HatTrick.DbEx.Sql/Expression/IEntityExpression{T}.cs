using HatTrick.DbEx.Sql.Executor;
using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IEntityExpression<T> : IEntityExpression
    {
        SelectExpressionSet BuildInclusiveSelectExpression();
        SelectExpressionSet BuildInclusiveSelectExpression(Func<string, string> alias);
        InsertExpressionSet<T> BuildInclusiveInsertExpression(T entity);
        AssignmentExpressionSet BuildAssignmentExpression(T from, T to);
        void HydrateEntity(ISqlFieldReader reader, T entity);
    }
}
