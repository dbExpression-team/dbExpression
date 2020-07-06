using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DatePartFunctionExpression<TValue> : DatePartFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected DatePartFunctionExpression(ExpressionContainer datePart, ExpressionMediator<DateTime> startDate) : base(datePart, startDate)
        {
        }

        protected DatePartFunctionExpression(ExpressionContainer datePart, ExpressionMediator<DateTimeOffset> startDate) : base(datePart, startDate)
        {
        }
        #endregion
    }
}
