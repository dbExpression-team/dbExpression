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
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Boolean}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>.</returns>
        public static BooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element1, AnyElement<bool> element2)
            => new BooleanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Boolean}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>?.</returns>
        public static NullableBooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element1, AnyElement<bool?> element2)
            => new NullableBooleanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Boolean"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>.</returns>
        public static BooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element, bool value)
            => new BooleanIsNullFunctionExpression(element, new LiteralExpression<bool>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Boolean}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Boolean"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>?.</returns>
        public static NullableBooleanIsNullFunctionExpression IsNull(AnyElement<bool?> element, bool? value)
            => new NullableBooleanIsNullFunctionExpression(element, new LiteralExpression<bool?>(value));
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Byte}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteIsNullFunctionExpression IsNull(AnyElement<byte?> element1, AnyElement<byte> element2)
            => new ByteIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Byte}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteIsNullFunctionExpression IsNull(AnyElement<byte?> element1, AnyElement<byte?> element2)
            => new NullableByteIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Byte"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteIsNullFunctionExpression IsNull(AnyElement<byte?> element, byte value)
            => new ByteIsNullFunctionExpression(element, new LiteralExpression<byte>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Byte}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Byte"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteIsNullFunctionExpression IsNull(AnyElement<byte?> element, byte? value)
            => new NullableByteIsNullFunctionExpression(element, new LiteralExpression<byte?>(value));
        #endregion

        #region DateTime
        // <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTime}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public static DateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element1, AnyElement<DateTime> element2)
            => new DateTimeIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTime}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public static NullableDateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element1, AnyElement<DateTime?> element2)
            => new NullableDateTimeIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTime"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public static DateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element, DateTime value)
            => new DateTimeIsNullFunctionExpression(element, new LiteralExpression<DateTime>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTime}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTime"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public static NullableDateTimeIsNullFunctionExpression IsNull(AnyElement<DateTime?> element, DateTime? value)
            => new NullableDateTimeIsNullFunctionExpression(element, new LiteralExpression<DateTime?>(value));
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTimeOffset}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public static DateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element1, AnyElement<DateTimeOffset> element2)
            => new DateTimeOffsetIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element1, AnyElement<DateTimeOffset?> element2)
            => new NullableDateTimeOffsetIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTimeOffset"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public static DateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element, DateTimeOffset value)
            => new DateTimeOffsetIsNullFunctionExpression(element, new LiteralExpression<DateTimeOffset>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{DateTimeOffset}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="DateTimeOffset"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(AnyElement<DateTimeOffset?> element, DateTimeOffset? value)
            => new NullableDateTimeOffsetIsNullFunctionExpression(element, new LiteralExpression<DateTimeOffset?>(value));
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Decimal}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element1, AnyElement<decimal> element2)
            => new DecimalIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Decimal}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element1, AnyElement<decimal?> element2)
            => new NullableDecimalIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Decimal"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element, decimal value)
            => new DecimalIsNullFunctionExpression(element, new LiteralExpression<decimal>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Decimal}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Decimal"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalIsNullFunctionExpression IsNull(AnyElement<decimal?> element, decimal? value)
            => new NullableDecimalIsNullFunctionExpression(element, new LiteralExpression<decimal?>(value));
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Double}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleIsNullFunctionExpression IsNull(AnyElement<double?> element1, AnyElement<double> element2)
            => new DoubleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Double}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleIsNullFunctionExpression IsNull(AnyElement<double?> element1, AnyElement<double?> element2)
            => new NullableDoubleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Double"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleIsNullFunctionExpression IsNull(AnyElement<double?> element, double value)
            => new DoubleIsNullFunctionExpression(element, new LiteralExpression<double>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Double}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Double"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleIsNullFunctionExpression IsNull(AnyElement<double?> element, double? value)
            => new NullableDoubleIsNullFunctionExpression(element, new LiteralExpression<double?>(value));
        #endregion

        #region Enum
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TEnum}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>.</returns>
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element1, AnyElement<TEnum> element2)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TEnum}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>?.</returns>
        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element1, AnyElement<TEnum?> element2)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TEnum"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>.</returns>
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new EnumIsNullFunctionExpression<TEnum>(element, new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TEnum"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>?.</returns>
        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(AnyElement<TEnum?> element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new NullableEnumIsNullFunctionExpression<TEnum>(element, new LiteralExpression<TEnum?>(value));
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Single}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleIsNullFunctionExpression IsNull(AnyElement<float?> element1, AnyElement<float> element2)
            => new SingleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Single}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleIsNullFunctionExpression IsNull(AnyElement<float?> element1, AnyElement<float?> element2)
            => new NullableSingleIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Single"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleIsNullFunctionExpression IsNull(AnyElement<float?> element, float value)
            => new SingleIsNullFunctionExpression(element, new LiteralExpression<float>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Single}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Single"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleIsNullFunctionExpression IsNull(AnyElement<float?> element, float? value)
            => new NullableSingleIsNullFunctionExpression(element, new LiteralExpression<float?>(value));
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Guid}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public static GuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element1, AnyElement<Guid> element2)
            => new GuidIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Guid}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public static NullableGuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element1, AnyElement<Guid?> element2)
            => new NullableGuidIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Guid"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public static GuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element, Guid value)
            => new GuidIsNullFunctionExpression(element, new LiteralExpression<Guid>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Guid}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Guid"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public static NullableGuidIsNullFunctionExpression IsNull(AnyElement<Guid?> element, Guid? value)
            => new NullableGuidIsNullFunctionExpression(element, new LiteralExpression<Guid?>(value));
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int16}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16IsNullFunctionExpression IsNull(AnyElement<short?> element1, AnyElement<short> element2)
            => new Int16IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int16}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16IsNullFunctionExpression IsNull(AnyElement<short?> element1, AnyElement<short?> element2)
            => new NullableInt16IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int16"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16IsNullFunctionExpression IsNull(AnyElement<short?> element, short value)
            => new Int16IsNullFunctionExpression(element, new LiteralExpression<short>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int16}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int16"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16IsNullFunctionExpression IsNull(AnyElement<short?> element, short? value)
            => new NullableInt16IsNullFunctionExpression(element, new LiteralExpression<short?>(value));
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int32}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32IsNullFunctionExpression IsNull(AnyElement<int?> element1, AnyElement<int> element2)
            => new Int32IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int32}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32IsNullFunctionExpression IsNull(AnyElement<int?> element1, AnyElement<int?> element2)
            => new NullableInt32IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int32"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32IsNullFunctionExpression IsNull(AnyElement<int?> element, int value)
            => new Int32IsNullFunctionExpression(element, new LiteralExpression<int>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int32}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int32"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32IsNullFunctionExpression IsNull(AnyElement<int?> element, int? value)
            => new NullableInt32IsNullFunctionExpression(element, new LiteralExpression<int?>(value));
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int64}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64IsNullFunctionExpression IsNull(AnyElement<long?> element1, AnyElement<long> element2)
            => new Int64IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Int64}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64IsNullFunctionExpression IsNull(AnyElement<long?> element1, AnyElement<long?> element2)
            => new NullableInt64IsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int64"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64IsNullFunctionExpression IsNull(AnyElement<long?> element, long value)
            => new Int64IsNullFunctionExpression(element, new LiteralExpression<long>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{Int64}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="Int64"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64IsNullFunctionExpression IsNull(AnyElement<long?> element, long? value)
            => new NullableInt64IsNullFunctionExpression(element, new LiteralExpression<long?>(value));
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{String}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringIsNullFunctionExpression IsNull(AnyElement<string> element1, AnyElement<string> element2)
            => new StringIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{String}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringIsNullFunctionExpression IsNull(NullableStringElement element1, AnyElement<string> element2)
            => new StringIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="NullableStringElement"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableStringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="NullableStringElement"/>.</returns>
        public static NullableStringIsNullFunctionExpression IsNull(NullableStringElement element1, NullableStringElement element2)
            => new NullableStringIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="NullableStringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="String"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringIsNullFunctionExpression IsNull(NullableStringElement element, string value)
            => new StringIsNullFunctionExpression(element, new LiteralExpression<string>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{String}"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="String"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="StringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static StringIsNullFunctionExpression IsNull(AnyElement<string> element, string value)
            => new StringIsNullFunctionExpression(element, new LiteralExpression<string>(value));
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TimeSpan}"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public static TimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element1, AnyElement<TimeSpan> element2)
            => new TimeSpanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{TimeSpan}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public static NullableTimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element1, AnyElement<TimeSpan?> element2)
            => new NullableTimeSpanIsNullFunctionExpression(element1, element2);

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TimeSpan"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public static TimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element, TimeSpan value)
            => new TimeSpanIsNullFunctionExpression(element, new LiteralExpression<TimeSpan>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/isnull-transact-sql">Microsoft docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TimeSpan}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TimeSpan"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public static NullableTimeSpanIsNullFunctionExpression IsNull(AnyElement<TimeSpan?> element, TimeSpan? value)
            => new NullableTimeSpanIsNullFunctionExpression(element, new LiteralExpression<TimeSpan?>(value));
        #endregion
    }
}
