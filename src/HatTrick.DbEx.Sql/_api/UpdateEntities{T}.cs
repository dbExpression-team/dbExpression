using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntities<TEntity>
#pragma warning restore IDE1006 // Naming Styles
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct a TOP clause for a sql UPDATE query expression to limit the number of <typeparamref name="TEntity"/> entities updated.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="value">The maximum number of records to update in the database.</param>
        /// <returns><see cref="UpdateEntities{TEntity}"/>, a fluent continuation for constructing a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.</returns>
        UpdateEntities<TEntity> Top(int value);

        /// <summary>
        /// Construct the FROM clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="UpdateEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.</returns>
        UpdateEntitiesContinuation<TEntity> From(Entity<TEntity> entity);
    }
}
