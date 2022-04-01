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
        #region DateTime
        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion
    }
}
