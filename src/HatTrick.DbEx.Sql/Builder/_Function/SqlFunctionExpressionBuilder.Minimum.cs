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
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="ByteMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public ByteMinimumFunctionExpression Min(AnyElement<byte> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableByteMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public NullableByteMinimumFunctionExpression Min(AnyElement<byte?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int16MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public Int16MinimumFunctionExpression Min(AnyElement<short> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt16MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public NullableInt16MinimumFunctionExpression Min(AnyElement<short?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int32MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32MinimumFunctionExpression Min(AnyElement<int> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt32MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32MinimumFunctionExpression Min(AnyElement<int?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="Int64MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64MinimumFunctionExpression Min(AnyElement<long> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableInt64MinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64MinimumFunctionExpression Min(AnyElement<long?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="SingleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleMinimumFunctionExpression Min(AnyElement<float> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableSingleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleMinimumFunctionExpression Min(AnyElement<float?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DoubleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleMinimumFunctionExpression Min(AnyElement<double> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDoubleMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleMinimumFunctionExpression Min(AnyElement<double?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DecimalMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalMinimumFunctionExpression Min(AnyElement<decimal> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDecimalMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalMinimumFunctionExpression Min(AnyElement<decimal?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DateTimeMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public DateTimeMinimumFunctionExpression Min(AnyElement<DateTime> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDateTimeMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeMinimumFunctionExpression Min(AnyElement<DateTime?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="DateTimeOffsetMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public DateTimeOffsetMinimumFunctionExpression Min(AnyElement<DateTimeOffset> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableDateTimeOffsetMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetMinimumFunctionExpression Min(AnyElement<DateTimeOffset?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="GuidMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public GuidMinimumFunctionExpression Min(AnyElement<Guid> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableGuidMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public NullableGuidMinimumFunctionExpression Min(AnyElement<Guid?> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="StringMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringMinimumFunctionExpression Min(StringElement element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="TimeSpanMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public TimeSpanMinimumFunctionExpression Min(AnyElement<TimeSpan> element)
            => new(element);

        /// <summary>
        /// Construct an expression for the MIN transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/aggregate/min>read the docs on MIN</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, the value to use for calculating the minimum function result.</param>
        /// <returns><see cref="NullableTimeSpanMinimumFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public NullableTimeSpanMinimumFunctionExpression Min(AnyElement<TimeSpan?> element)
            => new(element);
    }
}
