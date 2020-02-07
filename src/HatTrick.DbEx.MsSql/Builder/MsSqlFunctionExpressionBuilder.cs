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
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, bool> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, bool?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region byte
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, byte> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, byte?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region DateTime
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, DateTime> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, DateTime?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region DateTimeOffset
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, DateTimeOffset> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, DateTimeOffset?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region decimal
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, decimal> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, decimal?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region enum
        //public static ICastFunctionExpressionBuilder Cast<TEntity, TEnum>(EnumFieldExpression<TEntity, TEnum> field)
        //    where TEntity : IDbEntity
        //    where TEnum : struct, Enum, IComparable
        //    => new CastFunctionExpressionBuilder((field.GetType(), field));

        //public static INullableCastFunctionExpressionBuilder Cast<TEntity, TEnum>(NullableEnumFieldExpression<TEntity, TEnum> field)
        //    where TEntity : IDbEntity
        //    where TEnum : struct, Enum, IComparable
        //    => new NullableCastFunctionExpressionBuilder((field.GetType(), field));

        public static ICastFunctionExpressionBuilder Cast<TEnum>(EnumFieldExpression<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast<TEnum>(NullableEnumFieldExpression<TEnum> field)
            where TEnum : struct, Enum, IComparable
            => new NullableCastFunctionExpressionBuilder((field.GetType(), field));

        //public static ICastFunctionExpressionBuilder Cast<TEnum>(ISupportedForFunctionExpression<CastFunctionExpression, TEnum> field)
        //    where TEnum : struct, Enum, IComparable
        //     => new CastFunctionExpressionBuilder((field.GetType(), field));

        //public static INullableCastFunctionExpressionBuilder Cast<TEnum>(ISupportedForFunctionExpression<CastFunctionExpression, TEnum?> field)
        //   where TEnum : struct, Enum, IComparable
        //    => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region float
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, float> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, float?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region Guid
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, Guid> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, Guid?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region short
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, short> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, short?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region int
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, int> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, int?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region long
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, long> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));

        public static INullableCastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, long?> field)
           => new NullableCastFunctionExpressionBuilder((field.GetType(), field));
        #endregion

        #region string
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression, string> field)
            => new CastFunctionExpressionBuilder((field.GetType(), field));
        #endregion
        #endregion

        #region date add
        public static DateAddFunctionExpression<DateTime> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> field)
            => new DateAddFunctionExpression<DateTime>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTimeOffset> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> field)
            => new DateAddFunctionExpression<DateTimeOffset>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> field)
            => new NullableDateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTime> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> field)
            => new DateAddFunctionExpression<DateTime>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTimeOffset> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> field)
            => new DateAddFunctionExpression<DateTimeOffset>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> field)
            => new NullableDateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> field)
            => new DateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> field)
            => new DateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> field)
            => new NullableDateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));
        
        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));




        public static DateAddFunctionExpression<DateTime> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int> field)
            => new DateAddFunctionExpression<DateTime>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTimeOffset> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, int> field)
            => new DateAddFunctionExpression<DateTimeOffset>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, int value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (typeof(int), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTime> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int> field)
            => new DateAddFunctionExpression<DateTime>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTimeOffset> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, int> field)
            => new DateAddFunctionExpression<DateTimeOffset>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int>, int> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int> field)
            => new DateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static DateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, int> field)
            => new DateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTimeOffset?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<int?>, int?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTimeOffset?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> value, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));

        public static NullableDateAddFunctionExpression<DateTime?> DateAdd(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> value, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?> field)
            => new NullableDateAddFunctionExpression<DateTime?>((typeof(DateParts), datePart), (value.GetType(), value), (field.GetType(), field));
        #endregion

        #region date part
        public static DatePartFunctionExpression<int> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, int> field)
            => new DatePartFunctionExpression<int>((datePart.GetType(), datePart), (field.GetType(), field));

        public static DatePartFunctionExpression<int> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime?>, int?> field)
            => new DatePartFunctionExpression<int>((datePart.GetType(), datePart), (field.GetType(), field));

        public static NullableDatePartFunctionExpression<int?> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, int?> field)
            => new NullableDatePartFunctionExpression<int?>((datePart.GetType(), datePart), (field.GetType(), field));

        public static DatePartFunctionExpression<int> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> field)
            => new DatePartFunctionExpression<int>((datePart.GetType(), datePart), (field.GetType(), field));

        public static NullableDatePartFunctionExpression<int?> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> field)
            => new NullableDatePartFunctionExpression<int?>((datePart.GetType(), datePart), (field.GetType(), field));

        public static DatePartFunctionExpression<int> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> field)
            => new DatePartFunctionExpression<int>((datePart.GetType(), datePart), (field.GetType(), field));

        public static NullableDatePartFunctionExpression<int?> DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> field)
            => new NullableDatePartFunctionExpression<int?>((datePart.GetType(), datePart), (field.GetType(), field));
        #endregion

        #region date diff
        #region DateTime
        public static DateDiffFunctionExpression<int> DateDiff(DateParts datePart, DateTime startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> endDate)
            => new DateDiffFunctionExpression<int>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, DateTime startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, DateTime? startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, DateTime? startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> startDate, DateTime endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> startDate, DateTime? endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> startDate, DateTime endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> startDate, DateTime? endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static DateDiffFunctionExpression<int> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> endDate)
            => new DateDiffFunctionExpression<int>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTime>, DateTime> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTime?>, DateTime?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));
        #endregion

        #region DateTimeOffset
        public static DateDiffFunctionExpression<int> DateDiff(DateParts datePart, DateTimeOffset startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> endDate)
            => new DateDiffFunctionExpression<int>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, DateTimeOffset startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, DateTimeOffset? startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, DateTimeOffset? startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> startDate, DateTimeOffset endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> startDate, DateTimeOffset? endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> startDate, DateTimeOffset endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> startDate, DateTimeOffset? endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static DateDiffFunctionExpression<int> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> endDate)
            => new DateDiffFunctionExpression<int>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression<DateTimeOffset>, DateTimeOffset> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));

        public static NullableDateDiffFunctionExpression<int?> DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> startDate, ISupportedForFunctionExpression<IDbNullableDateFunctionExpression<DateTimeOffset?>, DateTimeOffset?> endDate)
            => new NullableDateDiffFunctionExpression<int?>((datePart.GetType(), datePart), (startDate.GetType(), startDate), (endDate.GetType(), endDate));
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
