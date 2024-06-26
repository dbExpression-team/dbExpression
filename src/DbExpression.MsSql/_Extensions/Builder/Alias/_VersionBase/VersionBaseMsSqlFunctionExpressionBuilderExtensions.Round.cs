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
using DbExpression.Sql.Expression;

namespace DbExpression.MsSql.Builder.Alias
{
    public static partial class VersionBaseMsSqlFunctionExpressionBuilderExtensions
    {
        #region object
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableObjectRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableObjectRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) expression, int length)
            => new(new AliasExpression<decimal?>(expression), new LiteralExpression<int>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableObjectRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableObjectRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) expression, int length, NullableNumericElement function)
            => new(new AliasExpression<decimal?>(expression), new LiteralExpression<int>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) expression, int? length)
            => new(new AliasExpression<decimal?>(expression), new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) expression, int? length, NullableNumericElement function)
            => new(new AliasExpression<decimal?>(expression), new LiteralExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">An alias of an expression to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, (string TableName, string FieldName) expression, int length, NumericElement function)
            => new(new AliasExpression<decimal?>(expression), new LiteralExpression<int>(length), function);
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{Byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{Byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, int? length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int?>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{decimal}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<decimal?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{Byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{Byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, int? length)
            => new(expression, new LiteralExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{double}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<double?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{short}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, int? length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int?>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{short}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<byte?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{Byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{Byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, int? length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int?>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{short}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<short?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{Byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{Byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, int? length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int?>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{int}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{int}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<int?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{Byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{Byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, int? length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int?>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{long}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{long}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<long?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, (string TableName, string FieldName) length)
            => new(expression, new AliasExpression<int?>(length));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, (string TableName, string FieldName) length, NullableNumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">A <see cref="NullableNumericElement" /> (one of <see cref="AnyElement{Byte}" />?, <see cref="AnyElement{short}" />?, <see cref="AnyElement{int}" />?, or <see cref="AnyElement{long}" />?), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, NullableNumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">A <see cref="NumericElement" /> (one of <see cref="AnyElement{Byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, NumericElement length, (string TableName, string FieldName) function)
            => new(expression, length, new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, int length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">An alias of an expression indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, int? length, (string TableName, string FieldName) function)
            => new(expression, new LiteralExpression<int?>(length), new AliasExpression<int?>(function));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href=https://dbexpression.com/rtd/reference/mssql/functions/mathematical/round">read the docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{float}"/>? to round.</param>
        /// <param name="length">An alias of an expression providing the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NumericElement" /> (one of <see cref="AnyElement{byte}" />, <see cref="AnyElement{short}" />, <see cref="AnyElement{int}" />, or <see cref="AnyElement{long}" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{float}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(this VersionBaseMsSqlFunctionExpressionBuilder _, AnyElement<float?> expression, (string TableName, string FieldName) length, NumericElement function)
            => new(expression, new AliasExpression<int?>(length), function);
        #endregion
    }
}