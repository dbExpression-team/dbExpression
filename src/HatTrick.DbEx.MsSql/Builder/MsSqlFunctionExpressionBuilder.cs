using HatTrick.DbEx.MsSql.Expression;
using HatTrick.DbEx.Sql.Builder;
using HatTrick.DbEx.Sql.Builder.Syntax;
using HatTrick.DbEx.Sql.Expression;
using System;

namespace HatTrick.DbEx.MsSql.Builder
{
    public partial class MsSqlFunctionExpressionBuilder : SqlFunctionExpressionBuilder
    {
        #region cast
        public static ICastFunctionExpressionBuilder Cast(ISupportedForFunctionExpression<CastFunctionExpression> function)
            => new CastFunctionExpressionBuilder(function);
        #endregion

        #region date
        public static DateAddFunctionExpression DateAdd(DateParts datePart, int number, ISupportedForFunctionExpression<IDbDateFunctionExpression> field)
            => new DateAddFunctionExpression(field, (typeof(DateParts), datePart), number);

        public static DatePartFunctionExpression DatePart(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> field)
            => new DatePartFunctionExpression(field, datePart);

        public static DateDiffFunctionExpression DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> startDate, DateTime endDate)
            => new DateDiffFunctionExpression(datePart, startDate, endDate);

        public static DateDiffFunctionExpression DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> startDate, DateTimeOffset endDate)
            => new DateDiffFunctionExpression(datePart, startDate, endDate);

        public static DateDiffFunctionExpression DateDiff(DateParts datePart, DateTime startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression> endDate)
            => new DateDiffFunctionExpression(datePart, startDate, endDate);

        public static DateDiffFunctionExpression DateDiff(DateParts datePart, DateTimeOffset startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression> endDate)
            => new DateDiffFunctionExpression(datePart, startDate, endDate);

        public static DateDiffFunctionExpression DateDiff(DateParts datePart, ISupportedForFunctionExpression<IDbDateFunctionExpression> startDate, ISupportedForFunctionExpression<IDbDateFunctionExpression> endDate)
            => new DateDiffFunctionExpression(datePart, startDate, endDate);

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
    }
}
