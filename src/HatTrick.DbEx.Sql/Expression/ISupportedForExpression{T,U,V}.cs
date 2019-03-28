using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForExpression<TExpression, TEntity, TValue> : ISupportedForExpression<TExpression, TEntity>
        where TExpression : IDbExpression
        where TEntity : IDbEntity
    {
    }
}
