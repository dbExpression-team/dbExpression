using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntities<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        UpdateEntities<TEntity> Top(int value);
        UpdateEntitiesContinuation<TEntity> From(Entity<TEntity> entity);
    }
}
