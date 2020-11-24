using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntity<TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        IContinuationExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        InsertEntityTermination<TEntity> Into<U>(U entity)
            where U : EntityExpression<TEntity>;
    }
}
