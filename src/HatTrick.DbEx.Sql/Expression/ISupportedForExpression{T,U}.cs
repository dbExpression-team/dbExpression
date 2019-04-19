using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForExpression<TExpression, TEntity> : ISupportedForExpression<TExpression>
        where TExpression : IDbExpression
        where TEntity : IDbEntity
    {
    }
}
