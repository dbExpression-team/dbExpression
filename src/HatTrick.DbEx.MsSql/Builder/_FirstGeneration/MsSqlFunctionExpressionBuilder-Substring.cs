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
    public partial class FirstGenerationMsSqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, int start, int length)
            => new(expression, new LiteralExpression<int>(start), new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, int length)
            => new(expression, start, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, int start, AnyElement<int> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, long start, long length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, long start, AnyElement<long> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, int start, long length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, int start, AnyElement<long> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, long start, int length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, int length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, long start, AnyElement<int> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="StringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual StringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, int? length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));


        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int start, int? length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, int length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, int length)
            => new(expression, start, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, int? length)
            => new(expression, start, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, int? length)
            => new(expression, start, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, AnyElement<int> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, long length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long start, long? length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, long? length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, AnyElement<long> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, long length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int start, long? length)
            => new(expression, new LiteralExpression<int>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, long? length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, int? start, AnyElement<long> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<int?> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, int length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long start, int? length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, int? length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, int length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, int? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, int? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, AnyElement<int> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, long? start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="StringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="StringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(StringElement expression, AnyElement<long?> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, int? length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));


        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, int? length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, int length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, int length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, int length)
            => new(expression, start, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, int length)
            => new(expression, start, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, int? length)
            => new(expression, start, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, int? length)
            => new(expression, start, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, AnyElement<int> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, AnyElement<int> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, long length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, long length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, long? length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, long? length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, AnyElement<long> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, AnyElement<long> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, long length)
            => new(expression, new LiteralExpression<int>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, long length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, long? length)
            => new(expression, new LiteralExpression<int>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, long? length)
            => new(expression, new LiteralExpression<int?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, long length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, long? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, AnyElement<long> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int start, AnyElement<long?> length)
            => new(expression, new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, int? start, AnyElement<long> length)
            => new(expression, new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, AnyElement<long> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<int?> start, AnyElement<long?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, int length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, int length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, int? length)
            => new(expression, new LiteralExpression<long>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, int? length)
            => new(expression, new LiteralExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, int length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, int length)
            => new(expression, start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, int? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, int? length)
            => new(expression, start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, AnyElement<int> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, AnyElement<int> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, long? start, AnyElement<int?> length)
            => new(expression, new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, AnyElement<int> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long> start, AnyElement<int?> length)
            => new(expression, start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/substring-transact-sql">Microsoft docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="NullableStringElement"/> to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public virtual NullableStringSubstringFunctionExpression Substring(NullableStringElement expression, AnyElement<long?> start, AnyElement<int?> length)
            => new(expression, start, length);
    }
}
