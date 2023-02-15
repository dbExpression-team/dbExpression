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
    public static partial class VersionBaseMsSqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element, long startSearchPosition)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)), new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a<see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element, int startSearchPosition)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)), new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element, AnyElement<int> startSearchPosition)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="expression"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element, AnyElement<long> startSearchPosition)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element, AnyElement<int?> startSearchPosition)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, string pattern, (string TableName, string FieldName) element, AnyElement<long?> startSearchPosition)
            => new(new NullableStringExpressionMediator(new LiteralExpression<string?>(pattern)), new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element, long startSearchPosition)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element, int startSearchPosition)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element, AnyElement<int> startSearchPosition)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element, AnyElement<long> startSearchPosition)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element, AnyElement<int?> startSearchPosition)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">An alias of the search pattern to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) pattern, AnyStringElement element, AnyElement<long?> startSearchPosition)
            => new(new NullableStringExpressionMediator(new AliasExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element, long startSearchPosition)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)), new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a<see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element, int startSearchPosition)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)), new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element, AnyElement<int> startSearchPosition)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="expression"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element, AnyElement<long> startSearchPosition)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element, AnyElement<int?> startSearchPosition)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex>read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element"An alias of the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyStringElement pattern, (string TableName, string FieldName) element, AnyElement<long?> startSearchPosition)
            => new(pattern, new NullableStringExpressionMediator(new AliasExpression<string?>(element)), startSearchPosition);
    }
}
