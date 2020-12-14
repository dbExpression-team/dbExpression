using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValue<TValue>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql">Microsoft docs on FROM</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectValueContinuation{TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a single <typeparamref name="TValue"/> value.</returns>
        SelectValueContinuation<TValue> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
