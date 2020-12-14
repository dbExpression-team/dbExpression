namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface UpdateEntities
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Construct a TOP clause for a sql UPDATE query expression to limit the number of records updated.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <param name="value">The maximum number of records to update in the database.</param>
        /// <returns><see cref="UpdateEntities"/>, a fluent continuation for constructing a sql UPDATE query expression for updating records.</returns>
        UpdateEntities Top(int value);

        /// <summary>
        /// Construct the FROM clause of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/update-transact-sql">Microsoft docs on UPDATE</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="UpdateEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql UPDATE query expression for updating <typeparamref name="TEntity"/> entities.</returns>
        UpdateEntitiesContinuation<TEntity> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
