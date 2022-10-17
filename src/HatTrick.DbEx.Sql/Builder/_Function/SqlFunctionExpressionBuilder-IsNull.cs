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
        #region bool
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Boolean}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>.</returns>
        public BooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element1, AnyElement<bool> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Boolean}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>?.</returns>
        public NullableBooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element1, AnyElement<bool?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Boolean"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>.</returns>
        public BooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element, bool value)
            => new(element, new LiteralExpression<bool>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Boolean"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>?.</returns>
        public NullableBooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element, bool? value)
            => new(element, new LiteralExpression<bool?>(value));
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Byte}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public ByteIsNullFunctionExpression IsNull(AnyElement<byte?> element1, AnyElement<byte> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Byte}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public NullableByteIsNullFunctionExpression IsNull(AnyElement<byte?> element1, AnyElement<byte?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Byte"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public ByteIsNullFunctionExpression IsNull(AnyElement<byte?> element, byte value)
            => new(element, new LiteralExpression<byte>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Byte"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public NullableByteIsNullFunctionExpression IsNull(AnyElement<byte?> element, byte? value)
            => new(element, new LiteralExpression<byte?>(value));
        #endregion

        #region DateTime
        // <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTime}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public DateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element1, AnyElement<DateTime> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTime}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element1, AnyElement<DateTime?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTime"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public DateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element, DateTime value)
            => new(element, new LiteralExpression<DateTime>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTime"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public NullableDateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element, DateTime? value)
            => new(element, new LiteralExpression<DateTime?>(value));
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTimeOffset}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public DateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element1, AnyElement<DateTimeOffset> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element1, AnyElement<DateTimeOffset?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTimeOffset"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public DateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element, DateTimeOffset value)
            => new(element, new LiteralExpression<DateTimeOffset>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTimeOffset"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element, DateTimeOffset? value)
            => new(element, new LiteralExpression<DateTimeOffset?>(value));
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Decimal}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element1, AnyElement<decimal> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Decimal}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element1, AnyElement<decimal?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Decimal"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public DecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element, decimal value)
            => new(element, new LiteralExpression<decimal>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Decimal"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public NullableDecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element, decimal? value)
            => new(element, new LiteralExpression<decimal?>(value));
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Double}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleIsNullFunctionExpression IsNull(AnyElement<double?> element1, AnyElement<double> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Double}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleIsNullFunctionExpression IsNull(AnyElement<double?> element1, AnyElement<double?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Double"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public DoubleIsNullFunctionExpression IsNull(AnyElement<double?> element, double value)
            => new(element, new LiteralExpression<double>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Double"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public NullableDoubleIsNullFunctionExpression IsNull(AnyElement<double?> element, double? value)
            => new(element, new LiteralExpression<double?>(value));
        #endregion

        #region Enum
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TEnum}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>.</returns>
        public EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element1, AnyElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TEnum}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>?.</returns>
        public NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element1, AnyElement<TEnum?> element2)
            where TEnum : struct, Enum, IComparable
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TEnum"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>.</returns>
        public EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(element, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TEnum"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>?.</returns>
        public NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(element, new LiteralExpression<TEnum?>(value));
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Single}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleIsNullFunctionExpression IsNull(AnyElement<float?> element1, AnyElement<float> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Single}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleIsNullFunctionExpression IsNull(AnyElement<float?> element1, AnyElement<float?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Single"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public SingleIsNullFunctionExpression IsNull(AnyElement<float?> element, float value)
            => new(element, new LiteralExpression<float>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Single"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public NullableSingleIsNullFunctionExpression IsNull(AnyElement<float?> element, float? value)
            => new(element, new LiteralExpression<float?>(value));
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Guid}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public GuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element1, AnyElement<Guid> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Guid}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public NullableGuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element1, AnyElement<Guid?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Guid"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public GuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element, Guid value)
            => new(element, new LiteralExpression<Guid>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Guid"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public NullableGuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element, Guid? value)
            => new(element, new LiteralExpression<Guid?>(value));
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int16}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public Int16IsNullFunctionExpression IsNull(AnyElement<short?> element1, AnyElement<short> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int16}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public NullableInt16IsNullFunctionExpression IsNull(AnyElement<short?> element1, AnyElement<short?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int16"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public Int16IsNullFunctionExpression IsNull(AnyElement<short?> element, short value)
            => new(element, new LiteralExpression<short>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int16"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public NullableInt16IsNullFunctionExpression IsNull(AnyElement<short?> element, short? value)
            => new(element, new LiteralExpression<short?>(value));
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int32}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32IsNullFunctionExpression IsNull(AnyElement<int?> element1, AnyElement<int> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int32}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32IsNullFunctionExpression IsNull(AnyElement<int?> element1, AnyElement<int?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int32"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public Int32IsNullFunctionExpression IsNull(AnyElement<int?> element, int value)
            => new(element, new LiteralExpression<int>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int32"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public NullableInt32IsNullFunctionExpression IsNull(AnyElement<int?> element, int? value)
            => new(element, new LiteralExpression<int?>(value));
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int64}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64IsNullFunctionExpression IsNull(AnyElement<long?> element1, AnyElement<long> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int64}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64IsNullFunctionExpression IsNull(AnyElement<long?> element1, AnyElement<long?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int64"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public Int64IsNullFunctionExpression IsNull(AnyElement<long?> element, long value)
            => new(element, new LiteralExpression<long>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int64"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public NullableInt64IsNullFunctionExpression IsNull(AnyElement<long?> element, long? value)
            => new(element, new LiteralExpression<long?>(value));
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="String"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringIsNullFunctionExpression IsNull(StringElement element1, string element2)
            => new(element1, new StringExpressionMediator(new LiteralExpression<string>(element2)));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="StringElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringIsNullFunctionExpression IsNull(StringElement element1, StringElement element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="StringElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringIsNullFunctionExpression IsNull(NullableStringElement element1, StringElement element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyStringElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableStringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public NullableStringIsNullFunctionExpression IsNull(NullableStringElement element1, AnyStringElement element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="String"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public StringIsNullFunctionExpression IsNull(NullableStringElement element, string value)
            => new(element, new StringExpressionMediator(new LiteralExpression<string>(value)));
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TimeSpan}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public TimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element1, AnyElement<TimeSpan> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TimeSpan}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public NullableTimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element1, AnyElement<TimeSpan?> element2)
            => new(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TimeSpan"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public TimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element, TimeSpan value)
            => new(element, new LiteralExpression<TimeSpan>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull?version=0.9.4">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TimeSpan"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public NullableTimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element, TimeSpan? value)
            => new(element, new LiteralExpression<TimeSpan?>(value));
        #endregion
    }
}
