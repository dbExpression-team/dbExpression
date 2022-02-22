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
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class MsSqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(string pattern, AnyElement<string> element)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new Int64CharIndexFunctionExpression(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(string pattern, AnyElement<string> element, long startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new Int64CharIndexFunctionExpression(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, new LiteralExpression<long>(startSearchPosition));
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(string pattern, AnyElement<string> element, int startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new Int64CharIndexFunctionExpression(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, new LiteralExpression<int>(startSearchPosition));
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(string pattern, AnyElement<string> element, AnyElement<int> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new Int64CharIndexFunctionExpression(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(string pattern, AnyElement<string> element, AnyElement<long> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new Int64CharIndexFunctionExpression(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(AnyElement<string> pattern, AnyElement<string> element)
            => new Int64CharIndexFunctionExpression(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(AnyElement<string> pattern, AnyElement<string> element, long startSearchPosition)
            => new Int64CharIndexFunctionExpression(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(AnyElement<string> pattern, AnyElement<string> element, int startSearchPosition)
            => new Int64CharIndexFunctionExpression(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(AnyElement<string> pattern, AnyElement<string> element, AnyElement<int> startSearchPosition)
            => new Int64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64CharIndexFunctionExpression CharIndex(AnyElement<string> pattern, AnyElement<string> element, AnyElement<long> startSearchPosition)
            => new Int64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, long startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, new LiteralExpression<long>(startSearchPosition));
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, int startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, new LiteralExpression<int>(startSearchPosition));
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<int> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="expression"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<long> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, StringElement element, AnyElement<int?> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, StringElement element, AnyElement<long?> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<int?> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<long?> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new NullableInt64CharIndexFunctionExpression(new LiteralExpression<string>(pattern), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element)
            => new NullableInt64CharIndexFunctionExpression(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, long startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a<see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, int startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<int> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="expression"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<long> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element, AnyElement<int?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element, AnyElement<long?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<int?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<long?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element)
            => new NullableInt64CharIndexFunctionExpression(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, NullableStringElement element)
            => new NullableInt64CharIndexFunctionExpression(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, NullableStringElement element, long startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, NullableStringElement element, int startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element, AnyElement<int> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, NullableStringElement element, AnyElement<int> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element, long startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element, AnyElement<long> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, NullableStringElement element, AnyElement<long> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element, int startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element, AnyElement<int?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element, AnyElement<long?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/charindex-transact-sql">Microsoft docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="NullableStringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="NullableStringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, NullableStringElement element, AnyElement<int?> startSearchPosition)
            => new NullableInt64CharIndexFunctionExpression(pattern, element, startSearchPosition);
    }
}
