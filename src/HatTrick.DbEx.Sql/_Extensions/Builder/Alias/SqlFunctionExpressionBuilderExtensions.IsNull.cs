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

namespace HatTrick.DbEx.Sql.Builder.Alias
{
    public static partial class SqlFunctionExpressionBuilderExtensions
    {
        #region bool
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="BooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>.</returns>
        public static BooleanIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, bool element2)
            => new(new AliasExpression<bool?>(element1), new LiteralExpression<bool>(element2));


        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableBooleanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Boolean}"/>?.</returns>
        public static NullableBooleanIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, bool? element2)
            => new(new AliasExpression<bool?>(element1), new LiteralExpression<bool?>(element2));
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="ByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>.</returns>
        public static ByteIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, byte element2)
            => new(new AliasExpression<byte?>(element1), new LiteralExpression<byte>(element2));


        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableByteIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Byte}"/>?.</returns>
        public static NullableByteIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, byte? element2)
            => new(new AliasExpression<byte?>(element1), new LiteralExpression<byte?>(element2));
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>.</returns>
        public static DateTimeIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, DateTime element2)
            => new(new AliasExpression<DateTime?>(element1), new LiteralExpression<DateTime>(element2));


        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTime}"/>?.</returns>
        public static NullableDateTimeIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, DateTime? element2)
            => new(new AliasExpression<DateTime?>(element1), new LiteralExpression<DateTime?>(element2));
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>.</returns>
        public static DateTimeOffsetIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, DateTimeOffset element2)
            => new(new AliasExpression<DateTimeOffset?>(element1), new LiteralExpression<DateTimeOffset>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDateTimeOffsetIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{DateTimeOffset}"/>?.</returns>
        public static NullableDateTimeOffsetIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, DateTimeOffset? element2)
            => new(new AliasExpression<DateTimeOffset?>(element1), new LiteralExpression<DateTimeOffset?>(element2));
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>.</returns>
        public static DecimalIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, decimal element2)
            => new(new AliasExpression<decimal?>(element1), new LiteralExpression<decimal>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDecimalIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Decimal}"/>?.</returns>
        public static NullableDecimalIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, decimal? element2)
            => new(new AliasExpression<decimal?>(element1), new LiteralExpression<decimal?>(element2));
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="DoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>.</returns>
        public static DoubleIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, double element2)
            => new(new AliasExpression<double?>(element1), new LiteralExpression<double>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableDoubleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Double}"/>?.</returns>
        public static NullableDoubleIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, double? element2)
            => new(new AliasExpression<double?>(element1), new LiteralExpression<double?>(element2));
        #endregion

        #region Enum
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TEnum"/> value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="EnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>.</returns>
        public static EnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element, TEnum value)
            where TEnum : struct, Enum, IComparable
            => new(new AliasExpression<TEnum?>(element), new LiteralExpression<TEnum>(value));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement{TEnum}"/>?, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned <see cref="TEnum"/>? value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableEnumIsNullFunctionExpression{TEnum}"/> for use with any operation accepting a <see cref="AnyElement{TEnum}"/>?.</returns>
        public static NullableEnumIsNullFunctionExpression<TEnum> IsNull<TEnum>(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element, TEnum? value)
            where TEnum : struct, Enum, IComparable
            => new(new AliasExpression<TEnum?>(element), new LiteralExpression<TEnum?>(value));
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="GuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>.</returns>
        public static GuidIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, Guid element2)
            => new(new AliasExpression<Guid?>(element1), new LiteralExpression<Guid>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableGuidIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Guid}"/>?.</returns>
        public static NullableGuidIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, Guid? element2)
            => new(new AliasExpression<Guid?>(element1), new LiteralExpression<Guid?>(element2));
       #endregion

        #region short
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>.</returns>
        public static Int16IsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, short element2)
            => new(new AliasExpression<short?>(element1), new LiteralExpression<short>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt16IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int16}"/>?.</returns>
        public static NullableInt16IsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, short? element2)
            => new(new AliasExpression<short?>(element1), new LiteralExpression<short?>(element2));
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>.</returns>
        public static Int32IsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, int element2)
            => new(new AliasExpression<int?>(element1), new LiteralExpression<int>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt32IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int32}"/>?.</returns>
        public static NullableInt32IsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, int? element2)
            => new(new AliasExpression<int?>(element1), new LiteralExpression<int?>(element2));
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="Int64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>.</returns>
        public static Int64IsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, long element2)
            => new(new AliasExpression<long?>(element1), new LiteralExpression<long>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableInt64IsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Int64}"/>?.</returns>
        public static NullableInt64IsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, long? element2)
            => new(new AliasExpression<long?>(element1), new LiteralExpression<long?>(element2));
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="SingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>.</returns>
        public static SingleIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, float element2)
            => new(new AliasExpression<float?>(element1), new LiteralExpression<float>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableSingleIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{Single}"/>?.</returns>
        public static NullableSingleIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, float? element2)
            => new(new AliasExpression<float?>(element1), new LiteralExpression<float?>(element2));
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="StringElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="String"/>, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableStringIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{String}"/>.</returns>
        public static NullableStringIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, string? element2)
            => new(new AliasExpression<string?>(element1), new LiteralExpression<string?>(element2));        
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="TimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>.</returns>
        public static TimeSpanIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, TimeSpan element2)
            => new(new AliasExpression<TimeSpan?>(element1), new LiteralExpression<TimeSpan>(element2));

        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">The returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableTimeSpanIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement{TimeSpan}"/>?.</returns>
        public static NullableTimeSpanIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, TimeSpan? element2)
            => new(new AliasExpression<TimeSpan?>(element1), new LiteralExpression<TimeSpan?>(element2));
        #endregion

        #region any element
        /// <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An alias of an expression , if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An expression of type <see cref="AnyElement{Boolean}"/>?, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement"/>?.</returns>
        public static NullableObjectIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, (string TableName, string FieldName) element1, AnyElement element2)
            => new(new AliasExpression<object?>(element1), element2);

        // <summary>
        /// Construct an expression for the ISNULL transact sql function.
        /// <para><see href="https://dbexpression.com/rtd/reference/mssql/functions/expressions/isnull">read the docs on ISNULL</see></para>
        /// </summary>
        /// <param name="element">An expression of type <see cref="AnyElement"/>, if this value evaluates to a (database) NULL, <paramref name="value"/> will be returned.</param>
        /// <param name="value">An alias of an expression, the returned value if <paramref name="element"/> evaluates to a (database) NULL.</param>
        /// <returns><see cref="NullableObjectIsNullFunctionExpression"/> for use with any operation accepting a <see cref="AnyElement"/>?.</returns>
        public static NullableObjectIsNullFunctionExpression IsNull(this SqlFunctionExpressionBuilder _, AnyElement element1, (string TableName, string FieldName) element2)
            => new(element1, new AliasExpression<object?>(element2));
        #endregion
    }
}
