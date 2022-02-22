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
        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>.</param>
        /// <returns><see cref="Int32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTime> element)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>?.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTime?> element)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>.</param>
        /// <returns><see cref="Int32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTimeOffset> element)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>?.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTimeOffset?> element)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);
    }
}
