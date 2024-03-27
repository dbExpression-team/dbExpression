#region license
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

using DbExpression.Sql;
using DbExpression.Sql.Expression;

using __ = DbExpression.MsSql.Builder.VersionBaseMsSqlFunctionExpressionBuilder;

namespace DbExpression.MsSql.Builder.Alias
{
    public static partial class VersionBaseMsSqlFunctionExpressionBuilderExtensions
    {
        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">An alias of an expresion that specifies the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), new AliasExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, int length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, int? length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int>(start), new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), start, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), start, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, long? length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">An alias of an expression that specifies the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, (string TableName, string FieldName) start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), new AliasExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), start, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, (string TableName, string FieldName) length)
            => new(new AliasExpression<string?>(expression), start, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, int length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int>(start), new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, int length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, long length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, long length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, long length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, long length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, int length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, int length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, int? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));


        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, int? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, int length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, int length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, int? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, int? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, long length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, long? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, long? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, long length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, long? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, long? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, long length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, long? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, long? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, long length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, long? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, long? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, int? start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<int?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, AnyElement<long> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int> start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int32}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<int?> start, AnyElement<long?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, int length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, int? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, int? length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, int length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, int? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">The number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, int? length)
            => new(new AliasExpression<string?>(expression), start, new LiteralExpression<long?>(length));

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">The start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int32}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, long? start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), new LiteralExpression<long?>(start), length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, AnyElement<int> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long> start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), start, length);

        /// <summary>
        /// Construct an expression for the SUBSTRING transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/string/substring">read the docs on SUBSTRING</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to take a portion of.</param>
        /// <param name="start">A <see cref="AnyElement{Int64}"/>?, the start position in <paramref name="expression"/> to start taking characters.</param>
        /// <param name="length">A <see cref="AnyElement{Int64}"/>?, the number of characters to take.</param>
        /// <returns><see cref="NullableStringSubstringFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringSubstringFunctionExpression Substring(this __ _, (string TableName, string FieldName) expression, AnyElement<long?> start, AnyElement<int?> length)
            => new(new AliasExpression<string?>(expression), start, length);
    }
}
