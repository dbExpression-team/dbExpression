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
    public partial class VersionBaseMsSqlFunctionExpressionBuilder
    {
        #region DateTime
        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, AnyElement<DateTime> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, AnyElement<DateTime?> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, AnyElement<DateTime> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int?>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, AnyElement<DateTime?> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int?>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int> value, AnyElement<DateTime> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int> value, AnyElement<DateTime?> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="AnyElement{Int32}"/>? to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int?> value, AnyElement<DateTime> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="AnyElement{Int32}"/>? to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int?> value, AnyElement<DateTime?> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, AnyElement<DateTimeOffset> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, AnyElement<DateTimeOffset?> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int? value, AnyElement<DateTimeOffset> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int?>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int? value, AnyElement<DateTimeOffset?> element)
            => new(new DatePartsExpression<DateParts>(datePart), new LiteralExpression<int?>(value), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int> value, AnyElement<DateTimeOffset> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int> value, AnyElement<DateTimeOffset?> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="AnyElement{Int32}"/>? to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int?> value, AnyElement<DateTimeOffset> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/dateadd?version=0.9.5">read the docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="AnyElement{Int32}"/>? to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>? to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, AnyElement<int?> value, AnyElement<DateTimeOffset?> element)
            => new(new DatePartsExpression<DateParts>(datePart), value, element);
        #endregion
    }
}
