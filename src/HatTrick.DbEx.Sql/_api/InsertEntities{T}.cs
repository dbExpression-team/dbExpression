using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface InsertEntities<TEntity> :
#pragma warning restore IDE1006 // Naming Styles
        IContinuationExpressionBuilder<TEntity>
        where TEntity : class, IDbEntity
    {
        /// <summary>
        /// Construct the INTO clause of a sql INSERT query expression for inserting <typeparamref name="TEntity"/> entities.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/statements/insert-transact-sql">Microsoft docs on INSERT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="InsertEntitiesTermination{TEntity}"/>, a fluent continuation for the construction of a sql INSERT query expression for inserting <typeparamref name="TEntity"/> entities.</returns>
        InsertEntitiesTermination<TEntity> Into(Entity<TEntity> entity);
    }
}
