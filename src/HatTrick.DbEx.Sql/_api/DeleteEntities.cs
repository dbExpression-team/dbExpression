using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface DeleteEntities
#pragma warning restore IDE1006 // Naming Styles
    {
        DeleteEntities Top(int value);
        DeleteEntitiesContinuation<TEntity> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
