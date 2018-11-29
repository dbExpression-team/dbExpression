using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface IDbExpressionSelectClausePart : IDbExpression
    {
    }

    public interface IDbExpressionSelectClausePart<T> : IDbExpressionSelectClausePart
    {
    }
}
