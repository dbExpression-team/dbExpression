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
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="ByteMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteMinimumFunctionExpression Min(AnyElement<byte> element)
            => new ByteMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableByteMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteMinimumFunctionExpression Min(AnyElement<byte?> element)
            => new NullableByteMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int16MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16MinimumFunctionExpression Min(AnyElement<short> element)
            => new Int16MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt16MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16MinimumFunctionExpression Min(AnyElement<short?> element)
            => new NullableInt16MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int32MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32MinimumFunctionExpression Min(AnyElement<int> element)
            => new Int32MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt32MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32MinimumFunctionExpression Min(AnyElement<int?> element)
            => new NullableInt32MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int64MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64MinimumFunctionExpression Min(AnyElement<long> element)
            => new Int64MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt64MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64MinimumFunctionExpression Min(AnyElement<long?> element)
            => new NullableInt64MinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="SingleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleMinimumFunctionExpression Min(AnyElement<float> element)
            => new SingleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableSingleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleMinimumFunctionExpression Min(AnyElement<float?> element)
            => new NullableSingleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DoubleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleMinimumFunctionExpression Min(AnyElement<double> element)
            => new DoubleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDoubleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleMinimumFunctionExpression Min(AnyElement<double?> element)
            => new NullableDoubleMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DecimalMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalMinimumFunctionExpression Min(AnyElement<decimal> element)
            => new DecimalMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDecimalMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalMinimumFunctionExpression Min(AnyElement<decimal?> element)
            => new NullableDecimalMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DateTimeMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public static DateTimeMinimumFunctionExpression Min(AnyElement<DateTime> element)
            => new DateTimeMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDateTimeMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public static NullableDateTimeMinimumFunctionExpression Min(AnyElement<DateTime?> element)
            => new NullableDateTimeMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DateTimeOffsetMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public static DateTimeOffsetMinimumFunctionExpression Min(AnyElement<DateTimeOffset> element)
            => new DateTimeOffsetMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDateTimeOffsetMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public static NullableDateTimeOffsetMinimumFunctionExpression Min(AnyElement<DateTimeOffset?> element)
            => new NullableDateTimeOffsetMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="GuidMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public static GuidMinimumFunctionExpression Min(AnyElement<Guid> element)
            => new GuidMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableGuidMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public static NullableGuidMinimumFunctionExpression Min(AnyElement<Guid?> element)
            => new NullableGuidMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="StringMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringMinimumFunctionExpression Min(StringElement element)
            => new StringMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="TimeSpanMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public static TimeSpanMinimumFunctionExpression Min(AnyElement<TimeSpan> element)
            => new TimeSpanMinimumFunctionExpression(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/min-transact-sql">Microsoft docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableTimeSpanMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public static NullableTimeSpanMinimumFunctionExpression Min(AnyElement<TimeSpan?> element)
            => new NullableTimeSpanMinimumFunctionExpression(element);
    }
}
