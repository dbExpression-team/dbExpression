using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JoinOnWithAlias<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Specify an alias of a JOIN clause.
        /// <para>
        /// Use the <paramref name="alias"/> value from this operation as the 'tableName' parameter when creating an <see cref="AliasExpression"/> 
        /// (for the joined sql SELECT query expression) for use with outer expressions:
        /// <code>db.alias({tableName}, {fieldName})</code>
        /// </para>
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="alias">The alias to apply to the JOIN clause.</param>
        /// <returns><typeparamref name="TCaller"/>, a fluent continuation for the construction of a sql query expression.</returns>
        JoinOn<TCaller> As(string alias);
    }
}
