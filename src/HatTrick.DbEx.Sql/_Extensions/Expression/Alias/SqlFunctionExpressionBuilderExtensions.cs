using HatTrick.DbEx.Sql.Builder;
using System;

namespace HatTrick.DbEx.Sql.Expression.Alias
{
    public static class SqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/left-transact-sql">Microsoft docs on LEFT</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref=Int32"/> providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringLeftFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>?.</returns>
        public static NullableStringLeftFunctionExpression Left(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) alias, int characterCount)
            => new(new NullableStringExpressionMediator(new AliasExpression<string?>(alias.TableName, alias.FieldName)), new LiteralExpression<int>(characterCount));

        /// <summary>
        /// Construct an expression for the LEFT transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/left-transact-sql">Microsoft docs on LEFT</see></para>
        /// </summary>
        /// <param name="alias">An alias of an expression to take the number of characters from.</param>
        /// <param name="characterCount">An expression of type <see cref="AnyElement{Int32}"/> providing the number of characters to return from the left of <paramref name="element"/>.</param>
        /// <returns><see cref="NullableStringLeftFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>?.</returns>
        public static NullableStringLeftFunctionExpression Left(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) alias, AnyElement<int> characterCount)
            => new(new NullableStringExpressionMediator(new AliasExpression<string?>(alias.TableName, alias.FieldName)), characterCount);
    }
}
