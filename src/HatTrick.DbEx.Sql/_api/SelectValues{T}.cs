using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValues<TValue>
#pragma warning restore IDE1006 // Naming Styles
    {
        SelectValues<TValue> Top(int value);
        SelectValues<TValue> Distinct();
        SelectValuesContinuation<TValue> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
