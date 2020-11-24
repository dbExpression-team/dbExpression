using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntities<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        SelectEntities<TEntity> Top(int value);
        SelectEntities<TEntity> Distinct();
        SelectEntitiesContinuation<TEntity> From(Entity<TEntity> entity);
    }
}
