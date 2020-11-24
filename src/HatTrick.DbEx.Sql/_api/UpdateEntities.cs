using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntities
#pragma warning restore IDE1006 // Naming Styles
    {
        UpdateEntities Top(int value);
        UpdateEntitiesContinuation<TEntity> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
