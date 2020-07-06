using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class NullableDateDiffFunctionExpression<TValue> : NullableDateDiffFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        public NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator<DateTime> startDate, ExpressionMediator<DateTime> endDate) : base(datePart, startDate, endDate)
        {
        }

        public NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator<DateTimeOffset> startDate, ExpressionMediator<DateTime> endDate) : base(datePart, startDate, endDate)
        {
        }

        public NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator<DateTime> startDate, ExpressionMediator<DateTimeOffset> endDate) : base(datePart, startDate, endDate)
        {
        }

        public NullableDateDiffFunctionExpression(ExpressionContainer datePart, ExpressionMediator<DateTimeOffset> startDate, ExpressionMediator<DateTimeOffset> endDate) : base(datePart, startDate, endDate)
        {
        }
        #endregion
    }
}
