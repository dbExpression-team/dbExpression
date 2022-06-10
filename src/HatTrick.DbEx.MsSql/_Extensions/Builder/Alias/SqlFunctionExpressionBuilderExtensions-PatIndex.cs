#region license
// Copyright (c) HatTrick Labs, LLC.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// The latest version of this file can be found at https://github.com/HatTrickLabs/db-ex
#endregion

using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Expression;

namespace HatTrick.DbEx.MsSql.Builder.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> that contains the expression to be found in <paramref name="element"/>.</param>
        /// <param name="element">An alias of an expression to search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(this MsSqlFunctionExpressionBuilder _, string? pattern, (string TableName, string FieldName) element)
            => new(new LiteralExpression<string?>(pattern), new AliasExpression<long?>(element));

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of an expression that contains the expression to be found in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/> the expression to search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(this MsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, string? element)
            => new(new AliasExpression<string?>(pattern), new LiteralExpression<string?>(element));

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> that contains the expression to be found in <paramref name="element"/>.</param>
        /// <param name="element">An alias of an expression to search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(this MsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element)
            => new(pattern, new AliasExpression<string?>(element));

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> that contains the expression to be found in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/> the expression to search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(this MsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element)
            => new(new AliasExpression<string?>(pattern), element);

        /// <summary>
        /// Construct an expression for the PATINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/patindex-transact-sql">Microsoft docs on PATINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> that contains the expression to be found in <paramref name="element"/>.</param>
        /// <param name="element">An alias of an expression to search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64PatIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static NullableInt64PatIndexFunctionExpression PatIndex(this MsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, (string TableName, string FieldName) element)
            => new(new AliasExpression<string?>(pattern), new AliasExpression<string?>(element));
    }
}