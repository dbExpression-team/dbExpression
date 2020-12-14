using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface DeleteEntities
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Construct a TOP clause for a sql DELETE query expression to limit the number of entities deleted.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="value">The maximum number of records to select from the database.</param>
        /// <returns><see cref="DeleteEntities"/>, a fluent continuation for constructing a sql DELETE query expression.</returns>
        DeleteEntities Top(int value);

        /// <summary>
        /// Construct the FROM clause of a sql DELETE query expression for deleting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql">Microsoft docs on FROM</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The database representation of the entity, for example "dbo.<typeparamref name="TEntity"/>" when the entity is of type <typeparamref name="TEntity"/>.</param>
        /// <returns><see cref="DeleteEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql DELETE query expression for a list of <typeparamref name="TEntity"/> entities.</returns>
        DeleteEntitiesContinuation<TEntity> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
