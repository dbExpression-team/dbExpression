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
        public static ICastFunctionExpressionBuilder Cast(BooleanExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableBooleanExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region byte
        public static ICastFunctionExpressionBuilder Cast(ByteExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableByteExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region DateTime
        public static ICastFunctionExpressionBuilder Cast(DateTimeExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableDateTimeExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region DateTimeOffset
        public static ICastFunctionExpressionBuilder Cast(DateTimeOffsetExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableDateTimeOffsetExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region decimal
        public static ICastFunctionExpressionBuilder Cast(DecimalExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableDecimalExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region enum
        public static ICastFunctionExpressionBuilder Cast<TEnum>(IEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new MsSqlCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(field));

        public static INullableCastFunctionExpressionBuilder Cast<TEnum>(INullableEnumExpressionMediator<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new MsSqlNullableCastFunctionExpressionBuilder(new NullableEnumExpressionMediator<TEnum>(field));
        #endregion

        #region float
        public static ICastFunctionExpressionBuilder Cast(SingleExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableSingleExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region Guid
        public static ICastFunctionExpressionBuilder Cast(GuidExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableGuidExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region short
        public static ICastFunctionExpressionBuilder Cast(Int16ExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableInt16ExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region int
        public static ICastFunctionExpressionBuilder Cast(Int32ExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableInt32ExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region long
        public static ICastFunctionExpressionBuilder Cast(Int64ExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);

        public static INullableCastFunctionExpressionBuilder Cast(NullableInt64ExpressionMediator field)
           => new MsSqlNullableCastFunctionExpressionBuilder(field);
        #endregion

        #region string
        public static ICastFunctionExpressionBuilder Cast(StringExpressionMediator field)
            => new MsSqlCastFunctionExpressionBuilder(field);
        #endregion
        #endregion

        #region date add
        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeExpressionMediator field)
            => new DateTimeDateAddFunctionExpression(new ExpressionContainer(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullableDateTimeExpressionMediator field)
            => new NullableDateTimeDateAddFunctionExpression(new ExpressionContainer(datePart), new NullableInt32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, DateTimeOffsetExpressionMediator field)
            => new DateTimeOffsetDateAddFunctionExpression(new ExpressionContainer(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, int value, NullableDateTimeOffsetExpressionMediator field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new ExpressionContainer(datePart), new Int32ExpressionMediator(new LiteralExpression<int>(value)), field);

        public static DateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, DateTimeExpressionMediator field)
            => new DateTimeDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, NullableDateTimeExpressionMediator field)
            => new NullableDateTimeDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static DateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, DateTimeOffsetExpressionMediator field)
            => new DateTimeOffsetDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, Int32ExpressionMediator value, NullableDateTimeOffsetExpressionMediator field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, DateTimeExpressionMediator field)
            => new NullableDateTimeDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static NullableDateTimeDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, NullableDateTimeExpressionMediator field)
            => new NullableDateTimeDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, DateTimeOffsetExpressionMediator field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);

        public static NullableDateTimeOffsetDateAddFunctionExpression DateAdd(DateParts datePart, NullableInt32ExpressionMediator value, NullableDateTimeOffsetExpressionMediator field)
            => new NullableDateTimeOffsetDateAddFunctionExpression(new ExpressionContainer(datePart), value, field);
        #endregion

        #region date part
        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeExpressionMediator field)
            => new Int32DatePartFunctionExpression(new ExpressionContainer(datePart), field);

        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullableDateTimeExpressionMediator field)
            => new NullableInt32DatePartFunctionExpression(new ExpressionContainer(datePart), field);

        public static Int32DatePartFunctionExpression DatePart(DateParts datePart, DateTimeOffsetExpressionMediator field)
            => new Int32DatePartFunctionExpression(new ExpressionContainer(datePart), field);

        public static NullableInt32DatePartFunctionExpression DatePart(DateParts datePart, NullableDateTimeOffsetExpressionMediator field)
            => new NullableInt32DatePartFunctionExpression(new ExpressionContainer(datePart), field);
        #endregion

        #region date diff
        #region DateTime
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, DateTimeExpressionMediator endDate)
            => new Int32DateDiffFunctionExpression(new ExpressionContainer(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, NullableDateTimeExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), new DateTimeExpressionMediator(new LiteralExpression<DateTime>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, DateTimeExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime? startDate, NullableDateTimeExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeExpressionMediator startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeExpressionMediator startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeExpressionMediator startDate, DateTime endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new DateTimeExpressionMediator(new LiteralExpression<DateTime>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeExpressionMediator startDate, DateTime? endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new NullableDateTimeExpressionMediator(new LiteralExpression<DateTime?>(endDate)));

        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeExpressionMediator startDate, DateTimeExpressionMediator endDate)
            => new Int32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeExpressionMediator startDate, NullableDateTimeExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeExpressionMediator startDate, DateTimeExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeExpressionMediator startDate, NullableDateTimeExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);
        #endregion

        #region DateTimeOffset
        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, DateTimeOffsetExpressionMediator endDate)
            => new Int32DateDiffFunctionExpression(new ExpressionContainer(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, NullableDateTimeOffsetExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, DateTimeOffsetExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset? startDate, NullableDateTimeOffsetExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(startDate)), endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetExpressionMediator startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetExpressionMediator startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetExpressionMediator startDate, DateTimeOffset endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new DateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset>(endDate)));

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetExpressionMediator startDate, DateTimeOffset? endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, new NullableDateTimeOffsetExpressionMediator(new LiteralExpression<DateTimeOffset?>(endDate)));

        public static Int32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetExpressionMediator startDate, DateTimeOffsetExpressionMediator endDate)
            => new Int32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffsetExpressionMediator startDate, NullableDateTimeOffsetExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetExpressionMediator startDate, DateTimeOffsetExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);

        public static NullableInt32DateDiffFunctionExpression DateDiff(DateParts datePart, NullableDateTimeOffsetExpressionMediator startDate, NullableDateTimeOffsetExpressionMediator endDate)
            => new NullableInt32DateDiffFunctionExpression(new ExpressionContainer(datePart), startDate, endDate);
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
