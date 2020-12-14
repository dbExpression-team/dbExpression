using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntity<TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        IContinuationExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the INTO clause of a sql INSERT query expression for inserting a <typeparamref name="TEntity"/> entity.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <param name="entity">The database representation of the entity, for example "dbo.<typeparamref name="TEntity"/>" when the entity is of type <typeparamref name="TEntity"/>.</param>
        /// <returns><see cref="InsertEntityTermination{TEntity}"/>, a fluent continuation for the construction of a sql INSERT query expression for inserting a <typeparamref name="TEntity"/> entity.</returns>
        InsertEntityTermination<TEntity> Into(Entity<TEntity> entity);
    }
}
