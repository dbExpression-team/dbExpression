using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class MsSqlFunctionExpressionBuilder : SqlFunctionExpressionBuilder
    {
        #region cast
        #region bool
        public static ICastFunctionExpressionBuilder Cast(BooleanElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullBooleanElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region byte
        public static ICastFunctionExpressionBuilder Cast(ByteElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullByteElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region DateTime
        public static ICastFunctionExpressionBuilder Cast(DateTimeElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullDateTimeElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region DateTimeOffset
        public static ICastFunctionExpressionBuilder Cast(DateTimeOffsetElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullDateTimeOffsetElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region decimal
        public static ICastFunctionExpressionBuilder Cast(DecimalElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullDecimalElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region double
        public static ICastFunctionExpressionBuilder Cast(DoubleElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullDoubleElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region enum
        public static ICastFunctionExpressionBuilder Cast<TEnum>(EnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new MsSqlCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(field));

        public static INullableCastFunctionExpressionBuilder Cast<TEnum>(NullEnumElement<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new MsSqlNullableCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(field));
        #endregion

        #region float
        public static ICastFunctionExpressionBuilder Cast(SingleElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullSingleElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region Guid
        public static ICastFunctionExpressionBuilder Cast(GuidElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullGuidElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region short
        public static ICastFunctionExpressionBuilder Cast(Int16Element field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullInt16Element field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region int
        public static ICastFunctionExpressionBuilder Cast(Int32Element field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullInt32Element field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region long
        public static ICastFunctionExpressionBuilder Cast(Int64Element field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullInt64Element field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region string
        public static ICastFunctionExpressionBuilder Cast(StringElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);


        public static INullableCastFunctionExpressionBuilder Cast(NullStringElement field)
            => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region TimeSpan
        public static ICastFunctionExpressionBuilder Cast(TimeSpanElement field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullTimeSpanElement field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion
        #endregion

        #region date add
        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeElement field)
            => new DateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeOffsetElement field)
            => new DateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, DateTimeElement field)
            => new DateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, NullDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, DateTimeOffsetElement field)
            => new DateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, NullDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, DateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, NullDateTimeElement field)
            => new NullableDateTimeDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, DateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, NullDateTimeOffsetElement field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new DatePartsExpression<DateParts>(datePart), value, field);
        #endregion

        #region date part
        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeElement field)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullDateTimeElement field)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeOffsetElement field)
            => new Int32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);

        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullDateTimeOffsetElement field)
            => new NullableInt32DatePartFunctionExpression(new DatePartsExpression<DateParts>(datePart), field);
        #endregion

        #region date diff
        #region DateTime
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, DateTimeElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, NullDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, DateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, NullDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeElement startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeElement startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeExpressionMediator(new NullableLiteralExpression<DateTime?>(endDate)));

        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, DateTimeElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeElement startDate, NullDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeElement startDate, DateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeElement startDate, NullDateTimeElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);
        #endregion

        #region DateTimeOffset
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, DateTimeOffsetElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, NullDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, DateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, NullDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeOffsetElement startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeOffsetElement startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new NullableLiteralExpression<DateTimeOffset?>(endDate)));

        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, DateTimeOffsetElement endDate)
            => new Int32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetElement startDate, NullDateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeOffsetElement startDate, DateTimeOffsetElement endDate)
            => new NullableInt32DateDiffFunctionExpression(new DatePartsExpression<DateParts>(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullDateTimeOffsetElement startDate, NullDateTimeOffsetElement endDate)
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
