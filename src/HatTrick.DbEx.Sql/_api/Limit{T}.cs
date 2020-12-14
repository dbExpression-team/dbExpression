using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface Limit<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Specify the maximum number of records to return for a SELECT query expression.
        /// </summary>
        /// <remarks>If a Skip operation was specified for the SELECT query expression, the <paramref name="value"/> does not begin until after skipping/ignoring the number of records specified in the Skip operation.</remarks>
        /// <param name="value">The maximum number of records to return.</param>
        /// <returns><see cref="{TCaller}"/>, a fluent continuation for the construction of a sql SELECT query expression.</returns>
        TCaller Limit(int value);

        /// <summary>
        /// Construct the HAVING clause of a sql SELECT query expression.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/t-sql/queries/select-having-transact-sql">Microsoft docs on HAVING</see>
        /// </para>
        /// </summary>
        /// <param name="having">A list of expressions of type <see cref="AnyHavingClause"/> specifying conditions on the grouping or aggregation of selected results.</param>
        /// <returns><see cref="{TCaller}"/>, a fluent continuation for the construction of a sql SELECT query expression.</returns>
        TCaller Having(AnyHavingClause having);
    }
}
