using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValues<TValue>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Construct a TOP clause for a sql SELECT query expression to limit the number of <typeparamref name="TValue"/> values selected.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <param name="value">The maximum number of records to select from the database.</param>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent continuation for constructing a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValues<TValue> Top(int value);

        /// <summary>
        /// Construct a DISTINCT clause for a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-US/sql/t-sql/queries/select-transact-sql">Microsoft docs on SELECT</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectValues{TValue}"/>, a fluent continuation for constructing a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValues<TValue> Distinct();

        /// <summary>
        /// Construct the FROM clause of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/from-transact-sql">Microsoft docs on FROM</see>
        /// </para>
        /// </summary>
        /// <returns><see cref="SelectEntitiesContinuation{TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValuesContinuation<TValue> From<TEntity>(Entity<TEntity> entity)
            where TEntity : class, IDbEntity;
    }
}
