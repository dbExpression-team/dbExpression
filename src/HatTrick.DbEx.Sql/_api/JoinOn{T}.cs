using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.Sql
{
#pragma warning disable IDE1006 // Naming Styles
    public interface JoinOn<TCaller>
#pragma warning restore IDE1006 // Naming Styles
    {
        /// <summary>
        /// Specify the ON condition of a JOIN clause.
        /// <para>
        /// <see href="https://docs.microsoft.com/en-us/sql/relational-databases/performance/joins">Microsoft docs on JOINS</see>
        /// </para>
        /// </summary>
        /// <param name="joinOn">Any expression of type <see cref="AnyJoinOnClause"/> specifying the JOIN condition.</param>
        /// <returns><typeparamref name="TCaller"/>, a fluent continuation for the construction of a sql query expression.</returns>
        TCaller On(AnyJoinOnClause joinOn);
    }
}
