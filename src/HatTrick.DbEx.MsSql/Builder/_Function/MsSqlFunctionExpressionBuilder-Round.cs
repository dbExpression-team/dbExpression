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
        #region decimal
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Decimal}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, int length)
            => new DecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Decimal}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, int length, int function)
            => new DecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Decimal}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, IntegralNumericElement length)
            => new DecimalRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Decimal}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, IntegralNumericElement length, int function)
            => new DecimalRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Decimal}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, int length, IntegralNumericElement function)
            => new DecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Decimal}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalRoundFunctionExpression Round(AnyElement<decimal> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new DecimalRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length)
            => new NullableDecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length, int function)
            => new NullableDecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, IntegralNumericElement length)
            => new NullableDecimalRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableIntegralNumericElement length)
            => new NullableDecimalRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, IntegralNumericElement length, int function)
            => new NullableDecimalRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableIntegralNumericElement length, int function)
            => new NullableDecimalRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length, IntegralNumericElement function)
            => new NullableDecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, int length, NullableIntegralNumericElement function)
            => new NullableDecimalRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new NullableDecimalRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableIntegralNumericElement length, IntegralNumericElement function)
            => new NullableDecimalRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, IntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableDecimalRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<decimal?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDecimalRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalRoundFunctionExpression Round(AnyElement<decimal?> expression, NullableIntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableDecimalRoundFunctionExpression(expression, length, function);
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Double}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleRoundFunctionExpression Round(AnyElement<double> expression, int length)
            => new DoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Double}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleRoundFunctionExpression Round(AnyElement<double> expression, int length, int function)
            => new DoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Double}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleRoundFunctionExpression Round(AnyElement<double> expression, IntegralNumericElement length)
            => new DoubleRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Double}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleRoundFunctionExpression Round(AnyElement<double> expression, IntegralNumericElement length, int function)
            => new DoubleRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Double}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleRoundFunctionExpression Round(AnyElement<double> expression, int length, IntegralNumericElement function)
            => new DoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Double}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="DoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleRoundFunctionExpression Round(AnyElement<double> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new DoubleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length)
            => new NullableDoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length, int function)
            => new NullableDoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, IntegralNumericElement length)
            => new NullableDoubleRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableIntegralNumericElement length)
            => new NullableDoubleRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, IntegralNumericElement length, int function)
            => new NullableDoubleRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableIntegralNumericElement length, int function)
            => new NullableDoubleRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length, IntegralNumericElement function)
            => new NullableDoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, int length, NullableIntegralNumericElement function)
            => new NullableDoubleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new NullableDoubleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableIntegralNumericElement length, IntegralNumericElement function)
            => new NullableDoubleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, IntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableDoubleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<double?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableDoubleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleRoundFunctionExpression Round(AnyElement<double?> expression, NullableIntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableDoubleRoundFunctionExpression(expression, length, function);
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int16}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16RoundFunctionExpression Round(AnyElement<short> expression, int length)
            => new Int16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int16}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16RoundFunctionExpression Round(AnyElement<short> expression, int length, int function)
            => new Int16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int16}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16RoundFunctionExpression Round(AnyElement<short> expression, IntegralNumericElement length)
            => new Int16RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int16}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16RoundFunctionExpression Round(AnyElement<short> expression, IntegralNumericElement length, int function)
            => new Int16RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int16}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16RoundFunctionExpression Round(AnyElement<short> expression, int length, IntegralNumericElement function)
            => new Int16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int16}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16RoundFunctionExpression Round(AnyElement<short> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new Int16RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, int length)
            => new NullableInt16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, int length, int function)
            => new NullableInt16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, IntegralNumericElement length)
            => new NullableInt16RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, NullableIntegralNumericElement length)
            => new NullableInt16RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, IntegralNumericElement length, int function)
            => new NullableInt16RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, NullableIntegralNumericElement length, int function)
            => new NullableInt16RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, int length, IntegralNumericElement function)
            => new NullableInt16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, int length, NullableIntegralNumericElement function)
            => new NullableInt16RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new NullableInt16RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, NullableIntegralNumericElement length, IntegralNumericElement function)
            => new NullableInt16RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, IntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableInt16RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<short?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt16RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16RoundFunctionExpression Round(AnyElement<short?> expression, NullableIntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableInt16RoundFunctionExpression(expression, length, function);
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int32}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32RoundFunctionExpression Round(AnyElement<int> expression, int length)
            => new Int32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int32}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32RoundFunctionExpression Round(AnyElement<int> expression, int length, int function)
            => new Int32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int32}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32RoundFunctionExpression Round(AnyElement<int> expression, IntegralNumericElement length)
            => new Int32RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int32}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32RoundFunctionExpression Round(AnyElement<int> expression, IntegralNumericElement length, int function)
            => new Int32RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int32}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32RoundFunctionExpression Round(AnyElement<int> expression, int length, IntegralNumericElement function)
            => new Int32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int32}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32RoundFunctionExpression Round(AnyElement<int> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new Int32RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length)
            => new NullableInt32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length, int function)
            => new NullableInt32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, IntegralNumericElement length)
            => new NullableInt32RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableIntegralNumericElement length)
            => new NullableInt32RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, IntegralNumericElement length, int function)
            => new NullableInt32RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableIntegralNumericElement length, int function)
            => new NullableInt32RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length, IntegralNumericElement function)
            => new NullableInt32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, int length, NullableIntegralNumericElement function)
            => new NullableInt32RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new NullableInt32RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableIntegralNumericElement length, IntegralNumericElement function)
            => new NullableInt32RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, IntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableInt32RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<int?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt32RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32RoundFunctionExpression Round(AnyElement<int?> expression, NullableIntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableInt32RoundFunctionExpression(expression, length, function);
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int64}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64RoundFunctionExpression Round(AnyElement<long> expression, int length)
            => new Int64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int64}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64RoundFunctionExpression Round(AnyElement<long> expression, int length, int function)
            => new Int64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int64}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64RoundFunctionExpression Round(AnyElement<long> expression, IntegralNumericElement length)
            => new Int64RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int64}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64RoundFunctionExpression Round(AnyElement<long> expression, IntegralNumericElement length, int function)
            => new Int64RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int64}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64RoundFunctionExpression Round(AnyElement<long> expression, int length, IntegralNumericElement function)
            => new Int64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Int64}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="Int64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64RoundFunctionExpression Round(AnyElement<long> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new Int64RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length)
            => new NullableInt64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length, int function)
            => new NullableInt64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, IntegralNumericElement length)
            => new NullableInt64RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableIntegralNumericElement length)
            => new NullableInt64RoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, IntegralNumericElement length, int function)
            => new NullableInt64RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableIntegralNumericElement length, int function)
            => new NullableInt64RoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length, IntegralNumericElement function)
            => new NullableInt64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, int length, NullableIntegralNumericElement function)
            => new NullableInt64RoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new NullableInt64RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableIntegralNumericElement length, IntegralNumericElement function)
            => new NullableInt64RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, IntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableInt64RoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<long?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableInt64RoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64RoundFunctionExpression Round(AnyElement<long?> expression, NullableIntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableInt64RoundFunctionExpression(expression, length, function);
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Single}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleRoundFunctionExpression Round(AnyElement<float> expression, int length)
            => new SingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Single}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleRoundFunctionExpression Round(AnyElement<float> expression, int length, int function)
            => new SingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Single}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleRoundFunctionExpression Round(AnyElement<float> expression, IntegralNumericElement length)
            => new SingleRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Single}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleRoundFunctionExpression Round(AnyElement<float> expression, IntegralNumericElement length, int function)
            => new SingleRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Single}"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleRoundFunctionExpression Round(AnyElement<float> expression, int length, IntegralNumericElement function)
            => new SingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement{Single}"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="SingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleRoundFunctionExpression Round(AnyElement<float> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new SingleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length)
            => new NullableSingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length, int function)
            => new NullableSingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, IntegralNumericElement length)
            => new NullableSingleRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableIntegralNumericElement length)
            => new NullableSingleRoundFunctionExpression(expression, length);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, IntegralNumericElement length, int function)
            => new NullableSingleRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">The type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableIntegralNumericElement length, int function)
            => new NullableSingleRoundFunctionExpression(expression, length, new Int32ExpressionMediator(new LiteralExpression<int>(function)));

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length, IntegralNumericElement function)
            => new NullableSingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">The precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, int length, NullableIntegralNumericElement function)
            => new NullableSingleRoundFunctionExpression(expression, new Int32ExpressionMediator(new LiteralExpression<int>(length)), function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, IntegralNumericElement length, IntegralNumericElement function)
            => new NullableSingleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableIntegralNumericElement length, IntegralNumericElement function)
            => new NullableSingleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="IntegralNumericElement" /> (one of <see cref="ByteElement" />, <see cref="AnyElement<short>" />, <see cref="AnyElement<int>" />, or <see cref="AnyElement<long>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, IntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableSingleRoundFunctionExpression(expression, length, function);

        /// <summary>
        /// Construct an expression for the ROUND transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/round-transact-sql">Microsoft docs on ROUND</see></para>
        /// </summary>
        /// <param name="expression">A <see cref="AnyElement<float?>"/> to round.</param>
        /// <param name="length">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />), the precision to which <paramref name="expression" /> is to be rounded.</param>
        /// <param name="function">A <see cref="NullableIntegralNumericElement" /> (one of <see cref="NullableByteElement" />, <see cref="AnyElement<short?>" />, <see cref="AnyElement<int?>" />, or <see cref="AnyElement<long?>" />) indicating the type of operation to perform.</param>
        /// <returns><see cref="NullableSingleRoundFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleRoundFunctionExpression Round(AnyElement<float?> expression, NullableIntegralNumericElement length, NullableIntegralNumericElement function)
            => new NullableSingleRoundFunctionExpression(expression, length, function);
        #endregion
    }
}
