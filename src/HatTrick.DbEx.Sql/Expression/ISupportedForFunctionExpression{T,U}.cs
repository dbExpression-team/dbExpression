using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForFunctionExpression<TFunction, TValue> : ISupportedForFunctionExpression<TFunction>
        where TFunction : IDbFunctionExpression
    {

    }
}
