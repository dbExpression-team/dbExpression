using System;

namespace HatTrick.DbEx.Sql.Expression
{
    public abstract class DatePartFunctionExpression<TValue> : DatePartFunctionExpression
        where TValue : IComparable
    {
        #region constructors
        protected DatePartFunctionExpression(DatePartsExpression datePart, ExpressionMediator<DateTime> startDate) : base(datePart, startDate)
        {
        }

        protected DatePartFunctionExpression(DatePartsExpression datePart, ExpressionMediator<DateTimeOffset> startDate) : base(datePart, startDate)
        {
        }
        #endregion
    }
}
