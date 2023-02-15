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
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="ByteMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public ByteMaximumFunctionExpression Max(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableByteMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public NullableByteMaximumFunctionExpression Max(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int16MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public Int16MaximumFunctionExpression Max(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt16MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public NullableInt16MaximumFunctionExpression Max(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int32MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32MaximumFunctionExpression Max(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt32MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32MaximumFunctionExpression Max(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int64MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64MaximumFunctionExpression Max(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt64MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64MaximumFunctionExpression Max(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="SingleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleMaximumFunctionExpression Max(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableSingleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleMaximumFunctionExpression Max(AnyElement<float?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DoubleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleMaximumFunctionExpression Max(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDoubleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleMaximumFunctionExpression Max(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DecimalMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalMaximumFunctionExpression Max(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDecimalMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalMaximumFunctionExpression Max(AnyElement<decimal?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DateTimeMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public DateTimeMaximumFunctionExpression Max(AnyElement<DateTime> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDateTimeMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeMaximumFunctionExpression Max(AnyElement<DateTime?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DateTimeOffsetMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public DateTimeOffsetMaximumFunctionExpression Max(AnyElement<DateTimeOffset> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDateTimeOffsetMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetMaximumFunctionExpression Max(AnyElement<DateTimeOffset?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="GuidMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public GuidMaximumFunctionExpression Max(AnyElement<Guid> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableGuidMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public NullableGuidMaximumFunctionExpression Max(AnyElement<Guid?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="StringMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringMaximumFunctionExpression Max(StringElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="TimeSpanMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public TimeSpanMaximumFunctionExpression Max(AnyElement<TimeSpan> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/max>read the docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableTimeSpanMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public NullableTimeSpanMaximumFunctionExpression Max(AnyElement<TimeSpan?> element)
            => new(element);
    }
}
