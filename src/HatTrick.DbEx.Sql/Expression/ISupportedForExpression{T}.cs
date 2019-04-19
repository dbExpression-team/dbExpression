using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForExpression<TExpression> : IDbExpression
        where TExpression : IDbExpression
    {
    }

}
