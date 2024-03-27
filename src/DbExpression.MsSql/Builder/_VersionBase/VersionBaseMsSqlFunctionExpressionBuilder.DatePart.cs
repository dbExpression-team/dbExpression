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
        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datepart">read the docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/> to return the <paramref name="datePart"/> from.</param>
        /// <returns><see cref="Int32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public virtual Int32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTime> element)
            => new(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datepart">read the docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTime}"/>? to return the <paramref name="datePart"/> from.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public virtual NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTime?> element)
            => new(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datepart">read the docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/> to return the <paramref name="datePart"/> from.</param>
        /// <returns><see cref="Int32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public virtual Int32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTimeOffset> element)
            => new(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/date-and-time/datepart">read the docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyElement{DateTimeOffset}"/>? to return the <paramref name="datePart"/> from.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public virtual NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, AnyElement<DateTimeOffset?> element)
            => new(new DatePartsExpression<DateParts>(datePart), element);
    }
}
