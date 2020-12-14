using HatTrick.DbEx.Sql.Expression;
using System.Collections.Generic;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface SelectValuesOrderByContinuation<TValue>
#pragma warning restore IDE1006 // Naming Styles
        : SelectValuesTermination<TValue>
    {
        /// <summary>
        /// Specify a number of records to ignore while reading before beginning to return records.
        /// </summary>
        /// <param name="value">The number of records to ignore.</param>
        /// <returns><see cref="SelectValuesSkipContinuation{TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValuesSkipContinuation<TValue> Skip(int value);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByClause"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectValuesOrderByContinuation{TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValuesOrderByContinuation<TValue> GroupBy(params AnyGroupByClause[] groupBy);

        /// <summary>
        /// Construct the GROUP BY clause of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql">Microsoft docs on GROUP BY</see>
        /// </para>
        /// </summary>
        /// <param name="groupBy">A list of expressions of type <see cref="AnyGroupByClause"/> specifying how to group the selected results.</param>
        /// <returns><see cref="SelectValuesOrderByContinuation{TValue}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValuesOrderByContinuation<TValue> GroupBy(IEnumerable<AnyGroupByClause> groupBy);

        /// <summary>
        /// Construct the HAVING clause of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-having-transact-sql">Microsoft docs on HAVING</see>
        /// </para>
        /// </summary>
        /// <param name="having">A list of expressions of type <see cref="AnyHavingClause"/> specifying conditions on the grouping or aggregation of selected results.</param>
        /// <returns><see cref="SelectValuesOrderByContinuation{TEntity}"/>, a fluent continuation for the construction of a sql SELECT query expression for a list of <typeparamref name="TValue"/> values.</returns>
        SelectValuesOrderByContinuation<TValue> Having(AnyHavingClause having);
    }
}
