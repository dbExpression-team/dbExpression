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

using DbExpression.MsSql.Expression;
using DbExpression.Sql;
using DbExpression.Sql.Builder;
using DbExpression.Sql.Expression;
using System;

namespace DbExpression.MsSql.Builder
{
    public partial class VersionBaseMsSqlFunctionExpressionBuilder
    {
        #region DateTime
        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTime?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTime?> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
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
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<DateTimeOffset?>(startDate), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTimeOffset? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTimeOffset endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTimeOffset>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTime? endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime?>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, DateTime endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, new LiteralExpression<DateTime>(endDate));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset> startDate, AnyElement<DateTime?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTimeOffset> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTimeOffset?> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyElement{DateTime}"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyElement<DateTimeOffset?> startDate, AnyElement<DateTime> endDate)
            => new(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datediff">read the docs on DATEDIFF</see></para>
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
