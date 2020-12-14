using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    /// <inheritdoc/>
    public partial class MsSqlFunctionExpressionBuilder : SqlFunctionExpressionBuilder
    {
        #region cast
        #region object
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="AnyObjectElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(AnyObjectElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);
        #endregion

        #region bool
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="BooleanElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(BooleanElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableBooleanElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableBooleanElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region byte
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="ByteElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(ByteElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableByteElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableByteElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="DateTimeElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(DateTimeElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableDateTimeElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="DateTimeOffsetElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(DateTimeOffsetElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeOffsetElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableDateTimeOffsetElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region decimal
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="DecimalElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(DecimalElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableDecimalElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableDecimalElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region double
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="DoubleElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(DoubleElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableDoubleElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableDoubleElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region enum
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="EnumElement{TEnum}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast<TEnum>(EnumElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new MsSqlCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(element));

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableEnumElement{TEnum}"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast<TEnum>(NullableEnumElement<TEnum> element)
            where TEnum : struct, Enum, IComparable
            => new MsSqlNullableCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(element));
        #endregion

        #region float
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="SingleElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(SingleElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableSingleElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableSingleElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region Guid
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="GuidElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(GuidElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableGuidElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableGuidElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region short
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="Int16Element"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(Int16Element element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableInt16Element"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableInt16Element element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region int
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="Int32Element"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(Int32Element element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableInt32Element"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableInt32Element element)
            => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region long
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="Int64Element"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(Int64Element element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableInt64Element"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableInt64Element element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region string
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="StringElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(StringElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);


        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableStringElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableStringElement element)
            => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion

        #region TimeSpan
        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="TimeSpanElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="Cast"/> to specify the sql data type to convert to.</returns>
        public static Cast Cast(TimeSpanElement element)
            => new MsSqlCastFunctionExpressionBuilder(element);

        /// <summary>
        /// Construct an expression for the CAST transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/cast-and-convert-transact-sql">Microsoft docs on CAST</see></para>
        /// </summary>
        /// <param name="element">Any expression of type <see cref="NullableTimeSpanElement"/> to convert to a different sql data type.</param>
        /// <returns><see cref="NullableCast"/> to specify the sql data type to convert to.</returns>
        public static NullableCast Cast(NullableTimeSpanElement element)
           => new MsSqlNullableCastFunctionExpressionBuilder(element);
        #endregion
        #endregion

        #region date add
        #region object
        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyObjectElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, AnyObjectElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyObjectElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, AnyObjectElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="Int32Element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyObjectElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, AnyObjectElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="NullableInt32Element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyObjectElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, AnyObjectElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeElement element)
            => new DateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullableDateTimeElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, DateTimeElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, NullableDateTimeElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, DateTimeElement element)
            => new DateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, NullableDateTimeElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="NullableInt32Element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, DateTimeElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="NullableInt32Element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="NullableDateTimeElement"/>.</returns>
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, NullableDateTimeElement element)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeOffsetElement element)
            => new DateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int? value, DateTimeOffsetElement element)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int? value, NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="DateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="DateTimeOffsetElement"/>.</returns>
        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, DateTimeOffsetElement element)
            => new DateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">The value to add to <paramref name="element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="NullableInt32Element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, DateTimeOffsetElement element)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);

        /// <summary>
        /// Construct an expression for the DATEADD transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/dateadd-transact-sql">Microsoft docs on DATEADD</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date to add <paramref name="value"/> to.</param>
        /// <param name="value">Any expression of type <see cref="NullableInt32Element"/> to add to <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeOffsetElement"/> to add <paramref name="value"/> to.</param>
        /// <returns><see cref="NullableDateTimeOffsetDateAddFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeOffsetElement"/> or <see cref="NullableDateTimeOffsetElement"/>.</returns>
        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, NullableDateTimeOffsetElement element)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, element);
        #endregion
        #endregion

        #region date part
        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="AnyObjectElement"/> that represents a date.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, AnyObjectElement element)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeElement"/>.</param>
        /// <returns><see cref="Int32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeElement element)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeElement"/>.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullableDateTimeElement element)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="DateTimeOffsetElement"/>.</param>
        /// <returns><see cref="Int32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeOffsetElement element)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);

        /// <summary>
        /// Construct an expression for the DATEPART transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datepart-transact-sql">Microsoft docs on DATEPART</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the date value to extract from <paramref name="element"/>.</param>
        /// <param name="element">Any expression of type <see cref="NullableDateTimeOffsetElement"/>.</param>
        /// <returns><see cref="NullableInt32DatePartFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullableDateTimeOffsetElement element)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), element);
        #endregion

        #region date diff
        #region object
        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyDateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyObjectElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyObjectElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyDateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyObjectElement startDate, AnyDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyDateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyObjectElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyDateTimeElement startDate, AnyObjectElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyObjectElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyDateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyObjectElement startDate, AnyDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="AnyDateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="AnyObjectElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyDateTimeOffsetElement startDate, AnyObjectElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion

        #region DateTime
        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, DateTimeElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, DateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTime endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTimeElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, DateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion

        #region DateTimeOffset
        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, DateTimeOffsetElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, DateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">The starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(startDate)), endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">The ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffset endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="Int32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="Int32Element"/>.</returns>
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffsetElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="DateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, DateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        /// <summary>
        /// Construct an expression for the DATEDIFF transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/datediff-transact-sql">Microsoft docs on DATEDIFF</see></para>
        /// </summary>
        /// <param name="datePart">A <see cref="DateParts"/> specifying the part of the date value to use for calculation.</param>
        /// <param name="startDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the starting date used for calculation.</param>
        /// <param name="endDate">Any expression of type <see cref="NullableDateTimeOffsetElement"/>, the ending date used for calculation.</param>
        /// <returns><see cref="NullableInt32DateDiffFunctionExpression"/> for use with any operation accepting a <see cref="AnyInt32Element"/> or <see cref="NullableInt32Element"/>.</returns>
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion
        #endregion

        #region discrete date
        /// <summary>
        /// Construct an expression for the GETDATE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/getdate-transact-sql">Microsoft docs on GETDATE</see></para>
        /// </summary>
        /// <returns><see cref="GetDateFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static GetDateFunctionExpression GetDate()
            => new GetDateFunctionExpression();

        /// <summary>
        /// Construct an expression for the GETUTCDATE transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/getutcdate-transact-sql">Microsoft docs on GETUTCDATE</see></para>
        /// </summary>
        /// <returns><see cref="GetUtcDateFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static GetUtcDateFunctionExpression GetUtcDate()
            => new GetUtcDateFunctionExpression();

        /// <summary>
        /// Construct an expression for the SYSDATETIME transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sysdatetime-transact-sql">Microsoft docs on SYSDATETIME</see></para>
        /// </summary>
        /// <returns><see cref="SysDateTimeFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static SysDateTimeFunctionExpression SysDateTime()
            => new SysDateTimeFunctionExpression();

        /// <summary>
        /// Construct an expression for the SYSDATETIMEOFFSET transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sysdatetimeoffset-transact-sql">Microsoft docs on SYSDATETIMEOFFSET</see></para>
        /// </summary>
        /// <returns><see cref="SysDateTimeOffsetFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static SysDateTimeOffsetFunctionExpression SysDateTimeOffset()
            => new SysDateTimeOffsetFunctionExpression();

        /// <summary>
        /// Construct an expression for the SYSUTCDATETIME transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sysutcdatetimeoffset-transact-sql">Microsoft docs on SYSUTCDATETIME</see></para>
        /// </summary>
        /// <returns><see cref="SysUtcDateTimeFunctionExpression"/> for use with any operation accepting a <see cref="AnyDateTimeElement"/> or <see cref="DateTimeElement"/>.</returns>
        public static SysUtcDateTimeFunctionExpression SysUtcDateTime()
            => new SysUtcDateTimeFunctionExpression();
        #endregion

        /// <summary>
        /// Construct an expression for the NEWID transact sql function.
        /// <para><see href="https://docs.microsoft.com/en-us/sql/t-sql/functions/sysutcdatetimeoffset-transact-sql">Microsoft docs on NEWID</see></para>
        /// </summary>
        /// <returns><see cref="NewIdFunctionExpression"/> for use with any operation accepting a <see cref="AnyGuidElement"/> or <see cref="GuidElement"/>.</returns>
        public static NewIdFunctionExpression NewId()
             => new NewIdFunctionExpression();
    }
}
