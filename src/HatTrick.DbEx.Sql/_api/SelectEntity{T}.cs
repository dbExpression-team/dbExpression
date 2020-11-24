using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntity<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        SelectEntityContinuation<TEntity> From(Entity<TEntity> entity);
    }
}
