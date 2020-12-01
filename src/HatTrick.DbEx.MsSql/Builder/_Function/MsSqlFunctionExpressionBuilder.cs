using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class MsSqlFunctionExpressionBuilder : SqlFunctionExpressionBuilder
    {
        #region cast
        #region object
        public static Cast Cast(AnyObjectElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);
        #endregion

        #region bool
        public static Cast Cast(BooleanElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableBooleanElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region byte
        public static Cast Cast(ByteElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableByteElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region DateTime
        public static Cast Cast(DateTimeElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableDateTimeElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region DateTimeOffset
        public static Cast Cast(DateTimeOffsetElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableDateTimeOffsetElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region decimal
        public static Cast Cast(DecimalElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableDecimalElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region double
        public static Cast Cast(DoubleElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableDoubleElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region enum
        public static Cast Cast<TEnum>(EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new MsSqlCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(field));

        public static NullableCast Cast<TEnum>(NullableEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new MsSqlNullableCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(field));
        #endregion

        #region float
        public static Cast Cast(SingleElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableSingleElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region Guid
        public static Cast Cast(GuidElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableGuidElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region short
        public static Cast Cast(Int16Element field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableInt16Element field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region int
        public static Cast Cast(Int32Element field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableInt32Element field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region long
        public static Cast Cast(Int64Element field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableInt64Element field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region string
        public static Cast Cast(StringElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);


        public static NullableCast Cast(NullableStringElement field)
            => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region TimeSpan
        public static Cast Cast(TimeSpanElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static NullableCast Cast(NullableTimeSpanElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion
        #endregion

        #region date add
        #region object
        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, AnyObjectElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, AnyObjectElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, AnyObjectElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, AnyObjectElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);
        #endregion

        #region DateTime
        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeElement field)
            => new DateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullableDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, DateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int? value, NullableDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), field);

        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, DateTimeElement field)
            => new DateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, NullableDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, DateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, NullableDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);
        #endregion

        #region DateTimeOffset
        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeOffsetElement field)
            => new DateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullableDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int? value, DateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int? value, NullableDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int?>(value)), field);

        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, DateTimeOffsetElement field)
            => new DateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32Element value, NullableDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, DateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32Element value, NullableDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);
        #endregion
        #endregion

        #region date part
        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, AnyObjectElement field)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeElement field)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullableDateTimeElement field)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeOffsetElement field)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullableDateTimeOffsetElement field)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);
        #endregion

        #region date diff
        #region object
        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, AnyObjectElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyObjectElement startDate, AnyDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyDateTimeElement startDate, AnyObjectElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyObjectElement startDate, AnyDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, AnyDateTimeOffsetElement startDate, AnyObjectElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion

        #region DateTime
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, DateTimeElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, DateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(endDate)));

        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTimeElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, DateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeElement startDate, NullableDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion

        #region DateTimeOffset
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, DateTimeOffsetElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, DateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(endDate)));

        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffsetElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, DateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetElement startDate, NullableDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion
        #endregion

        #region discrete date
        public static GetDateFunctionExpression GetDate()
            => new GetDateFunctionExpression();

        public static GetUtcDateFunctionExpression GetUtcDate()
            => new GetUtcDateFunctionExpression();

        public static SysDateTimeFunctionExpression SysDateTime()
            => new SysDateTimeFunctionExpression();

        public static SysDateTimeOffsetFunctionExpression SysDateTimeOffset()
            => new SysDateTimeOffsetFunctionExpression();

        public static SysUtcDateTimeFunctionExpression SysUtcDateTime()
            => new SysUtcDateTimeFunctionExpression();
        #endregion

        public static NewIdFunctionExpression NewId()
             => new NewIdFunctionExpression();
    }
}
