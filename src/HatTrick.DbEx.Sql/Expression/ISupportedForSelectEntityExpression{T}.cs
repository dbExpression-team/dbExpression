using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public interface ISupportedForSelectEntityExpression<TEntity> : ISupportedForSelectExpression
        where TEntity : IDbEntity
    {
    }
}
