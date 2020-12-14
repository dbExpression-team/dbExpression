using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectEntity<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql">Microsoft docs on FROM</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a <typeparamref name="TEntity"/> entity.</returns>
        SelectEntityContinuation<TEntity> From(Entity<TEntity> entity);
    }
}
