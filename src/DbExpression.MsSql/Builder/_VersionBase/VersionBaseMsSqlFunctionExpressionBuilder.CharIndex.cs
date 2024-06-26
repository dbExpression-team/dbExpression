﻿#region license
// Copyright (c) dbExpression.  All rights reserved.
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
// The latest version of this file can be found at https://github.com/dbexpression-team/dbexpression
#endregion

using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.MsSql.Builder
{
    public partial class VersionBaseMsSqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(string pattern, StringElement element)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(string pattern, StringElement element, long startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, new LiteralExpression<long>(startSearchPosition));
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(string pattern, StringElement element, int startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, new LiteralExpression<int>(startSearchPosition));
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(string pattern, StringElement element, AnyElement<int> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(string pattern, StringElement element, AnyElement<long> startSearchPosition)
        {
            if (pattern is null)
                throw new ArgumentException($"{nameof(pattern)} cannot be null or empty.", nameof(pattern));
            return new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);
        }

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element)
            => new(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element, long startSearchPosition)
            => new(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element, int startSearchPosition)
            => new(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element, AnyElement<int> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="Int64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64CharIndexFunctionExpression CharIndex(StringElement pattern, StringElement element, AnyElement<long> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element)
            => new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, long startSearchPosition)
            => new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, int startSearchPosition)
            => new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<int> startSearchPosition)
            => new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="expression"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<long> startSearchPosition)
            => new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<int?> startSearchPosition)
            => new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(string pattern, NullableStringElement element, AnyElement<long?> startSearchPosition)
            =>  new(new StringExpressionMediator(new LiteralExpression<string>(pattern)), element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element)
            => new(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, long startSearchPosition)
            => new(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a<see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, int startSearchPosition)
            => new(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<int> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="expression"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<long> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<int?> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="StringElement"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(StringElement pattern, NullableStringElement element, AnyElement<long?> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, StringElement element)
            => new(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element)
            => new(pattern, element);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="string"/> to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element, long startSearchPosition)
            => new(pattern, element, new LiteralExpression<long>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="AnyElement{String}"/>? the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element, int startSearchPosition)
            => new(pattern, element, new LiteralExpression<int>(startSearchPosition));

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element, AnyElement<int> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element, AnyElement<long> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element, AnyElement<int?> startSearchPosition)
            => new(pattern, element, startSearchPosition);

        /// <summary>
        /// Construct an expression for the CHARINDEX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/charindex">read the docs on CHARINDEX</see></para>
        /// </summary>
        /// <param name="pattern">A <see cref="AnyElement{String}"/>? to search for in <paramref name="element"/>.</param>
        /// <param name="element">A <see cref="StringElement"/> the expression to search.</param>
        /// <param name="startSearchPosition">Where in <paramref name="element"/> to begin the search for <paramref name="pattern"/>.</param>
        /// <returns><see cref="NullableInt64CharIndexFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64CharIndexFunctionExpression CharIndex(NullableStringElement pattern, AnyStringElement element, AnyElement<long?> startSearchPosition)
            => new(pattern, element, startSearchPosition);
    }
}
