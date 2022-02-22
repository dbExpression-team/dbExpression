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
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="ByteMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteMaximumFunctionExpression Max(AnyElement<byte> element)
            => new ByteMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableByteMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteMaximumFunctionExpression Max(AnyElement<byte?> element)
            => new NullableByteMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int16MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16MaximumFunctionExpression Max(AnyElement<short> element)
            => new Int16MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt16MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16MaximumFunctionExpression Max(AnyElement<short?> element)
            => new NullableInt16MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int32MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32MaximumFunctionExpression Max(AnyElement<int> element)
            => new Int32MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt32MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32MaximumFunctionExpression Max(AnyElement<int?> element)
            => new NullableInt32MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="Int64MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64MaximumFunctionExpression Max(AnyElement<long> element)
            => new Int64MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableInt64MaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64MaximumFunctionExpression Max(AnyElement<long?> element)
            => new NullableInt64MaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="SingleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleMaximumFunctionExpression Max(AnyElement<float> element)
            => new SingleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableSingleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleMaximumFunctionExpression Max(AnyElement<float?> element)
            => new NullableSingleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DoubleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleMaximumFunctionExpression Max(AnyElement<double> element)
            => new DoubleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDoubleMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleMaximumFunctionExpression Max(AnyElement<double?> element)
            => new NullableDoubleMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DecimalMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalMaximumFunctionExpression Max(AnyElement<decimal> element)
            => new DecimalMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDecimalMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalMaximumFunctionExpression Max(AnyElement<decimal?> element)
            => new NullableDecimalMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DateTimeMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public static DateTimeMaximumFunctionExpression Max(AnyElement<DateTime> element)
            => new DateTimeMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDateTimeMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public static NullableDateTimeMaximumFunctionExpression Max(AnyElement<DateTime?> element)
            => new NullableDateTimeMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="DateTimeOffsetMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public static DateTimeOffsetMaximumFunctionExpression Max(AnyElement<DateTimeOffset> element)
            => new DateTimeOffsetMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableDateTimeOffsetMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public static NullableDateTimeOffsetMaximumFunctionExpression Max(AnyElement<DateTimeOffset?> element)
            => new NullableDateTimeOffsetMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="GuidMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public static GuidMaximumFunctionExpression Max(AnyElement<Guid> element)
            => new GuidMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableGuidMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public static NullableGuidMaximumFunctionExpression Max(AnyElement<Guid?> element)
            => new NullableGuidMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="StringMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringMaximumFunctionExpression Max(StringElement element)
            => new StringMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="TimeSpanMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public static TimeSpanMaximumFunctionExpression Max(AnyElement<TimeSpan> element)
            => new TimeSpanMaximumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MAX transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/max-transact-sql">Microsoft docs on MAX</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, the value to use for calculating the maximum function result.</param>
        /// <returns><see cref="NullableTimeSpanMaximumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public static NullableTimeSpanMaximumFunctionExpression Max(AnyElement<TimeSpan?> element)
            => new NullableTimeSpanMaximumFunctionExpression(element);
    }
}
