using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValue<TValue>
#pragma warning restore IDE1006 // Naming Styles
    {
        SelectValueContinuation<TValue> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
