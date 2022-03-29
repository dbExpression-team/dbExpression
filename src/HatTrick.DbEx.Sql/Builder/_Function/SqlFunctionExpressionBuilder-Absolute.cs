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

using HatTrick.DbEx.Sql.Expression;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HatTrick.DbEx.Sql.Builder
{
    public partial class SqlFunctionExpressionBuilder
    {
        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="ByteAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public ByteAbsFunctionExpression Abs(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableByteAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public NullableByteAbsFunctionExpression Abs(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="Int16AbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public Int16AbsFunctionExpression Abs(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableInt16AbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public NullableInt16AbsFunctionExpression Abs(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="Int32AbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32AbsFunctionExpression Abs(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableInt32AbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32AbsFunctionExpression Abs(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="Int64AbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64AbsFunctionExpression Abs(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableInt64AbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64AbsFunctionExpression Abs(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="SingleAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleAbsFunctionExpression Abs(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableSingleElement"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableSingleAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleAbsFunctionExpression Abs(AnyElement<float?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="DoubleAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleAbsFunctionExpression Abs(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableDoubleAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleAbsFunctionExpression Abs(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="DecimalAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalAbsFunctionExpression Abs(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the ABS transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/abs-transact-sql">Microsoft docs on ABS</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the absolute value.</param>
        /// <returns><see cref="NullableDecimalAbsFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalAbsFunctionExpression Abs(AnyElement<decimal?> element)
            => new(element);
    }
}
